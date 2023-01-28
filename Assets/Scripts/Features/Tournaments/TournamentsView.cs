using Ariel.Systems;
using UnityEngine;
using UnityEngine.UI;

namespace Ariel.Features
{
    public class TournamentsView : BaseView
    {
        [SerializeField] private Transform _tournamentsContainer;
        [SerializeField] private ScrollRect _tournamentsScrollRect;
        [SerializeField] private ScrollerPoolInfinity _scrollerPoolInfinity;

        public Transform TournamentsContainer => _tournamentsContainer;

        public void ShowLiveTournaments()
        {
            
        }
        
    }
}
