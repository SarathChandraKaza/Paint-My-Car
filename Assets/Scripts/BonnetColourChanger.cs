using UnityEngine;

public class BonnetColourChanger : MonoBehaviour, ICommand
{
    [SerializeField] Material bonnetMaterial;
    [SerializeField] Color initialColor;
    [SerializeField] Color newColour;

    private void Start()
    {
        Debug.Log("Name of bonnet's material is: " + bonnetMaterial);
    }
    public void Execute()
    {
        Debug.Log("Changing bonnet's colour to new colour");
        bonnetMaterial.SetColor("_Color", newColour);
    }
    public void Undo()
    {
        Debug.Log("Resetting bonnet's colour to initial colour");
        bonnetMaterial.SetColor("_Color", initialColor);
    }
}
