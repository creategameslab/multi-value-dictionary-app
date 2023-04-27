﻿using App.Core.Contracts;
using System.ComponentModel;

namespace App.Core.Commands;

/// <summary>
/// Returns whether a member exists within a key. Returns false if the key does not exist.
/// </summary>
[Description("MemberExists: verify a member exists within a key.")]
public sealed class MemberExistsCommand : CommandBase
{
    public MemberExistsCommand() : base("MemberExists") { }

    public override void Run(IMultiValueRepository repository, params string[] commandParams)
    {
        if (commandParams.Length > 1)
        {
            var key = commandParams[0];
            var value = commandParams[1];

            if (!string.IsNullOrWhiteSpace(key))
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    var result = repository.DoesSetContainsValue(key, value);
                    Console.WriteLine(result.ToString().ToLowerInvariant());
                }
            }
        }
        else
        {
            Console.WriteLine($"Error, invalid format -> ex: {Key} keyname valuename, {Key} foo bar");
        }
    }
}
