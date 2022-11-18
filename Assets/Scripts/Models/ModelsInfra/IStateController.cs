using System.Threading.Tasks;

namespace Systems.Models
{
    public interface IStateController<EnumType>
    {
        public Task MoveToState(EnumType toState);
    }
}