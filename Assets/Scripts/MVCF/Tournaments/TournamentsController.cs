using System.Threading.Tasks;
using Ariel.Systems;
using UnityEngine;

namespace Ariel.MVCF
{
    public class TournamentsController : BaseController
    {
        private TournamentView _view;

        public override void BindViews()
        {
            _view = BindView<TournamentView>();
        }
        
        public async Task ShowTournaments()
        {
            Debug.Log("Showing Tournaments");
            
            UiBlockerSystem.Instance.ShowFullScreenLoadingCircle();
            var tournamentsFeature = Injector.GetInstance<TournamentsFeature>();
            var tournaments = await tournamentsFeature.LoadTournaments();
            UiBlockerSystem.Instance.HideFullScreenLoadingCircle();
            
            foreach (var tournament in tournaments)
            {
                TournamentsController tournamentsController = Injector.GetInstance<TournamentsController>();
                // var TournamentView = ViewResolver.GetView<TournamentView>();
            }
        }
    }
}
