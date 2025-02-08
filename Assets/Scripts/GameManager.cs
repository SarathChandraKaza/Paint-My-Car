using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// GameManager is the player script which takes input from the buttons 
/// and then calls respective functions in Command Invoker.
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField] CommandInvoker commandInvoker;

    [SerializeField] Button changeBonnetColour;
    [SerializeField] Button changeBodyColour;
    [SerializeField] Button undoButton;

    /// <summary>
    /// Right now we are directly referencing BodyColourChanger and BonnetColourChanger in GameManager. 
    /// Everytime we need to add another ICommand member, we need to modify GameManager class. 
    /// This is not the right way. One way is to use Factory Design Pattern to abstractly get reference 
    /// to all the ICommand members and the Factory Class deals with low level details and references 
    /// of the ICommand members like their respective Materials, colours
    /// </summary>
    [Header("References to the ICommand Classes")]
    [SerializeField] BodyColourChanger bodyChanger;
    [SerializeField] BonnetColourChanger bonnetChanger;

    private void Start()
    {
        changeBonnetColour.onClick.AddListener(UpdateBonnetColour);
        changeBodyColour.onClick.AddListener(UpdateBodyColour);
        undoButton.onClick.AddListener(UndoButtonPressed);
    }

    private void UndoButtonPressed()
    {
        commandInvoker.UndoCommand();
    }
    private void UpdateBodyColour()
    {
        commandInvoker.ExecuteCommand(bodyChanger);
    }
    private void UpdateBonnetColour()
    {
        commandInvoker.ExecuteCommand(bonnetChanger);
    }
}
