using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] CommandInvoker commandInvoker;

    [SerializeField] Button changeBonnetColour;
    [SerializeField] Button changeBodyColour;
    [SerializeField] Button undoButton;

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
