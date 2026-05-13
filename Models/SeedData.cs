using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace finalproject3312.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

        if(context.Characters.Any())
        {
            return;
        }
        context.Characters.AddRange(
    new Character { Name = "Beatrix", Description = "Beatrix is a samurai who wields two katanas, and rides on a black skateboard."},
    new Character { Name = "Phil", Description = "Phil is a mechanic who maintains turrets and wears a gray bandana."},
    new Character { Name = "Margot", Description = "Margot is a gardener who fights with shears and her walking cane, Margot is very short and wears black sneakers."},
    new Character { Name = "Robin", Description = "Robin is a paleontologist who harnesses the power of the sun with her magnifying glass, Robin wears a white lab coat."},
    new Character { Name = "Ted", Description = "Ted is the most ordinary man alive, Ted wears jeans and a blue t-shirt, Ted's weapon of choice is the Glock 19."}
);

context.SaveChanges();

List<Player> players = new List<Player>
{
	new Player { Username = "LockFly12", RunDate = DateTime.Parse("2025-02-25"), KillCount = 952},
	new Player { Username = "MonsterDJ1", RunDate = DateTime.Parse("2025-03-22"), KillCount = 1058},
	new Player { Username = "SilkySmooth", RunDate = DateTime.Parse("2025-10-10"), KillCount = 1123},
	new Player { Username = "AngryMongoose32", RunDate = DateTime.Parse("2025-01-17"), KillCount = 113},
	new Player { Username = "SmilingCentipede", RunDate = DateTime.Parse("2025-03-12"), KillCount = 4353},
	new Player { Username = "FatContrarian232", RunDate = DateTime.Parse("2025-04-20"), KillCount = 5322},
	new Player { Username = "RoundTelevision33", RunDate = DateTime.Parse("2025-06-13"), KillCount = 2144},
	new Player { Username = "ObtuseBattery112", RunDate = DateTime.Parse("2025-01-29"), KillCount = 11},
	new Player { Username = "LittlestChair645", RunDate = DateTime.Parse("2025-08-18"), KillCount = 5523},
	new Player { Username = "SlimmestTrack039", RunDate = DateTime.Parse("2025-05-18"), KillCount = 933},
	new Player { Username = "HariestWombat120", RunDate = DateTime.Parse("2025-03-30"), KillCount = 5500},
	new Player { Username = "LoudScent659", RunDate = DateTime.Parse("2025-07-23"), KillCount = 3031},
	new Player { Username = "SilentSmile020", RunDate = DateTime.Parse("2025-09-12"), KillCount = 13},
	new Player { Username = "StinkyPanda456", RunDate = DateTime.Parse("2025-11-11"), KillCount = 4151},
	new Player { Username = "Seven77", RunDate = DateTime.Parse("2025-10-19"), KillCount = 33},
	new Player { Username = "QuietSkater236", RunDate = DateTime.Parse("2025-02-08"), KillCount = 8733},
	new Player { Username = "FlirtyKiwi393", RunDate = DateTime.Parse("2025-12-25"), KillCount = 3036},
	new Player { Username = "WiredDog776", RunDate = DateTime.Parse("2025-12-12"), KillCount = 7439},
	new Player { Username = "SlimyCan302", RunDate = DateTime.Parse("2025-08-19"), KillCount = 3266},
	new Player { Username = "IndigoWrapper764", RunDate = DateTime.Parse("2025-03-22"), KillCount = 2345},
	new Player { Username = "BlackRemote752", RunDate = DateTime.Parse("2025-09-01"), KillCount = 2976},
	new Player { Username = "FourthCerveza974", RunDate = DateTime.Parse("2025-10-17"), KillCount = 3009},
	new Player { Username = "SkinnyPants888", RunDate = DateTime.Parse("2025-11-28"), KillCount = 8645},
	new Player { Username = "WirelessSofa820", RunDate = DateTime.Parse("2025-07-06"), KillCount = 3710},
	new Player { Username = "ProbedBracelet912", RunDate = DateTime.Parse("2025-11-05"), KillCount = 4450},
	new Player { Username = "James", RunDate = DateTime.Parse("2025-06-06"), KillCount = 986}
};

context.AddRange(players);
context.SaveChanges();

List<PlayerCharacter> playerCharacters = new List<PlayerCharacter>
{
	//First Player Characters Used
	new PlayerCharacter { PlayerID = 1, CharacterID = 1 },
	new PlayerCharacter { PlayerID = 1, CharacterID = 5 },
	new PlayerCharacter { PlayerID = 1, CharacterID = 2 },
	//Second Player Characters Used
	new PlayerCharacter { PlayerID = 2, CharacterID = 2 },
	new PlayerCharacter { PlayerID = 2, CharacterID = 3 },
	//Third Player Characters Used
	new PlayerCharacter { PlayerID = 3, CharacterID = 2 },
	new PlayerCharacter { PlayerID = 3, CharacterID = 4 },
	//Fourth Player Characters Used
	new PlayerCharacter { PlayerID = 4, CharacterID = 1 },
	new PlayerCharacter { PlayerID = 4, CharacterID = 5 },
	new PlayerCharacter { PlayerID = 4, CharacterID = 2 },
	//Fifth Player Characters Used
	new PlayerCharacter { PlayerID = 5, CharacterID = 1 },
	new PlayerCharacter { PlayerID = 5, CharacterID = 3 },
	new PlayerCharacter { PlayerID = 5, CharacterID = 4 },
	//Sixth Player Characters Used
	new PlayerCharacter { PlayerID = 6, CharacterID = 2 },
	new PlayerCharacter { PlayerID = 6, CharacterID = 4 },
};
context.AddRange(playerCharacters);
context.SaveChanges();
    }
}