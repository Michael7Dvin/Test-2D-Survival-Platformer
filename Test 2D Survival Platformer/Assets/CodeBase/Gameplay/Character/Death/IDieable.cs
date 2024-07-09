using System;
using Cysharp.Threading.Tasks;
using UniRx;

namespace CodeBase.Gameplay.Character.Death
{
    public interface IDieable
    {
        IObservable<Unit> Died { get; }

        void Initialize();
        UniTaskVoid Die();
    }
}