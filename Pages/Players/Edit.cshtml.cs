using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using finalproject3312.Models;

namespace finalproject3312.Pages_Players
{
    public class EditModel : PageModel
    {
        private readonly finalproject3312.Models.AppDbContext _context;

        public EditModel(finalproject3312.Models.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Player Player { get; set; } = default!;

        public List<Character> Characters {get;set;} = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player =  await _context.Players.Include(p=>p.PlayerCharacters!).ThenInclude(pc=>pc.Character).FirstOrDefaultAsync(m => m.PlayerID == id);
            Characters = _context.Characters.ToList();
            if (player == null)
            {
                return NotFound();
            }
            Player = player;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int[] selectedCharacters)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var playerToUpdate = await _context.Players.Include(p=>p.PlayerCharacters!).ThenInclude(pc=>pc.Character).FirstOrDefaultAsync(m => m.PlayerID == id);
            if(playerToUpdate != null)
            {
                playerToUpdate.Username = Player.Username;
                UpdatePlayerCharacters(selectedCharacters, playerToUpdate);
            }
            //_context.Attach(Player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(Player.PlayerID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PlayerExists(int id)
        {
            return _context.Players.Any(e => e.PlayerID == id);
        }

        private void UpdatePlayerCharacters(int[] selectedCharacters, Player playerToUpdate)
        {
            if(selectedCharacters == null)
            {
                playerToUpdate.PlayerCharacters = new List<PlayerCharacter>();
                return;
            }

            List<int> currentCharacters = playerToUpdate.PlayerCharacters!.Select(c=>c.CharacterID).ToList();
            List<int> selectedCharactersList = selectedCharacters.ToList();

            foreach(var character in _context.Characters)
            {
                if(selectedCharactersList.Contains(character.CharacterID))
                {
                    if(!currentCharacters.Contains(character.CharacterID))
                    {
                        playerToUpdate.PlayerCharacters!.Add(
                            new PlayerCharacter {PlayerID = playerToUpdate.PlayerID, CharacterID = character.CharacterID}
                        );
                    }
                }
                else
                {
                    if(currentCharacters.Contains(character.CharacterID))
                    {
                        PlayerCharacter characterToRemove = playerToUpdate.PlayerCharacters!.SingleOrDefault(s=>s.CharacterID == character.CharacterID)!;
                        _context.Remove(characterToRemove);
                    }
                }
            }
        }
    }
}
