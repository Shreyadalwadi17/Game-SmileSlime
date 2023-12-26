using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public Collider[] regdollColiders;
    public Collider[] ragdollColiders;
    public Rigidbody[] ragdollRigidbodys;
    public Animator animator;
    public Vector3[] initialBonePositions;

    private void Start()
    {
        GetRegdoll();
        ModeOn();
       StoreInitialBonePositions();
    }
    private void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.enabled = false;
            ModeOff();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {

            ResetBonePositions();
            ModeOn();
            animator.enabled = true;
            animator.SetTrigger("StandUp");

        }
    }
    public void GetRegdoll()
    {
        regdollColiders = GetComponentsInChildren<Collider>();
        ragdollColiders = GetComponentsInChildren<Collider>();
        ragdollRigidbodys = GetComponentsInChildren<Rigidbody>();

    }
    public void ModeOn()
    {
        foreach (Rigidbody rb in ragdollRigidbodys)
        {
            rb.isKinematic = true;
           
        }
    }
    public void ModeOff()
    {
        foreach (Rigidbody rb in ragdollRigidbodys)
        {
            rb.isKinematic = false;
           
        }
    }


    private void StoreInitialBonePositions()
    {
        initialBonePositions = new Vector3[ragdollRigidbodys.Length];
        for (int i = 0; i < ragdollRigidbodys.Length; i++)
        {
            initialBonePositions[i] = ragdollRigidbodys[i].transform.localPosition;
        }
    }

    private void ResetBonePositions()
    {
        for (int i = 0; i < ragdollRigidbodys.Length; i++)
        {
            ragdollRigidbodys[i].transform.localPosition = initialBonePositions[i];

        }
    }

}