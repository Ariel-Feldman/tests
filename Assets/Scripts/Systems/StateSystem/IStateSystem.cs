using System.Threading.Tasks;

namespace Systems.StateSystem
{
    public interface IStateSystem<EnumType>
    {
        public Task MoveToState(EnumType toState);
    }
}