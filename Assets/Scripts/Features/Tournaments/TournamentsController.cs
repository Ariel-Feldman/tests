using System.Collections.Generic;
using Ariel.Services;
using Ariel.Systems;
using UnityEngine;
using UnityEngine.Pool;

namespace Ariel.Features
{
    public class TournamentsController : BaseController
    {
        private TournamentsView TournamentsView => GetView<TournamentsView>();
        

        public override void Init()
        {
            LoadTournaments();
        }

        private async void LoadTournaments()
        {
            Debug.Log("Showing Tournaments");
            UiBlockerSystem.Instance.ShowFullScreenLoadingCircle();
            
            // show loading screen?

            TournamentRequest tournamentRequest = new TournamentRequest();
            TournamentResponse tournamentsResponse = await HttpService.Get<TournamentResponse>(tournamentRequest.Url);
            UiBlockerSystem.Instance.HideFullScreenLoadingCircle();

            CreateTournamentsPooledData(tournamentsResponse.Tournaments);

            // var tournamentsPool = new ObjectPool<TournamentsData>();m,nk
            
            

            // foreach (LiveTournamentData tournamentData in tournamentsResponse.Tournaments)
            // {
            //     TournamentEntryView TournamentEntryView = 
            //         InstantiateView<TournamentEntryView>(TournamentsView.TournamentsContainer);
            //
            //     TournamentEntryView.SetViewUI(tournamentData);
            //     TournamentEntryView.SetJoinButtonAction(OnJoinButtonClicked);
            //     _liveTournamentsView.Add(TournamentEntryView);
            // }
        }

        private void CreateTournamentsPooledData(List<LiveTournamentData> tournamentsData)
        {
            
            // _liveTournamentsPool = 
            // ScrollerPoolInfinity 
        }

        private void OnJoinButtonClicked()
        {
            throw new System.NotImplementedException();
        }
    }
}
