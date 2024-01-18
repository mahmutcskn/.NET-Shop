using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrnekSite.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string SurName { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string Semt { get; set; }
        public string PostaKodu{ get; set; }
        [NotMapped]
        public string Role { get; set; }

    }
}
