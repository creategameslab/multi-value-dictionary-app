using App.Core.Contracts;
using System.ComponentModel;

namespace App.Core.Commands;

[Description("AllMembers: Returns all the members in the dictionary.")]
public sealed class AllMembersCommand : CommandBase
{
    public AllMembersCommand() : base("AllMembers") { }

    public override void Run(IMultiValueRepository repository, params string[] commandParams)
    {
        if (repository.Store().Count() > 0)
        {
            foreach(KeyValuePair<string, HashSet<string>> pair in repository.Store())
            {
                var output = string.Join(Environment.NewLine, pair.Value);
                Console.WriteLine(output);
            }    
        }
        else
        {
            Console.WriteLine("(empty set)");
        }
    }
}
