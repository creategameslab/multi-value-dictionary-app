using App.Core.Commands;
using App.Core.Contracts;
using App.Core.Exceptions;
using System.Collections.Immutable;

namespace App.Core;

public sealed class ParserService
{
    private readonly Dictionary<string, CommandBase> _supportedCommands;
    private readonly IMultiValueRepository _repository;
    private readonly string Separator = new string(Enumerable.Range(0, Console.IsOutputRedirected ? 0 : Console.WindowWidth).Select(s => '-').ToArray());

    public ParserService(IMultiValueRepository repository)
    {
        var commands = CommandBase.GetAllInstances();

        _supportedCommands = new Dictionary<string, CommandBase>(commands.Count);
        _repository = repository;

        foreach (var command in commands)
        {
            _supportedCommands.Add(command.Key.ToLowerInvariant(), command);
        }
    }

    public void ProcessInput(ReadOnlySpan<char> input)
    {
        if (input.Length < 1) Console.WriteLine("Invalid command.");

        var commandIndex = input.IndexOf(' ');
        var hasParameters = commandIndex > -1;
        var commandKey = hasParameters ? input.Slice(0, commandIndex) : input;
        var lookupKey = new string(commandKey).ToLowerInvariant();
        
        if (_supportedCommands.ContainsKey(lookupKey))
        {
            var command = _supportedCommands[lookupKey];

            try
            {
                List<string> commandParameters = null;

                if (hasParameters && input.Length > commandIndex + 1)
                {
                    commandParameters = new string(input.Slice(commandIndex + 1, input.Length - (commandIndex + 1)))
                        .Split(' ')
                        .ToList();
                }

                command.Run(_repository, commandParameters?.ToArray());
            }
            catch (KeyNotFoundException) { Console.WriteLine("Error, key does not exist."); }
            catch (InvalidParameterException invalidEx) { Console.WriteLine(invalidEx.Message); }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            Console.WriteLine(Separator);
            
            return;
        }

        Console.WriteLine($"Error, unable to find command: {lookupKey}.");
    }
}
