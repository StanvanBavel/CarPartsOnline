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
                new User { userId = 1, firstName = "Joop", email = "Joop@test.nl", password = "Joop" },
                new User { userId = 2, firstName = "Jaap", email = "Jaap@test.nl", password = "Jaap"},
                new User { userId = 3, firstName = "Samson", email = "Samson@test.nl", password = "Samson"},
                new User { userId = 4, firstName = null, password = null, },
            };
            if (!context.Users.Any())
            {
                context.Users.AddRange(Users);
            }
            context.SaveChanges();
        }

        [Fact]
        private void LoginUser_shouldloginuseraftertokengen()
        {

            var controller = Initialize();
            var controller2 = InitializeToken();
            var usermodel = new User();
            string test = controller2.nonExistentToken(1);
            var result = controller.login(test, usermodel);
            Assert.IsType<string>(result);

        }

        [Fact]
        private void LoginToken_shouldloginuser()
        {
            var controller = Initialize();
            var usermodel = new User();

            var result = controller.loginNoToken(1);
            Assert.IsType<string>(result);
        }

        [Fact]
        private void Register_shouldregisteruser()
        {
            var controller = Initialize();
            var usermodel = new User();

            var result = controller.register(usermodel);
            Assert.IsType<User>(result);
        }


        [Fact]
        private void CreateToken_shouldcreatetoken()
        {
            var controller = InitializeToken();

            var result = controller.CreateToken(1);
            Assert.IsType<ObjectResult>(result);
        }

        [Fact]
        private void ReadOut_shouldreadouttoken()
        {
            var controller = InitializeToken();
            string test = controller.nonExistentToken(1);
            var result = controller.readOut(test).ToString();
            

            Assert.IsType<string>(result);
        }

        [Fact]
        private void isExpired_shouldcreatenewtoken()
        {
            var controller = InitializeToken();
            string test = controller.nonExistentToken(1);
            var result = controller.isExpired(test);
            Assert.IsType <bool>(result);
        }

        [Fact]
        private void NonexistentToken_shouldgeneratenewtoken()
        {
            var controller = InitializeToken();

            var result = controller.nonExistentToken(1);
            Assert.IsType<string>(result);
        }

        //[Fact]
        //private void UpdateAccount_shouldupdatedata()
        //{

        //    var controller = Initialize();
        //    var usermodel = new User();
        //    usermodel.firstName = "piet";
        //    usermodel.email = "piet@mail.nl";
        //    usermodel.password = "SpaRood23";
        //    var test = controller.loginNoToken(1);
        //    var result = controller.updateAccount(test, usermodel);
        //    Assert.IsType<User>(result);
        //}

        //[Fact]
        //private void DeleteUserbyId_shoulddeleteuser()
        //{

        //    var controller = Initialize();
        //    var usermodel = new User();
        //    var test = controller.loginNoToken(1);
        //    var result = controller.DeleteUserbyID(test);
        //    Assert.IsType<User>(result);
        //}
    }
}