using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationg : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 rotateDirection;
    public float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed* rotateDirection.y*Time.deltaTime, 0);

        transform.Rotate(rotationSpeed * rotateDirection.x * Time.deltaTime, 0, 0);

        transform.Rotate(0, 0, rotationSpeed * rotateDirection.z * Time.deltaTime);
    }
}
