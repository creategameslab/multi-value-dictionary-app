using App.Core.Contracts;
using System.ComponentModel;

namespace App.Core.Commands;

/// <summary>
/// Returns the collection of strings for the given key. Return order is not guaranteed. Returns an error if the key does not exists.
/// </summary>
[Description("Members: all members for a given key.")]
public sealed class MembersCommand : CommandBase
{
    public MembersCommand() : base("Members") { }

    public override void Run(IMultiValueRepository repository, params string[] commandParams)
    {
        if (commandParams?.Length > 0 && !string.IsNullOrWhiteSpace(commandParams[0]))
        {
            var members = repository.Get(commandParams[0]);

            foreach (var member in members)
                Console.WriteLine(member);
        }
        else
        {
            Console.WriteLine("Error, invalid format -> ex: MEMBERS keyname, MEMBERS foo");
        }
    }
}
