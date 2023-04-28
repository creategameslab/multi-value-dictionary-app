using App.Core.Contracts;
using App.Core.Exceptions;
using System.ComponentModel;

namespace App.Core.Commands;

[Description("Add: adds a member to a collection for a given key.")]
public sealed class AddCommand : CommandBase
{
    public AddCommand() : base("Add") { }

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
                    repository.Add(key, value);
                    Console.WriteLine("Added");
                }
                else throw new InvalidParameterException("Error, invalid command parameters. Missing value.");
            }
            else throw new InvalidParameterException("Error, invalid command parameters. Missing key/value.");
        }
    }
}
