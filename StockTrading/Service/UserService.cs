using StockTrading.Data;
using StockTrading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockTrading.Service
{
    /// <summary>
    /// Class for user service
    /// </summary>
    public class UserService
    {
        /// <summary>
        /// User Details Data
        /// </summary>
        private readonly UserData userData;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService" /> class
        /// </summary>
        public UserService()
        {
            this.userData = new UserData();
        }

        /// <summary>
        /// Method to Get User Details By Email and Password
        /// </summary>
        /// <param name="objUserBO"></param>
        /// <returns></returns>
        public UserBO GetUserDetailsByUserNameAndPassword(string email, string password)
        {
            return this.userData.FindUserDetailsByUserNameAndPassword(email, password);
        }

        /// <summary>
        /// Method to save user details
        /// </summary>
        /// <param name="userDetails">user model</param>
        /// <returns>Returns int whether user created or not</returns>
        public int SaveUserDetails(UserBO userDetails)
        {
            return this.userData.AddUserDetails(userDetails);
        }

        /// <summary>
        /// Method to update user password
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <returns>Returns int whether user password is updated or not</returns>
        public int SaveUserPassword(int userId, string password)
        {
            return this.userData.AddUserPassword(userId, password);
        }
    }
}