using Authentication.Data;
using Authentication.Models;
using Authentication.Models.Dtos;
using Authentication.Services;
using Authentication.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Authentication.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataContext db;
        //private readonly IAccount _service;
        TokenController TC = new TokenController();
        public AccountController(DataContext db)
        {
            this.db = db;
        }
        //public AccountController(IAccount _service)
        //{
        //    this._service = _service;
        //}

        [Route("/[controller]/login")]
        [HttpPost]
        public string login([FromHeader] string Authorization, [FromBody] User u)
        {
            string validToken = "";

            //check if exists
            //var user = db.Users.Where(x => x.email.Equals(u.email) && x.password.Equals(u.password)).FirstOrDefault();
            var user = (from User in db.Users
                        where User.email == u.email && User.password == u.password
                        select User).FirstOrDefault();
            string json = JsonConvert.SerializeObject(user);

            if (json == "[]")
            {
                return "Niet gevonden";
            }
            else
            {
                if (user == null)
                {
                    return null;
                }
                UserDTO uDTO = new UserDTO();
                //wel gevonden valideren
                if (Authorization == null)
                {
                    Authorization = "Invalid";
                }

                if (TC.isExpired(Authorization))
                {
                    //als token niet valid is
                    //redirect naar login
                    validToken = loginNoToken(user.userId);
                    uDTO.email = u.email;
                    uDTO.token = validToken;
                    return JsonConvert.SerializeObject(uDTO);
                }
                else
                {

                    //Als token wel valid is log meteen in
                    uDTO.email = u.email;
                    uDTO.token = Authorization;
                    return JsonConvert.SerializeObject(uDTO);
                }
            }
        }

        //public string loginNoToken(string email, int role)
        //{
        //    string validToken = TC.nonExistentToken(email, role);

        //    return validToken;
        //}
        public string loginNoToken(int id)
        {
            string validToken = TC.nonExistentToken(id);

            return validToken;
        }

        [Route("/[controller]/register")]
        [HttpPost]
        public User register([FromBody] User u)
        {
            if (u.email == "" || u.firstName == "" || u.lastName == "" || u.adress == "" || u.housenumber == "" || u.password == "")
            {
                return null;
            }
            else
            {
                var user = db.Users.Where(x => x.email.Equals(u.email)).FirstOrDefault();

                if (user == null)
                {
                    try
                    {
                        db.Users.Add(u);
                        db.SaveChanges();
                        return u;
                        //redirect naar login page.
                    }
                    catch
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }

        }

        //[Authorize]
        //[HttpGet]
        //[Route("/[controller]/getUser")]
        //public User getUser([FromHeader] string Authorization)
        //{
        //    var x = TC.readOut(Authorization);
        //    User user = db.Users.Where(x => x.email.Equals(x.email)).FirstOrDefault();
        //    return user;
        //}
        [Authorize]
        [HttpGet]
        [Route("/[controller]/getUser")]
        public User getUser([FromHeader] string Authorization)
        {
            string userId = "";
            string[] tokentemp = Authorization.Split(" ");
            List<Claim> data = new List<Claim>();
            var token = tokentemp[1];
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            foreach (Claim c in jwtSecurityToken.Claims)
            {
                if (c.Type == "userId")
                {
                    userId = c.Value;
                }
            }
            var x = TC.readOut(Authorization);
            User u = (from User in db.Users
                        where User.userId == Convert.ToInt32(userId)
                        select User).FirstOrDefault();
            //User user = db.Users.Where(x => x.userId.Equals(x.userId)).FirstOrDefault();
            return u;
        }

        


        //[Authorize]
        //[HttpPut]
        //[Route("/[controller]/Update")]
        //public string EditUser(User mode)
        //{
        //    User user = db.Users.Where(x => x.userId == mode.userId).Single<User>();
        //    user.userId = mode.userId;
        //    user.firstName = mode.firstName;
        //    user.lastName = mode.lastName;
        //    user.adress = mode.adress;
        //    user.housenumber = mode.housenumber;
        //    user.city = mode.city;
        //    user.email = mode.email;
        //    user.password = mode.password;

        //    db.Entry(user).State = EntityState.Modified;
        //    db.SaveChanges();
        //    return "User has been Updated";
        //}

        [Authorize]
        [HttpDelete]
        [Route("/[controller]/delete")]
        public string DeleteUserbyID([FromHeader] string Authorization)
        {
            string userId = "";
            string[] tokentemp = Authorization.Split(" ");
            List<Claim> data = new List<Claim>();
            var token = tokentemp[1];
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            foreach (Claim c in jwtSecurityToken.Claims)
            {
                if (c.Type == "userId")
                {
                    userId = c.Value;
                }
            }
            User user = db.Users.Where(x => x.userId == Convert.ToInt32(userId)).Single<User>();
            db.Users.Remove(user);
            db.SaveChanges();
            return "User has successfully been Deleted";
        }

        [Authorize]
        [HttpPut]
        [Route("/[controller]/changeaccount")]
        public string updateAccount([FromHeader] string Authorization, [FromBody] User updated)
        {
            string userId = "";
            string[] tokentemp = Authorization.Split(" ");
            List<Claim> data = new List<Claim>();
            var token = tokentemp[1];
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            foreach (Claim c in jwtSecurityToken.Claims)
            {
                if (c.Type == "userId")
                {
                    userId = c.Value;
                }
            }
            User user = db.Users.Where(x => x.userId == Convert.ToInt32(userId)).Single<User>();
            //userId = Convert.ToString(mode.userId);
           
            user.firstName = updated.firstName;
            user.lastName = updated.lastName;
            user.adress = updated.adress;
            user.housenumber = updated.housenumber;
            user.city = updated.city;
            user.email = updated.email;
            user.password = updated.password;
            user.userId = Convert.ToInt32(userId);
            db.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return "Database is geupdate";
            

        }
    }

    
}
//        private readonly IAccount _service;
//        TokenController TC = new TokenController();
//        public AccountController(IAccount _service)
//        {
//            this._service = _service;
//        }

//        [Route("/[controller]/login")]
//        [HttpPost]
//        public string login([FromHeader] string Authorization, [FromBody] User u)
//        {
//            string validToken = "";

//            //check if exists
//            var user = _service.login(u);

//            string json = JsonConvert.SerializeObject(user);

//            if (json == "null")
//            {
//                return "Niet gevonden";
//            }
//            else
//            {
//                if (user == null)
//                {
//                    return null;
//                }

//                UserDTO uDTO = new UserDTO();
//                //wel gevonden valideren
//                if (Authorization == null)
//                {
//                    Authorization = "Invalid";
//                }

//                if (TC.isExpired(Authorization))
//                {
//                    //als token niet valid is
//                    //redirect naar login
//                    validToken = loginNoToken(user.userId, user.role);
//                    uDTO.user = user;
//                    uDTO.token = validToken;
//                    return JsonConvert.SerializeObject(uDTO);
//                }
//                else
//                {
//                    //Als token wel valid is log meteen in
//                    uDTO.user = user;
//                    uDTO.token = Authorization;
//                    return JsonConvert.SerializeObject(uDTO);
//                }
//            }
//        }
//        public string loginNoToken(int id, int role)
//        {
//            string validToken = TC.nonExistentToken(id, role);

//            return validToken;
//        }

//        [Route("/[controller]/register")]
//        [HttpPost]
//        public bool register([FromBody] User u)
//        {
//            if (u.email == "" || u.firstName == "" || u.lastName == "" || u.adress == "" || u.housenumber == "" || u.password == "" ||
//                u.email == null || u.firstName == null || u.lastName == null || u.adress == null || u.housenumber == null || u.password == null)
//            {
//                return false;
//            }
//            else
//            {
//                var user = _service.checkRegistered(u);

//                if (user == null)
//                {
//                    try
//                    {
//                        return _service.register(u);

//                        //redirect naar login page.
//                    }
//                    catch
//                    {
//                        return false;
//                    }
//                }
//                else
//                {
//                    return false;
//                }
//            }

//        }

//        [Authorize]
//        [HttpGet]
//        [Route("/[controller]/getUser")]
//        public User getUser([FromHeader] string Authorization)
//        {
//            string userId = "0";
//            List<Claim> x = new List<Claim>();
//            //list met claims
//            try
//            {
//                x = TC.readOut(Authorization);
//            }
//            catch
//            {
//                return null;
//            }

//            foreach (Claim c in x)
//            {
//                if (c.Type == "userId")
//                {
//                    userId = c.Value;
//                }
//            }
//            if (userId == "0")
//            {
//                return null;
//            }
//            else
//            {
//                User user = _service.getUserById(userId);
//                return user;
//            }

//        }
//    }
//}


