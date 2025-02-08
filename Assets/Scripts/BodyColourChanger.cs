using UnityEngine;

public class BodyColourChanger : MonoBehaviour, ICommand
{
    [SerializeField] Material bodyMaterial;
    [SerializeField] Color initialColor;
    [SerializeField] Color newColour;

    private void Start()
    {
        Debug.Log("Name of body's material is: " + bodyMaterial);
    }
    public void Execute()
    {
        Debug.Log("Changing Body's colour to new colour");
        bodyMaterial.SetColor("_Color", newColour);
    }
    public void Undo()
    {
        Debug.Log("Resetting body's colour to initial colour");
        bodyMaterial.SetColor("_Color", initialColor);
    }
}
