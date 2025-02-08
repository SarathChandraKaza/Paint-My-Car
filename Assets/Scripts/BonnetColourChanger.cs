using UnityEngine;

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
        bonnetMaterial.color =  initialColour;
    }
}
