using IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class User : IUser
    {
        public string getUser(int id)
        {
            return "admin";
        }
    }
}
