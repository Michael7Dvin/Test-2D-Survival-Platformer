using System;
using UniRx;

namespace CodeBase.Gameplay.Character.Healths
{
    public interface IDieable
    {
        IObservable<Unit> Died { get; }
        void Die();
    }
}