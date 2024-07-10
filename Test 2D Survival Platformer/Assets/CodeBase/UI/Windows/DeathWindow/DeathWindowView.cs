namespace CodeBase.UI.Windows.DeathWindow
{
    public class DeathWindowView : BaseWindowView
    {
        private DeathWindowPresenter _presenter; 
        
        public void Construct(DeathWindowPresenter presenter)
        {
            _presenter = presenter;
        }
        
        public void OnRestartClick() => 
            _presenter.Restart();
    }
}