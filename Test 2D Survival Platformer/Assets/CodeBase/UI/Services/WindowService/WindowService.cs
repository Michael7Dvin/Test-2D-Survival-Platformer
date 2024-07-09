using System.Collections.Generic;
using CodeBase.UI.Windows;
using UnityEngine;

namespace CodeBase.UI.Services.WindowService
{
    public class WindowService : IWindowService
    {
        private readonly Dictionary<WindowID, BaseWindowView> _windows = new();

        public void RegisterWindow(WindowID windowID, BaseWindowView window)
        {
            if (_windows.ContainsKey(windowID) == true)
            {
                Debug.LogError($"Unable to register window. Window with ID: '{windowID}' is already registered.");
                return;
            }
            
            _windows.Add(windowID, window);
        }

        public void ShowWindow(WindowID windowID)
        {
            if (_windows.ContainsKey(windowID) == false)
            {
                Debug.LogError($"Unable to show window. No window registered with ID: '{windowID}'.");
                return;
            }
            
            _windows[windowID].Show();
        }

        public void HideWindow(WindowID windowID)
        {
            if (_windows.ContainsKey(windowID) == false)
            {
                Debug.LogError($"Unable to hide window. No window registered with ID: '{windowID}'.");
                return;
            }
            
            _windows[windowID].Hide();
        }
    }
}