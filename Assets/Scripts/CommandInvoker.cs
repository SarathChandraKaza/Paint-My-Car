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
        if(commandsStack.Count > 0)
        {
            var lastCommand = commandsStack.Pop();
            lastCommand.Undo();
        }
        else
        {
            Debug.LogError("Stack is empty");
        }
    }
}
