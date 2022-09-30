using DnDWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DnDWebAPI.Data
{
    public class CharacterDbContext : DbContext
    {
        public CharacterDbContext( DbContextOptions<CharacterDbContext> options) 
            : base(options)
        {

        }
        public DbSet<Character> Characters { get; set; }
    }
}
