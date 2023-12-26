using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public Collider[] ragdollColiders;
    public Rigidbody[] ragdollRigidbodys;
    public Animator animator;
    public static Test inst;
    [SerializeField] private Ball ball;
    public Transform Tpose;
    public Vector3[] initialBonePositions;
    public IEnumerator delayCoroutine;

    private void Start()
    {
        delayCoroutine = DelayAnimation();
        inst = this;
        GetRagdoll();
        ModeOn();
        Tpose = transform.GetChild(0).GetComponent<Transform>();
        Debug.Log("name" + transform.GetChild(0).GetComponent<Transform>().name);
        //StoreInitialBonePositions();

    }

    public void GetRagdoll()
    {

        ragdollColiders = GetComponentsInChildren<Collider>();
        ragdollRigidbodys = GetComponentsInChildren<Rigidbody>();


    }
    public void ModeOn()
    {
        foreach (Rigidbody rb in ragdollRigidbodys)
        {
            rb.isKinematic = true;
        }
        //Tpose.localEulerAngles = new Vector3(Tpose.rotation.x, 180, 0);
    }
    public void ModeOff()
    {

        foreach (Rigidbody rb in ragdollRigidbodys)
        {
            rb.isKinematic = false;
            //rb.constraints = RigidbodyConstraints.FreezePositionZ;
        }

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
    public void StoreInitialBonePositions()
    {
        initialBonePositions = new Vector3[ragdollRigidbodys.Length];
        for (int i = 0; i < ragdollRigidbodys.Length; i++)
        {
            initialBonePositions[i] = ragdollRigidbodys[i].transform.localPosition;
        }
    }

    public void ResetBonePositions()
    {
        for (int i = 0; i < ragdollRigidbodys.Length; i++)
        {
            ragdollRigidbodys[i].transform.localPosition = initialBonePositions[i];

        }
    }

   


    public void StartDelay()
    {
        StartCoroutine(delayCoroutine);

    }

    public void StopDelay()
    {
        StopCoroutine(delayCoroutine);
    }

    public IEnumerator DelayAnimation()
    {
        yield return new WaitForSeconds(20f);
        ResetBonePositions();
        ModeOn();
        animator.enabled = true;
        animator.SetTrigger("StandUp");
        Debug.Log("Play StandUp Animation");

    }



}

