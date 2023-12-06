using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment5_Meduna_Naumann.Models;

namespace Assignment5_Meduna_Naumann.Data
{
    public class Assignment5_Meduna_NaumannContext : DbContext
    {
        public Assignment5_Meduna_NaumannContext (DbContextOptions<Assignment5_Meduna_NaumannContext> options)
            : base(options)
        {
        }

        public DbSet<Assignment5_Meduna_Naumann.Models.Song> Song { get; set; } = default!;
    }
}
