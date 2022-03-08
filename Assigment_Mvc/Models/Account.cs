using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assigment_Mvc.Models
{
    public class Account : IdentityUser
    {
        public string IdentityCard { get; set; }
        public int Status { get; set; }
    }
}