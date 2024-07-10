using CodeBase.Gameplay.Character;
using CodeBase.Infrastructure.Services.CharacterProvider;
using CodeBase.Infrastructure.Services.StaticDataProvider;
using CodeBase.Infrastructure.StateMachine.States.Base;
using UnityEngine;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class RestartState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ICharacterProvider _characterProvider;
        private readonly Vector3 _characterSpawnPoint;

        public RestartState(IGameStateMachine gameStateMachine, ICharacterProvider characterProvider, IStaticDataProvider staticDataProvider)
        {
            _gameStateMachine = gameStateMachine;
            _characterProvider = characterProvider;
            _characterSpawnPoint = staticDataProvider.CharacterConfig.SpawnPoint;
        }

        public void Enter()
        {
            ICharacter character = _characterProvider.Get();
            
            character.Dieable.AbortDeath();
            character.Health.ResetToMaxHealth();
            
            character.GameObject.transform.position = _characterSpawnPoint;
            character.Mover.Enabled = true;
            
            _gameStateMachine.EnterState<GameplayState>();
        }

        public void Exit()
        {
        }
    }
}