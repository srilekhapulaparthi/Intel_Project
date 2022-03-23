using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockTrading.Models
{
    /// <summary>
    /// Class for User BO
    /// </summary>
    public class UserBO
    {
        /// <summary>
        /// Gets or sets UseId
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Ges or sets RoleId
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Ges or sets Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Ges or sets Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Ges or sets First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Ges or sets Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Ges or sets Mobile No
        /// </summary>
        public string MobileNo { get; set; }

        /// <summary>
        /// Ges or sets Available cash
        /// </summary>
        public decimal AvailableCash { get; set; }

    }
}