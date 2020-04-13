using Legalize.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Legalize.Common.Models
{
    public  class UserResponse
    {
        public string Document { get; set; }
 
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string PicturePath { get; set; }

        public UserType UserType { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";

    }
}
