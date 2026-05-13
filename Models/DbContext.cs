using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace finalproject3312.Models;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {

        }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlayerCharacter>().HasKey(p=>new{p.PlayerID,p.CharacterID});
    }

    public DbSet<Player> Players {get;set;}
    public DbSet<Character> Characters {get;set;}
    public DbSet<PlayerCharacter> PlayerCharacters {get;set;}
}