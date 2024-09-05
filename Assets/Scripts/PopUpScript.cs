using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            ThirdPersonController third = other.gameObject.GetComponent<ThirdPersonController>();

            third.isMove = false;
            third.FinishPopUp();
        }
        

    }
}
