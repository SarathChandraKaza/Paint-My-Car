using UnityEngine;

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
