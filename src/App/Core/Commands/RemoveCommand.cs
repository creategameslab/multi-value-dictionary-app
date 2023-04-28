using App.Core.Contracts;
using App.Core.Exceptions;
using System.ComponentModel;

namespace App.Core.Commands;

/// <summary>
/// Removes a member from a key. If the last member is removed from the key, the key is removed from the dictionary. If the key or member does not exist, displays an error.
/// </summary>
[Description("Remove: removes a member from a key.")]
public sealed class RemoveCommand : CommandBase
{
    public RemoveCommand() : base("Remove") { }

    public override void Run(IMultiValueRepository repository, params string[] commandParams)
    {
        if (commandParams?.Length > 1)
        {
            var key = commandParams[0];
            var value = commandParams[1];

            if (!string.IsNullOrWhiteSpace(key))
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    if (repository.Remove(key, value))
                        Console.WriteLine("Removed");
                    else
                        Console.WriteLine("ERROR, member does not exist");
                }
            }
        }
        else throw new InvalidParameterException($"Error, invalid command parameters. Missing key/value.");
    }
}
