using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ariel.Features
{
    public class TournamentEntryView : BaseView
    {
        [SerializeField] private TMP_Text _tournamentHeader;
        [SerializeField] private TMP_Text _tournamentName;
        [SerializeField] private TMP_Text _playersCount;
        [SerializeField] private TMP_Text _entryFee;
        [SerializeField] private TMP_Text _rewards;
        
        
        [SerializeField] private Button _joinButton;
        
        public void SetViewUI(LiveTournamentData liveTournamentData)
        {
            _tournamentHeader.text = liveTournamentData.TournamentHeader;
            _tournamentName.text = liveTournamentData.TournamentName;
            _playersCount.text = liveTournamentData.PlayersCount.ToString();
            _entryFee.text = liveTournamentData.EntryFee.ToString();
        }
        
        public void SetJoinButtonAction(UnityAction OnJoinButtonClicked)
        {
            _joinButton.onClick.AddListener(OnJoinButtonClicked);
        }
    }
}