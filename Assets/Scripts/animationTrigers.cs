using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationTrigers : MonoBehaviour
{
    // Start is called before the first frame update
    ThirdPersonController thirdPerson;

    private void Awake()
    {
        thirdPerson = GetComponentInParent<ThirdPersonController>();
    }

    public void callJump()
    {
        thirdPerson.PerformJump();
    }
    // Update is called once per frame

}
