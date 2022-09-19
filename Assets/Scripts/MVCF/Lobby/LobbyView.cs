using System.Collections.Generic;
using UnityEngine;

namespace Ariel.MVCF
{
    public class LobbyView : BaseView
    {
        [SerializeField] private Transform _tournamentsContainer;
        [SerializeField] private TournamentView _tournamentView;
        public void ShowTournaments(List<TournamentModel> tournamentModels)
        {
            foreach (var tournament in tournamentModels)
            {
                Instantiate(_tournamentView, _tournamentsContainer);
            }
            Debug.Log("LoadingTournaments!!");
        }
    }
}
