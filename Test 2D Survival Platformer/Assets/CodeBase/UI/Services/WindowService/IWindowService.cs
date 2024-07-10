using CodeBase.UI.Windows;

namespace CodeBase.UI.Services.WindowService
{
    public interface IWindowService
    {
        void RegisterWindow(WindowID windowID, BaseWindowView window);
        void ShowWindow(WindowID windowID);
        void HideWindow(WindowID windowID);
    }
}