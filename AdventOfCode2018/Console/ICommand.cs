namespace AdventOfCode2018.Console
{
    public interface ICommand
    {
        void Execute();

        bool HadErrorInCreation();
    }
}