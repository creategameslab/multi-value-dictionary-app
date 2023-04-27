using App.Core.Contracts;
using System.ComponentModel;

namespace App.Core.Commands;

/// <summary>
/// Returns all the keys in the dictionary. Order is not guaranteed.
/// </summary>
[Description("Keys: lists all the keys.")]
public sealed class KeysCommand : CommandBase
{
    public KeysCommand() : base("Keys") { }

    public override void Run(IMultiValueRepository repository, params string[] commandParams)
    {
        foreach(var key in repository.GetAllKeys())
        {
            Console.WriteLine(key);
        }
    }
}
