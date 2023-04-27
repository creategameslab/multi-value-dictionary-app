using App.Core.Contracts;
using System.ComponentModel;

namespace App.Core.Commands;

[Description("Help: outputs a list of all available commands.")]
public sealed class HelpCommand : CommandBase
{
    public HelpCommand() : base("Help") { }

    public override void Run(IMultiValueRepository repository, params string[] commandParams)
    {
        var commandsDesc = CommandBase.GetAllInstancesDesc();
       
        foreach (var command in commandsDesc)
        {
            Console.WriteLine(command);
        }
    }
}
