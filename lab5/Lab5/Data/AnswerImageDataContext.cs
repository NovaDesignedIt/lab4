using Lab5.Models;
using Microsoft.EntityFrameworkCore;


namespace Lab5.Data
{
    public class AnswerImageDataContext : DbContext
    {
        public AnswerImageDataContext(DbContextOptions<AnswerImageDataContext> options) : base(options)
        {
         

        }

        public DbSet<AnswerImage> AnswerImage { get; set; }


      
    }
}
