using UnityEngine;

/// <summary>
/// Interface "ICommand"
/// This interface declares both Execute and Undo methods 
/// </summary>
public interface ICommand
{
    void Execute();
    void Undo();
}
