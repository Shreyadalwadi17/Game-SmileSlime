using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Ball : MonoBehaviour
{

    private Rigidbody rb;
    private LineRenderer lr;
    private Vector3 mouseWorldPos;
    private Vector3 direction;
    private float maxArrowLength = 0.6f;
    public bool isDragging = false;
    public float force;
    public TimeController timeController;
    private Vector3 startPos;
    private Vector3 endPos;
    public ParticleSystem particle;
    public Score score;
    public Test test;
    public GameObject head;
    public GameObject headColider;
    private bool headCollisionOccurred = false;
    public GameObject ball;
    public Transform initialPosition;
  

    void Awake()
    {
       
        rb = GetComponent<Rigidbody>();
        lr = GetComponent<LineRenderer>();
      
    }
   
    private void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            CalculateThrow();
            startPos = mouseWorldPos;
        }


        if (isDragging && Input.GetMouseButton(0))
        {
            CalculateThrow();
            endPos = mouseWorldPos;
            direction = endPos - startPos;
            SetArrow();
            timeController.SlowTime();
        }


        if (Input.GetMouseButtonUp(0))
        {
            timeController.FastTime();
            RemoveArrow();
            Throw();
        }

    }
    public void ResetBallPosition()
    {
        ball.transform.position = new Vector3(0, 0, 0);
    }
    void CalculateThrow()
    {
        Vector3 screenPos = Input.mousePosition;
        screenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        mouseWorldPos = Camera.main.ScreenToWorldPoint(screenPos);
    }

    void SetArrow()
    {
        direction = Vector3.ClampMagnitude(direction, maxArrowLength);
        lr.positionCount = 2;
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, transform.position + direction);
        lr.enabled = true;
    }

    void RemoveArrow()
    {
        lr.enabled = false;
    }


    public void Throw()
    {
        float Strength = direction.magnitude / maxArrowLength;
        float Power = Strength * force;
        rb.velocity = direction.normalized * Power;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (headCollisionOccurred)
        //{
        //    return;
        //}

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Test.inst.StoreInitialBonePositions();
            Debug.Log("store pos");
            test.animator.enabled = false;
            test.ModeOff();
         
        }
        if (collision.gameObject.CompareTag("Head"))
        {
            Debug.Log("Head Collision");
            test.animator.enabled = false;

            Test.inst.StopDelay();

            Debug.Log("Stoppp");
            head.transform.GetComponent<SkinnedMeshRenderer>().enabled = false;
            headColider.transform.GetComponent<Collider>().enabled = false;
            headColider.transform.GetComponent<BoxCollider>().enabled = false;
            particle.transform.position= headColider.transform.position;
            particle.Play();
            particle.GetComponent<Renderer>().material.color = Color.red;

            //test.ModeOff();
            //score.ScoreIncrese();
            //headCollisionOccurred = true;

        }
        if (collision.gameObject.CompareTag("glass"))
        {
            Destroy(collision.gameObject);
            particle.Play();
            particle.GetComponent<Renderer>().material.color = Color.cyan;
        }
    }
   
}






