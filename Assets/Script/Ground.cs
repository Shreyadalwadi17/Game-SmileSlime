using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("ground");
            Test.inst.StartDelay();
            Debug.Log("StartDelay");
        }

    }


}
