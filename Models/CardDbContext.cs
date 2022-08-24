using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Breakfast_Cards_Manage_System.Models
{
    public class CardDbContext:DbContext
    {
        public CardDbContext(DbContextOptions<CardDbContext> options):base(options)
        { }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Cards> Cardss { get; set; }
    }
}
