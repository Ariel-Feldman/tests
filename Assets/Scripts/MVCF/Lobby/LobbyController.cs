using System.Threading.Tasks;
using Ariel.Systems;
using UnityEngine;

namespace Ariel.MVCF
{
    public class LobbyController : BaseController
    {
        private LobbyView _view;
        private TournamentsController _tournamentsController;
        
        public async void BindView()
        {
            Debug.Log("Lobby Controller View Bind");
            _view = ViewSystem.GetView<LobbyView>();
            await Task.Delay(10000);

            // _tournamentsController = Resolver.GetController<TournamentsController>();
            // await _tournamentsController.ShowTournaments();
        }
    }
}
