using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using LegionTDServerReborn.Models;
using LegionTDServerReborn.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LegionTDServerReborn.Pages
{
    public class MatchModel : PageModel
    {
        public int MatchId {get; set;}

        public Match Match {get; set;}

        public Dictionary<long, Player> Players {get; set;}

        private LegionTdContext _db;

        public MatchModel(LegionTdContext db) {
                _db = db;
        }

        public async Task OnGetAsync(int matchId)
        {
            MatchId = matchId;
            Match = await _db.Matches.IgnoreQueryFilters()
                .Include(m => m.Duels)
                .Include(m => m.PlayerData)
                .ThenInclude(p => p.Player)
                .SingleOrDefaultAsync(m => m.MatchId == matchId);
        }

    }
}
