using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace finalproject3312.Models;

public class Player
{
    public int PlayerID {get;set;} //pk
    [Display(Name="Username")]
    public string Username {get;set;} = string.Empty;
    //[Display(Name="Favorite Character")] //dropdown list for this maybe?
    //public string Favorite {get;set;} = string.Empty;
    [Display(Name="Kill Count")]
    public int KillCount {get;set;}
    [Display(Name="Run Date")]
    [DataType(DataType.Date)]
    public DateTime RunDate {get;set;}
    [Display(Name="Characters Used In Run")]
    public List<PlayerCharacter> PlayerCharacters {get;set;} = default!;
}
