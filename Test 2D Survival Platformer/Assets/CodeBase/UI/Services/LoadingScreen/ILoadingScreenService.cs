
using Cysharp.Threading.Tasks;

namespace CodeBase.UI.Services.LoadingScreen
{
    public interface ILoadingScreenService
    {
        UniTask Initialize();
        void Show();
        UniTask Hide();
    }
}