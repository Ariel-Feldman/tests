using System.Threading.Tasks;
using Ariel.Systems;
using UnityEngine;

namespace Ariel.MVCF
{
    public class TournamentsController : BaseController
    {
        public async Task ShowTournaments()
        {
            Debug.Log("Showing Tournaments");
            
            UiBlockerSystem.Instance.ShowFullScreenLoadingCircle();
            var tournamentsFeature = Resolver.GetFeature<TournamentsFeature>();
            var tournaments = await tournamentsFeature.LoadTournaments();
            UiBlockerSystem.Instance.HideFullScreenLoadingCircle();
            
            foreach (var tournament in tournaments)
            {
                TournamentsController tournamentsController = Resolver.GetController<TournamentsController>();
                var TournamentView = ViewResolver.GetView<TournamentView>();
            }
        }
    }
}