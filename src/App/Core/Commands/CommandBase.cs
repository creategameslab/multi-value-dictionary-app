using App.Core.Contracts;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Reflection;

namespace App.Core.Commands;

/// <summary>
/// Command template for storing subcribers and providing validation.
/// </summary>
public abstract class CommandBase
{
    public string Key { get; private set; }

    public CommandBase(string key)
    {
        ArgumentException.ThrowIfNullOrEmpty(key, nameof(key));

        Key = key;
    }

    public virtual bool IsCommand(ReadOnlySpan<char> command)
    {
        if (Key.AsSpan().Equals(command, StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }

        return false;
    }

    public virtual bool IsCommand(string command)
    {
        return IsCommand(command.AsSpan());
    }

    public abstract void Run(IMultiValueRepository repository, params string[] commandParams);

    public static IImmutableList<CommandBase> GetAllInstances()
    {
        return typeof(CommandBase).Assembly.GetTypes()
            .Where(t => t.IsSubclassOf(typeof(CommandBase)) && !t.IsAbstract)
            .Select(t => (CommandBase)Activator.CreateInstance(t)).ToImmutableList();
    }

    public static IImmutableList<string> GetAllInstancesDesc()
    {
        return typeof(CommandBase).Assembly.GetTypes()
            .Where(t => t.IsSubclassOf(typeof(CommandBase)) && !t.IsAbstract && t.GetCustomAttribute<DescriptionAttribute>() != null)
            .Select(t => t.GetCustomAttribute<DescriptionAttribute>().Description).ToImmutableList();
    }
}
