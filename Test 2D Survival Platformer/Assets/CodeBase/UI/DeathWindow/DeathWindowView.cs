using UnityEngine;

namespace CodeBase.UI.DeathWindow
{
    public class DeathWindowView : MonoBehaviour
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