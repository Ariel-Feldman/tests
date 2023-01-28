using System.Threading.Tasks;

namespace Ariel.Utilities
{
    public interface IStateController<EnumType>
    {
        public Task MoveToState(EnumType toState);
    }
}