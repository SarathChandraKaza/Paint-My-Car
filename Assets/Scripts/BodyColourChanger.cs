using UnityEngine;

/// <summary>
/// Class "BodyColourChanger" which implements ICommand.
/// This class defines it's own functionality for the methods Execute and Undo.
/// Right now we are having only one functionality in Execute method for simplicity. 
/// It can be scaled up.
/// </summary>
public class BodyColourChanger : MonoBehaviour, ICommand
{
    [SerializeField] Material bodyMaterial;
    [SerializeField] Color initialColour;
    [SerializeField] Color newColour;
    public void Execute()
    {
        Debug.Log("Changing colour of body to new Colour");
        bodyMaterial.color = newColour;
    }
    public void Undo()
    {
        Debug.Log("Undoing colour of body to initial Colour");
        bodyMaterial.color = initialColour;
    }
}
