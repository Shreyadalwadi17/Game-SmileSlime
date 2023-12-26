//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.Threading.Tasks;

//public class Enemy : MonoBehaviour
//{

//    public Collider[] ragdollColiders;
//    public Rigidbody[] ragdollRigidbodys;
//    public Animator animator;
//    public Vector3[] initialBonePositions;

//    private void Start()
//    {

//        GetRegdoll();
//        ModeOn();
//        StoreInitialBonePositions();


//    }
//    public void GetRegdoll()
//    {

//        ragdollColiders = GetComponentsInChildren<Collider>();
//        ragdollRigidbodys = GetComponentsInChildren<Rigidbody>();

//    }

//    public void ModeOn()
//    {

//        foreach (Rigidbody rb in ragdollRigidbodys)
//        {
//            rb.isKinematic = true;
//        }
//        foreach (Collider cl in ragdollColiders)
//        {
//            cl.enabled = false;


//        }


//    }
//    public void ModeOff()
//    {

//        foreach (Rigidbody rb in ragdollRigidbodys)
//        {
//            rb.isKinematic = false;

//        }
//        foreach (Collider cl in ragdollColiders)
//        {
//            cl.enabled = true;


//        }

//    }
//    private void StoreInitialBonePositions()
//    {
//        initialBonePositions = new Vector3[ragdollRigidbodys.Length];
//        for (int i = 0; i < ragdollRigidbodys.Length; i++)
//        {
//            initialBonePositions[i] = ragdollRigidbodys[i].transform.localPosition;
//        }
//    }

//    private void ResetBonePositions()
//    {
//        for (int i = 0; i < ragdollRigidbodys.Length; i++)
//        {
//            ragdollRigidbodys[i].transform.localPosition = initialBonePositions[i];


//        }
//    }

//    private void Update()
//    {
//        if (Input.GetKey(KeyCode.LeftArrow))
//        {
//            animator.enabled = false;
//            ModeOff();

//        }
//        if (Input.GetKey(KeyCode.RightArrow))
//        {
//            ResetBonePositions();
//            ModeOn();
//            animator.enabled = true;
//            animator.SetTrigger("StandUp");


//        }
//    }

//}



//    //public void BulletMove()
//    //{
//    //    distance = Vector3.Distance(transform.position, player.position);
//    //    Debug.Log(distance);
//    //    if (isfollow)
//    //    {
//    //        if (distance <= Range && !bulletInstantiated)
//    //        {
//    //            ani.enabled = true;
//    //            ani.SetTrigger("Shoot");

//    //            Vector3 directionToPlayer = player.position;
//    //            transform.LookAt(directionToPlayer);


//    //            Rigidbody bulletInst = Instantiate(bullet, spawner.transform.position, Quaternion.identity);
//    //            Vector3 targetpos = player.transform.position - spawner.transform.position;
//    //            bulletInst.transform.LookAt(targetpos);
//    //            bulletInst.AddForce(targetpos * speed, ForceMode.Impulse);
//    //            bulletInstantiated = true;

//    //        }
//    //    }
//    //    if (distance < stopRange)
//    //    {
//    //        isfollow = false;

//    //    }
//    //    else
//    //    {
//    //        isfollow = true;
//    //    }

//    //}

//...................................Test

//public void. SetParent()
//{
//    child1.SetParent(parent, true);
//    child2.SetParent(parent, true);
//}

//public void UnParent()
//{
//    child1.SetParent(null, true);
//    child2.SetParent(null, true);
//}.
//...............................

//public void StoreInitialBonePositions()
//{

//    initialBonePositions = new Vector3[ragdollRigidbodys.Length];
//    for (int i = 0; i < ragdollRigidbodys.Length; i++)
//    {

//        initialBonePositions[i] = ragdollRigidbodys[i].transform.localPosition;
//        //initialBonePositions[i].z = 0;
//    }


//}

//public void ResetBonePositions()
//{

//    for (int i = 0; i < ragdollRigidbodys.Length; i++)
//    {
//        //Vector3 newPosition = initialBonePositions[i];
//        //newPosition.z = 0;
//        ragdollRigidbodys[i].transform.localPosition = initialBonePositions[i];

//    }

//}
//........................
     //public void MoveParent()
     //{

//    Vector3 newPosition = transform.position;
//    newPosition.y = storePos.transform.localPosition.y-1.5f;
//    transform.position = newPosition;

//}
