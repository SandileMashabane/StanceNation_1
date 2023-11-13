using Microsoft.EntityFrameworkCore;
using StanceNation_1.Models;
using System.Collections.Generic;

namespace StanceNation_1.Data
{
    public class dbContext : DbContext
    {
       
        public dbContext(DbContextOptions<dbContext> options) : base(options) { }
     
        
        public DbSet<StanceNation_1.Models.EventsModel> Events { get; set; } = default!;
        }
    

}
