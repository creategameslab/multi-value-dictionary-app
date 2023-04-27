using App.Core.Contracts;
using System.ComponentModel;

namespace App.Core.Commands;

/// <summary>
/// Adds dummy data for testing
/// </summary>
[Description("Seed: adds dummy data for testing.")]
public sealed class SeedCommand : CommandBase
{
    public SeedCommand() : base("Seed") { }

    public override void Run(IMultiValueRepository repository, params string[] commandParams)
    {
        repository.ClearAll();
        repository.Add("foo", new HashSet<string> { "bar", "park", "spark" });
        repository.Add("baz", new HashSet<string> { "bang", "tank" });
    }
}
