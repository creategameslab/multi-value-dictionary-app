using App.Core.Contracts;
using System.ComponentModel;

namespace App.Core.Commands;

[Description("Exit: closes the application, or use ESC.")]
public sealed class ExitCommand : CommandBase
{
    public ExitCommand() : base("Exit") { }

    public override void Run(IMultiValueRepository repository, params string[] commandParams)
    {
        Environment.Exit(0);
    }
}
