using UnityEngine;

namespace CodeBase.Infrastructure.Services.CameraProvider
{
    public class CameraProvider : ICameraProvider
    {
        private Camera _camera;
        
        public void Set(Camera camera) =>
            _camera = camera;

        public Camera Get()
        {
            if (_camera == null)
                Debug.LogError($"Unable to retrieve {nameof(_camera)}. {nameof(_camera)} is null");
            
            return _camera;
        }
    }
}