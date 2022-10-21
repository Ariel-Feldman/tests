using System.Threading.Tasks;
using Ariel.Systems;
using UnityEngine;

namespace Ariel.MVCF
{
    public class TournamentsTabController : BaseController
    {
        private TournamentsTabView _view;

        protected override void BindViews()
        {
            _view = BindView<TournamentsTabView>();
        }

        public override void Init()
        {
            LoadTournament();
        }

        private async Task LoadTournament()
        {
            Debug.Log("Showing Tournaments");
            UiBlockerSystem.Instance.ShowFullScreenLoadingCircle();
            
            var tournamentsFeature = Injector.GetInstance<TournamentsFeature>();
            var tournaments = await tournamentsFeature.LoadTournaments();
            
            UiBlockerSystem.Instance.HideFullScreenLoadingCircle();
            
            foreach (var tournament in tournaments)
            {
                TournamentsTabController tournamentsTabController = Injector.GetInstance<TournamentsTabController>();
                // var TournamentView = ViewResolver.GetView<TournamentView>();
            }
        }
    }
}
