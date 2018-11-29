using System.Configuration;

namespace AdventOfCode2018.Console.Commands
{
    public class VersionCommand : ICommand
    {
        public void Execute()
        {
            string versionNumber = ConfigurationManager.AppSettings["version"];
            System.Console.WriteLine($"AdventOfCode2018 version: {versionNumber}");
            System.Console.WriteLine("");
        }

        public bool HadErrorInCreation()
        {
            return false;
        }
    }
}