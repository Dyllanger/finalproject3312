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
        [BindProperty(SupportsGet = true)]
        public int PageNum {get;set;} = 1;
        public int PageSize {get;set;} = 7;
        public int TotalPages {get;set;}

        [BindProperty(SupportsGet = true)]
        public string CurrentSort {get;set;} = string.Empty;

        [BindProperty(SupportsGet = true)]
        public string CurrentSearch {get;set;} = string.Empty;

        public async Task OnGetAsync()
        {
            var query = _context.Players.Include(p=>p.PlayerCharacters!).ThenInclude(pc=>pc.Character).Select(p=>p);
            
            if (!string.IsNullOrEmpty(CurrentSearch))
            {
                query = query.Where(p=>p.Username.ToUpper().Contains(CurrentSearch.ToUpper()));
            }
            
            switch(CurrentSort)
            {
                case "first_asc":
                    query = query.OrderBy(p=>p.Username);
                    break;
                case "first_desc":
                    query = query.OrderByDescending(p=>p.Username);
                    break;
                case "date_asc":
                    query = query.OrderBy(p => p.RunDate);
                    break;
                case "date_desc":
                    query = query.OrderByDescending(p => p.RunDate);
                    break;
                case "killcount_asc":
                    query = query.OrderBy(p=>p.KillCount);
                    break;
                case "killcount_desc":
                    query = query.OrderByDescending(p=>p.KillCount);
                    break;
            }
            TotalPages = (int)Math.Ceiling(_context.Players.Count() / (double)PageSize);
            Player = await query.Skip((PageNum-1)*PageSize).Take(PageSize).ToListAsync();
        }
    }
}
