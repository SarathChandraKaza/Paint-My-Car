using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] CommandInvoker commandInvoker;

    [SerializeField] Button changeBonnetColour;
    [SerializeField] Button changeBodyColour;
    [SerializeField] Button undoButton;

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
        ICommand command = new BodyColourChanger();
        commandInvoker.ExecuteCommand(command);
    }
    private void UpdateBonnetColour()
    {
        ICommand command = new BonnetColourChanger();
        commandInvoker.ExecuteCommand(command);
    }
}
