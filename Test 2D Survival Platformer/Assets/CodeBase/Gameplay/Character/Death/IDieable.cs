using System;
using UniRx;

namespace CodeBase.Gameplay.Character.Death
{
    public interface IDieable
    {
        IObservable<Unit> Died { get; }
        void Die();
    }
}