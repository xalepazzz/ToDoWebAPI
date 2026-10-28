using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace BuisenessLogic.Entities
{
    public class User
    {
        Guid Id { get; set; } = Guid.NewGuid();
        string password { get; set; }
        string nickName { get; set; }
        string firstName { get; set; }
        string lastName { get; set; }
        string email { get; set; }
    }
}
