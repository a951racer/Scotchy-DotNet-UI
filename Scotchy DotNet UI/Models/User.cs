using System;
using System.ComponentModel.DataAnnotations;

namespace User.Model
{
    public class UserDTO
    {
        [Display(Name = "First Name")] public string firstName { get; set; }
        [Display(Name = "Last Name")] public string lastName { get; set; }
        [Display(Name = "Email")] public string email { get; set; }
        [Display(Name = "Username")] public string username { get; set; }
        [Display(Name = "Password")] public string password { get; set; }
        [Display(Name = "Salt")] public string salt { get; set; }
        [Display(Name = "Provider")] public string provider { get; set; }
        [Display(Name = "Provider Id")] public string providerId { get; set; }
        [Display(Name = "Created")] public DateTime created { get; set; }
        [Display(Name = "Full Name")] public virtual string fullName { get; set; }
    }

    public class CreatorDTO : UserDTO
    {
        [Display(Name = "Creator")] public override string fullName { get; set; }
    }
}