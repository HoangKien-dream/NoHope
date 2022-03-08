using Assigment_Mvc.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assigment_Mvc.Data
{
    public class MyIdentityDbContext: IdentityDbContext<Account>
    {
        public MyIdentityDbContext() : base("ConnectionString")
        {

        }
    }
}