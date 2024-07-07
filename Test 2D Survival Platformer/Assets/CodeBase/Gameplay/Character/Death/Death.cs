using System;
using UniRx;
using Object = UnityEngine.Object;

namespace CodeBase.Gameplay.Character.Death
{
    public class Death : IDieable 
    {
        private readonly Subject<Unit> _died = new();
        private readonly Object _dyingEntityGameObject;

        public Death(Object dyingEntityGameObject)
        {
            _dyingEntityGameObject = dyingEntityGameObject;
        }

        public IObservable<Unit> Died => _died;
        
        public void Die()
        {
            Object.Destroy(_dyingEntityGameObject);            
            _died.OnNext(Unit.Default);
        }
    }
}