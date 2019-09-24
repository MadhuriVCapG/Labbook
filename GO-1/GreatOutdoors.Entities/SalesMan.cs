using System;
using System.Collections.Generic;
using System.Linq;
using GreatOutdoors.Helpers.ValidationAttributes;

namespace GreatOutdoors.Entities
{
    /// <summary>
    /// Interface for SalesMan Entity
    /// </summary>
    public interface ISalesMan
    {
        Guid SalesManID { get; set; }
        string SalesManName { get; set; }
        string SalesManMobile { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        DateTime CreationDateTime { get; set; }
        DateTime LastModifiedDateTime { get; set; }


    }

    /// <summary>
    /// Represents SalesMan
    /// </summary>
    public class SalesMan : ISalesMan, IUser
    {
        /* Auto-Implemented Properties */
        [Required("Sales Man ID can't be blank.")]
        public Guid SalesManID { get; set; }

        [Required("SalesMan Name can't be blank.")]
        [RegExp(@"^(\w{2,40})$", "Sales Man Name should contain only 2 to 40 characters.")]
        public string SalesManName { get; set; }

        [RegExp(@"^[6789]\d{9}$", "Mobile number should contain 10 digits")]
        public string SalesManMobile { get; set; }

        [Required("Email can't be blank.")]
        [RegExp(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", "Email is invalid.")]
        public string Email { get; set; }

        [Required("Password can't be blank.")]
        [RegExp(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,15})", "Password should be 6 to 15 characters with at least one digit, one uppercase letter, one lower case letter.")]
        public string Password { get; set; }

        public DateTime CreationDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }


        // Additional properties of Sales Man
        double SalesManSalary { get; set; }
        double SalesManBonus { get; set; }
        List<int> SalesIDs { get; set; }

        /* Constructor */
        public SalesMan()
        {
            SalesManID = default(Guid);
            SalesManName = null;
            SalesManMobile = null;
            Email = null;
            Password = null;
            CreationDateTime = default(DateTime);
            LastModifiedDateTime = default(DateTime);
            SalesManSalary =0;
            SalesManBonus = 0;
            SalesIDs = null;

        }
    }
}






