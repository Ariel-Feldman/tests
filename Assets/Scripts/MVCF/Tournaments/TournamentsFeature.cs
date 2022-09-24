using System.Collections.Generic;
using System.Threading.Tasks;
using Ariel.Services;
using Ariel.Systems;

namespace Ariel.MVCF
{
    public class TournamentsFeature
    {
        private List<TournamentModel> _tournaments;
        
        public async Task<List<TournamentModel>> LoadTournaments()
        {
            var httpService = Injector.GetInstance<HttpService>();
            var tournaments = httpService.Get<TournamentResponse>("urlhere");
            
            await MonoSystem.Instance.AwaitFrames(10);
            return tournaments.Result.Tournaments;
        }
    }
}
