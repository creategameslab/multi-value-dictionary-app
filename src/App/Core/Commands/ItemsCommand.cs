using App.Core.Contracts;
using System.ComponentModel;

namespace App.Core.Commands;

/// <summary>
/// Returns all keys in the dictionary and all of their members. Returns nothing if there are none. Order is not guaranteed.
/// </summary>
[Description("Items: returns all keys and all of their members.")]
public sealed class ItemsCommand : CommandBase
{
    public ItemsCommand() : base("Items") { }

    public override void Run(IMultiValueRepository repository, params string[] commandParams)
    {
        if (repository.Store().Count() > 0)
        {
            foreach (KeyValuePair<string, HashSet<string>> pair in repository.Store())
            {
                foreach (var item in pair.Value)
                    Console.WriteLine($"{pair.Key}: {item}");
            }
        }
        else
        {
            Console.WriteLine("(empty set)");
        }
    }
}