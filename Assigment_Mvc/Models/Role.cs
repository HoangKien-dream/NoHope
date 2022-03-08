using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assigment_Mvc.Models
{
    public class Role : IdentityRole
    {
        public string Desciption { get; set; }
    }
}