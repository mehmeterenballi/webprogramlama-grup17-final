using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace VeritabaniProjesi.Models
{
    public class MyUser : IdentityUser
    {
        [Required, NotNull] public string NickName { get; set; }
        public bool IsAdmin { get; set; }
    }
}