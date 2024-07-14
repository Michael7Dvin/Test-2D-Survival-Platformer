using UnityEngine;

namespace CodeBase.Infrastructure.Services.CameraProvider
{
    public interface ICameraProvider
    {
        void Set(Camera camera);
        Camera Get();
    }
}