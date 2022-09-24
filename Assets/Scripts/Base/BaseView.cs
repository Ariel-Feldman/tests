using System.Threading.Tasks;

namespace Ariel.MVCF
{
    public class BaseView
    {
        public async Task TransitionOut()
        {
            await Task.Delay(100);
        }
    }
}
