using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using finalproject3312.Models;

namespace finalproject3312.Pages_Players
{
    public class IndexModel : PageModel
    {
        private readonly finalproject3312.Models.AppDbContext _context;

        public IndexModel(finalproject3312.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<Player> Player { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Player = await _context.Players.Include(p=>p.PlayerCharacters!).ThenInclude(pc=>pc.Character).ToListAsync();
        }
    }
}
