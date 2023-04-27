namespace CommandPattern.Interfaces
{
    public interface IReceiver<in T, out O>
        where T : ICommand
        where O : IState
    {
        public IState Action(T command);
    }
}