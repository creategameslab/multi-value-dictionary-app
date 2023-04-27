using App.Core.Contracts;
using System.ComponentModel;

namespace App.Core.Commands;

/// <summary>
/// Returns whether a key exists or not.
/// </summary>
[Description("KeyExists: returns whether a key exists or not.")]
public sealed class KeyExistsCommand : CommandBase
{
    public KeyExistsCommand() : base("KeyExists") { }

    public override void Run(IMultiValueRepository repository, params string[] commandParams)
    {
        if (commandParams.Length > 0)
        {
            var key = commandParams[0];

            if (!string.IsNullOrWhiteSpace(key))
            {
                var result = repository.Store().ContainsKey(key);
                Console.WriteLine(result.ToString().ToLowerInvariant());
            }
        }
        else
        {
            Console.WriteLine($"Error, invalid format -> ex: {Key} keyname, {Key} foo");
        }
    }
}
