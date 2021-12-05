using Authentication.Data;
using Authentication.Controllers;
using Authentication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Xunit;

namespace CarPartsOnlineTest
{
    public class AuthenticationTest
    {
       
        private AccountController Initialize([CallerMemberName] string callerName = "")
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: "InMemoryProductDb_" + callerName).Options;
            var context = new DataContext(options);
            SeedProductInMemoryDatabaseWithData(context);
            return new AccountController(context);
        }
        private TokenController InitializeToken([CallerMemberName] string callerName = "")
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: "InMemoryProductDb_" + callerName).Options;
            var context = new DataContext(options);
            SeedProductInMemoryDatabaseWithData(context);
            return new TokenController();
        }


        private void SeedProductInMemoryDatabaseWithData(DataContext context)
        {
            var Users = new List<User>
            {
                new User { userId = 1, firstName = "Samson", email = "Samson@test.nl", password = "Samson" },
                new User { userId = 2, firstName = "Pieter", email = "Pieter@test.nl", password = "Pietje"},
                new User { userId = 3, firstName = "Gertje", email = "Gertje@test.nl", password = "Gertje"},
                new User { userId = 4, firstName = null, password = null, },
            };
            if (!context.Users.Any())
            {
                context.Users.AddRange(Users);
            }
            context.SaveChanges();
        }

        [Fact]
        private void LoginUser_shouldloginuser()
        {

            var controller = Initialize();
            var controller2 = InitializeToken();
            var usermodel = new User();
            string test = controller2.nonExistentToken("Samson@test.nl", 1);
            var result = controller.login(test, usermodel);
            Assert.IsType<string>(result);

        }

        [Fact]
        private void LoginNoToken_shouldnotloginuser()
        {
            var controller = Initialize();
            var usermodel = new User();

            var result = controller.loginNoToken("Samson@test.nl", 1);
            Assert.IsType<string>(result);
        }

        [Fact]
        private void Register_shouldregisteruser()
        {
            var controller = Initialize();
            var usermodel = new User();

            var result = controller.register(usermodel);
            Assert.IsType<string>(result);
        }

        [Fact]
        private void GetUser_shouldgetuser()
        {
            var controller = Initialize();
            var usermodel = new User();
            var test = controller.loginNoToken("Samson@test.nl", 1);
            var result = controller.getUser(test);
            Assert.IsType<User>(result);
        }


        [Fact]
        private void CreateToken_shouldcreatetoken()
        {
            var controller = InitializeToken();

            var result = controller.CreateToken("Samson");
            Assert.IsType<ObjectResult>(result);
        }

        [Fact]
        private void ReadOut_shouldreadouttoken()
        {
            var controller = InitializeToken();
            string test = controller.nonExistentToken("Samson@test.nl", 0);
            var result = controller.readOut(test);
            //Assert.IsType<>(result);
        }

        [Fact]
        private void isExpired_shouldcreatenewtoken()
        {
            var controller = InitializeToken();
            string test = controller.nonExistentToken("Samson@test.nl", 0);
            var result = controller.isExpired(test);
            Assert.IsType<string>(result);
        }

        [Fact]
        private void NonexistentToken_shouldgeneratenewtoken()
        {
            var controller = InitializeToken();

            var result = controller.nonExistentToken("Samson@test.nl", 0);
            Assert.IsType<string>(result);
        }
    }
}
