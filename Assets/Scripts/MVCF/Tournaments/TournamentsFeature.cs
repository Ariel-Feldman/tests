using System.Collections.Generic;
using System.Threading.Tasks;
using Ariel.Services;
using Ariel.Systems;

namespace Ariel.MVCF
{
    public class TournamentsFeature : BaseFeature
    {
        private List<TournamentModel> _tournaments;
        
        public async Task<List<TournamentModel>> LoadTournaments()
        {
            var tournaments = HttpService.Get<TournamentResponse>("urlhere");
            
            await MonoSystem.Instance.AwaitFrames(10);
            return tournaments.Result.Tournaments;
        }
    }
}
