using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace YHAdmin.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Användarnamn")]
        public string Username { get; set; }
        [Required]
        [Display(Name = "Lösenord")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
