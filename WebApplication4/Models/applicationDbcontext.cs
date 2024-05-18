using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace WebApplication4.Models


{
    public class ApplicationDbcontext :DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options): base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
           
   
        
        }

        public DbSet<product> Products { get; set; }
        public DbSet<stockInDetail> StockInDetails { get; set;}



    }
}
