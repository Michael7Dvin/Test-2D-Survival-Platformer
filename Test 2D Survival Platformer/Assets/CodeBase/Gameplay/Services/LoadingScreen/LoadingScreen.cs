namespace CodeBase.Gameplay.Services.LoadingScreen
{
    public class LoadingScreen : ILoadingScreen
    {
        public void Initialize()
        {
            
        }

        public void Show()
        {
        }

        public void Hide()
        {
        }
    }

    public interface ILoadingScreen
    {
        void Initialize();
        void Show();
        void Hide();
    }
}