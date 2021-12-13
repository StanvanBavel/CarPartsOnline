using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authentication.Models;
using Authentication.Services;

namespace CarPartsOnlineTest
{
        public class AccountDB : IAccount
        {
            List<User> allUsers = new List<User>();
            public AccountDB()
            {
                User u = new User();
                u.userId = 1;
                u.email = "test@test.nl";
                u.password = "test";
                u.city = "TestStad";
                u.adress = "TestStraat 1";
                u.firstName = "Test";
                u.lastName = "Test";
                

                User u2 = new User();
                u2.userId = 2;
                u2.email = "a@a.nl";
                u2.password = "a";
                u2.city = "Astad";
                u2.adress = "Astraat 1";
                u2.firstName = "a";
                u2.lastName = "a";
                

                User u3 = new User();
                u3.userId = 3;
                u3.email = "b@b.nl";
                u3.password = "";
                u3.city = "Bstad";
                u3.adress = "Bstraat";
                u3.firstName = "B";
                u3.lastName = "B";
                

                allUsers.Add(u);
                allUsers.Add(u2);
                allUsers.Add(u3);
            }

            public User checkRegistered(User user)
            {
                foreach (User u in allUsers)
                {
                    if (u.email == user.email)
                    {
                        return u;
                    }
                }
                return null;
            }

            public User getUserById(string userId)
            {
                User returnUser = null;
                foreach (User u in allUsers)
                {
                    if (u.userId == Convert.ToInt32(userId))
                    {
                        returnUser = u;
                    }
                }
                return returnUser;
            }

            public User login(User user)
            {
                foreach (User u in allUsers)
                {
                    if (u.email == user.email)
                    {
                        if (u.password == user.password)
                        {
                            return u;
                        }
                    }
                }
                return null;
            }

            public bool register(User u)
            {
                try
                {
                    allUsers.Add(u);
                    if (allUsers.Count == 4)
                    {
                        return true;
                    }

                    return false;

                }
                catch
                {
                    return false;
                }
            }
        }
    }
