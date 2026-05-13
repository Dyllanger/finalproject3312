using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace finalproject3312.Models;

public class Character
{
    public int CharacterID {get;set;} //pk
    public string Name {get;set;} = string.Empty;
    public string Description {get;set;} = string.Empty;
    public List<PlayerCharacter>? PlayerCharacters {get;set;} = default!; //nav
}

public class PlayerCharacter
{
    public int PlayerID {get;set;} //fk1
    public int CharacterID {get;set;} //fk2
    public Player Player {get;set;} = default!; //nav
    public Character Character {get;set;} =default!; //nav
}