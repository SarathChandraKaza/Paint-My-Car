using UnityEngine;
/// <summary>
/// Class "BonnetColourChanger" which implements ICommand.
/// This class defines it's own functionality for the methods Execute and Undo.
/// Right now we are having only one functionality in Execute method for simplicity. 
/// It can be scaled up.
/// </summary>
public class BonnetColourChanger : MonoBehaviour, ICommand
{
    [SerializeField] Material bonnetMaterial;
    [SerializeField] Color initialColour;
    [SerializeField] Color newColour;
    public void Execute()
    {
        Debug.Log("Changing bonnet's colour to new Colour");
        bonnetMaterial.color = newColour;
    }
    public void Undo()
    {
        Debug.Log("Undoing bonnet's colour to initial Colour");
        bonnetMaterial.color = initialColour;
    }
}
