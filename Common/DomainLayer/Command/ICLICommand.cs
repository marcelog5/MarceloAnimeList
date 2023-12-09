namespace Common.DomainLayer.Command
{
    public interface ICLICommand
    {
        void Execute(string[] args);
    }
}
