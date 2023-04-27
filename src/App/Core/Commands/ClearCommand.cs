using App.Core.Contracts;
using System.ComponentModel;

namespace App.Core.Commands;

/// <summary>
/// Removes all keys and all members from the dictionary.
/// </summary>
[Description("Clear: removes all keys and all members.")]
public sealed class ClearCommand : CommandBase
{
    public ClearCommand() : base("Clear") { }

    public override void Run(IMultiValueRepository repository, params string[] commandParams)
    {
        repository.ClearAll();
    }
}
