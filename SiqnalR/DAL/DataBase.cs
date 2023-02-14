using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SiqnalR.Models;

namespace SiqnalR.DAL
{
    public class DataBase : IdentityDbContext<AppUser>
    {
        public DataBase(DbContextOptions<DataBase> options):base(options)
        {
            
        }
    }
}