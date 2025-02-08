using UnityEngine;

public class PlatformRotator : MonoBehaviour
{
    [SerializeField] private GameObject platformRotatorObject;
    [SerializeField] private float speed = 1.0f;
    void Update()
    {
        platformRotatorObject.transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
