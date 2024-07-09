using UnityEngine;

namespace CodeBase.UI.Windows
{
    public abstract class BaseWindowView : MonoBehaviour
    {
        public void Show() => 
            gameObject.SetActive(true);

        public void Hide() => 
            gameObject.SetActive(false);
    }
}