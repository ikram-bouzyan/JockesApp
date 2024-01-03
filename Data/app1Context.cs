using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using app1.Models;

namespace app1.Data
{
    public class app1Context : DbContext
    {
        public app1Context (DbContextOptions<app1Context> options)
            : base(options)
        {
        }

        public DbSet<app1.Models.Jocke> Jocke { get; set; } = default!;
    }
}
