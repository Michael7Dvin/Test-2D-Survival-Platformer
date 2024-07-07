using System;
using UniRx;

namespace CodeBase.Gameplay.Character.Healths
{
    public class Death : IDieable 
    {
        private readonly Subject<Unit> _died;

        public IObservable<Unit> Died => _died;
        
        public void Die()
        {
            _died.OnNext(Unit.Default);
        }
    }
}