using System;
using CodeBase.UI.Services.UIFactory;
using CodeBase.UI.Services.WindowService;
using CodeBase.UI.Windows;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UniRx;
using UnityEngine;

namespace CodeBase.Gameplay.Character.Death
{
    public class CharacterDeath : IDieable 
    {
        private readonly Subject<Unit> _died = new();
        private readonly GameObject _characterGameObject;
        private readonly IWindowService _windowService;

        private Tweener _shrinkTweener;

        public CharacterDeath(GameObject characterGameObject, IWindowService windowService)
        {
            _characterGameObject = characterGameObject;
            _windowService = windowService;
        }

        public IObservable<Unit> Died => _died;

        public void Initialize()
        {
            _shrinkTweener = _characterGameObject.transform
                .DOScale(new Vector3(0.5f, 0.5f), 2f)
                .SetAutoKill(false)
                .Pause();
        }

        public async UniTaskVoid Die()
        {
            float targetScaleX = Mathf.Sign(_characterGameObject.transform.localScale.x) * 0.5f;

            _shrinkTweener.ChangeEndValue(new Vector3(targetScaleX,0.5f)).Restart();
            await _shrinkTweener.AwaitForComplete();
            
            _died.OnNext(Unit.Default);
            
            _windowService.ShowWindow(WindowID.DeathWindow);
        }
    }
}