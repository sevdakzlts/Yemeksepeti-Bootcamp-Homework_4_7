using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework_4_7.API.Models;

namespace Homework_4_7.API.Data
{
    public class UserData
    {
        private static volatile UserData _instance = null;
        private static readonly object padLock = new object();

        public static UserData Instance
        {
            get
            {
                lock (padLock)
                {
                    if (_instance == null)
                    {
                        _instance = new UserData();
                    }
                }
                return _instance;
            }
        }

        private UserData()
        {
            FillData();
        }

        private void FillData()
        {
            for (int i = 1; i <= 10; i++)
            {
                Users.Add(new User { Id = i, Name = "User_" + i, UserRole = UserRole.Admin});
            }
        }

        public List<User> Users = new List<User>();
    }
}

