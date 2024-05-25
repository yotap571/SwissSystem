using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SwissSystem.Models;
using System.Diagnostics;
using SwissSystem.Utils;
using MongoDB.Driver;


namespace SwissSystem.Services
{
    public class AuthenService
    {
        public bool Login(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                return true;
            }
            else
            {
                return false;
            }



        }

    }
}