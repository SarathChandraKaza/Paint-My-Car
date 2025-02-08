using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

/// <summary>
/// "CommandInvoker" class acts as the logic part. This class contains the stack which 
/// stores all the commands. And the functionality involving Execute and Undo of any 
/// individual ICommand members is called from here.
/// </summary>
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
