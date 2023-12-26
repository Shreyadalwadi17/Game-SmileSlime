using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Transform character;
  
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            character.position= Vector3.right;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            character.position = Vector3.left;
        }
    }
}
