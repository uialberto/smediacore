using System;
using System.Collections.Generic;
using System.Text;
using Uibasoft.Smedia.Core.Enumerations;

namespace Uibasoft.Smedia.Core.DTOs
{
    public class SecurityDto
    {
        public string Nombres { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public RoleType? Role { get; set; }
    }
}
