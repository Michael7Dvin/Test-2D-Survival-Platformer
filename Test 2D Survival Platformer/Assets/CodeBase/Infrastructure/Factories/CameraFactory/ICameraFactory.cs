using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Infrastructure.Factories.CameraFactory
{
    public interface ICameraFactory
    {
        UniTask WarmUp();
        UniTask Create(Transform followPoint);
    }
}