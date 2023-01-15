using System.Threading.Tasks;
using Ariel.Services;
using Ariel.Systems;
using UnityEngine;

namespace Ariel.Models
{
    public class TournamentsController : BaseController
    {
        private TournamentsView _tournamentsView => GetView<TournamentsView>();
        

        public override void Init()
        {
            LoadTournament();
        }

        private async Task LoadTournament()
        {
            Debug.Log("Showing Tournaments");
            UiBlockerSystem.Instance.ShowFullScreenLoadingCircle();
            
            // show loading screen?
            
            TournamentResponse tournamentsResponse = await HttpService.Get<TournamentResponse>("urlhere");
            UiBlockerSystem.Instance.HideFullScreenLoadingCircle();
            
            foreach (var tournament in tournamentsResponse.Tournaments)
            {
                TournamentsController tournamentsController = Injector.GetInstance<TournamentsController>();
                // var TournamentView = ViewResolver.GetView<TournamentView>();
            }
        }
    }
}
