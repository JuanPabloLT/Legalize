using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Legalize.Common.Enums;

namespace Legalize.Web.Data.Entities
{
    public class UserEntity : IdentityUser
    {
        [Display(Name = "Document")]
        [MaxLength(20, ErrorMessage = "The Document field can not have more than {20} characters.")]
        [Required(ErrorMessage = "The field Document is mandatory.")]
        public string Document { get; set; }

        [Display(Name = "First Name")]
        [MaxLength(50, ErrorMessage = "The First Name field can not have more than {50} characters.")]
        [Required(ErrorMessage = "The field First Name is mandatory.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(50, ErrorMessage = "The Last Name field can not have more than {50} characters.")]
        [Required(ErrorMessage = "The field Last Name is mandatory.")]
        public string LastName { get; set; }

        [Display(Name = "Picture")]
        public string PicturePath { get; set; }

        [Display(Name = "User Type")]
        
        public UserType UserType { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";

        public ICollection<LegalizeEntity> Legalizes { get; set; }
        public ICollection<TripEntity> Trips { get; set; }

    }
}
