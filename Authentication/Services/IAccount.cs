﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication.Models;

namespace Authentication.Services
{
    public interface IAccount
    {
        public User login(User u);
        public User checkRegistered(User u);
        public bool register(User u);
        public User getUserById(string userId);
    }
}
