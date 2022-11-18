using System.Collections.Generic;
using System.Threading.Tasks;
using Ariel.Services;
using Ariel.Systems;

namespace Ariel.Models
{
    public class TournamentsFeature
    {
        private List<TournamentData> _tournaments;
        
        public async Task<List<TournamentData>> LoadTournaments()
        {
            var tournaments = HttpService.Get<TournamentResponse>("urlhere");
            
            return tournaments.Result.Tournaments;
        }
    }
}
