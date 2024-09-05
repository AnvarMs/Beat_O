
using UnityEngine;

public class AddChildren : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        // Set the parent of the other object's transform to this object's transform
        other.transform.SetParent(transform);
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }

}
