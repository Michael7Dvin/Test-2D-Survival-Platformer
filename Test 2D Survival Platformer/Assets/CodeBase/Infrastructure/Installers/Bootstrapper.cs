using CodeBase.Infrastructure.StateMachine;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    public class Bootstrapper : IInitializable
    {
        private readonly IGameStateMachine _stateMachine;
        
        public void Initialize()
        {
            
        }
    }
}