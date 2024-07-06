namespace CodeBase.Infrastructure.StateMachine.States
{
    public interface IStateWithArgument<in TArgs> : IExitableState
    {
        void Enter(TArgs args);
    }
}