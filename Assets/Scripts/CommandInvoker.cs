using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    private Stack<ICommand> commandsStack = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        commandsStack.Push(command);
    }
    public void UndoCommand()
    {
        var lastCommand = commandsStack.Pop();
        lastCommand.Undo();
    }
}
