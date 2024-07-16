using Cysharp.Threading.Tasks;

namespace CodeBase.UI.Services.LoadingScreen
{
    public interface ILoadingScreen
    {
        UniTask Initialize();
        void Show();
        void Hide();
    }
}