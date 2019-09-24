using System;
using System.Collections.Generic;

namespace GreatOutdoors.Entities
{
    public interface IUser
    {
        string Email { get; set; }
        string Password { get; set; }
    }
}