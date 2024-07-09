using System;
using UniRx;
using Object = UnityEngine.Object;

namespace CodeBase.Gameplay.Character.Death
{
    public class CharacterDeath : IDieable 
    {
        private readonly Subject<Unit> _died = new();
        private readonly Object _dyingEntityGameObject;

        public CharacterDeath(Object dyingEntityGameObject)
        {
            _dyingEntityGameObject = dyingEntityGameObject;
        }

        public IObservable<Unit> Died => _died;
        
        public void Die()
        {
            _died.OnNext(Unit.Default);
        }
    }
}