using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using finalproject3312.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace finalproject3312.Pages_Players
{
    public class DetailsModel : PageModel
    {
        private readonly finalproject3312.Models.AppDbContext _context;
        private readonly ILogger<DetailsModel> _logger;

        public DetailsModel(ILogger<DetailsModel> logger,finalproject3312.Models.AppDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public Player Player { get; set; } = default!;

        [BindProperty]
        [Display(Name = "Select Character")]
        [Required(ErrorMessage = "Invalid Selection")]
        public int CharacterIDToAdd {get;set;}
        public SelectList CharactersDropDown {get; set;} = default!;

        [BindProperty]
        public int CharacterIDToDelete {get;set;}

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.Players.Include(p=>p.PlayerCharacters!).ThenInclude(pc=>pc.Character).FirstOrDefaultAsync(m => m.PlayerID == id);

            if (player is not null)
            {
                Player = player;
                CharactersDropDown = new SelectList(_context.Characters.ToList(),"CharacterID","Description");
                return Page();
            }
            return NotFound();
        }

        public IActionResult OnPostAddCharacter(int? id)
        {
            _logger.LogWarning($"Add Character: PlayerID {id}, ADD character {CharacterIDToAdd}");

            if(id == null)
            {
                return NotFound();
            }

            var player = _context.Players.Include(p=>p.PlayerCharacters!).ThenInclude(pc=>pc.Character).FirstOrDefault(m => m.PlayerID == id);

            if(player == null)
            {
                return NotFound();
            }
            else
            {
                Player = player;
            }

            CharactersDropDown = new SelectList(_context.Characters.ToList(),"CharacterID","Description");

            if(!ModelState.IsValid)
            {
                _logger.LogWarning($"Model State is Invalid.");
                return Page();
            }

            if(!_context.PlayerCharacters.Any(pc=>pc.CharacterID == CharacterIDToAdd && pc.PlayerID == id))
            {
                PlayerCharacter characterToAdd = new PlayerCharacter {PlayerID = id.Value, CharacterID = CharacterIDToAdd};
                _context.Add(characterToAdd);
                _context.SaveChanges();
            } else {
                _logger.LogWarning("Character already recorded in run");
            }

            return Page();
        }

        public IActionResult OnPostDeleteCharacter(int? id)
        {
            _logger.LogWarning($"Delete Character: PlayerID {id}, DROP character {CharacterIDToDelete}");

            if(id == null)
            {
                return NotFound();
            }

            var player = _context.Players.Include(p=>p.PlayerCharacters!).ThenInclude(pc=>pc.Character).FirstOrDefault(m => m.PlayerID == id);

            if(player == null)
            {
                return NotFound();
            }
            else
            {
                Player = player;
            }
            CharactersDropDown = new SelectList(_context.Characters.ToList(),"CharacterID","Description");

            var characterToDrop = _context.PlayerCharacters.Find(CharacterIDToDelete, id);

            if(characterToDrop != null)
            {
                _context.Remove(characterToDrop);
                _context.SaveChanges();
            }
            else
            {
                _logger.LogWarning("Character NOT added to your run.");
            }
            return RedirectToPage(new {id = id});
        }
    }
}
