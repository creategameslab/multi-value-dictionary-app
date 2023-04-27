using App.Core.Contracts;
using System.ComponentModel;

namespace App.Core.Commands;

/// <summary>
/// Removes all members for a key and removes the key from the dictionary. Returns an error if the key does not exist.
/// </summary>
[Description("RemoveAll: remove all members for a given key.")]
public sealed class RemoveAllCommand : CommandBase
{
    public RemoveAllCommand() : base("RemoveAll") { }

    public override void Run(IMultiValueRepository repository, params string[] commandParams)
    {
        if (commandParams.Length > 0)
        {
            var key = commandParams[0];

            if (!string.IsNullOrWhiteSpace(key))
            {
                repository.RemoveAll(key);
                Console.WriteLine("Removed");
            }
        }
        else
        {
            Console.WriteLine("Error, invalid format -> ex: REMOVEALL keyname, REMOVEALL foo");
        }
    }
}
