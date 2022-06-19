using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public int speed = 20, startingSpeed;
    public KeyCode upKey;
    public KeyCode downKey;
    private Rigidbody2D rig;
    public Collider2D ball;
    private int twoSpeed;
    private int boostTime = 5;
    float timer;


    private void Start()
    {
        startingSpeed = speed;
        twoSpeed = speed * 2;
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MoveObject(GetInput());
    }

    private Vector2 GetInput()
    {
        if (Input.GetKey(upKey))
        {
            return Vector2.up * speed;
        }
        else if (Input.GetKey(downKey))
        {
            return Vector2.down * speed;
        }

        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement)
    {
        /* Debug.Log("TEST: " + movement);*/
        rig.velocity = movement;
    }

    public void boostSpeed()
    {
        StartCoroutine(wait());
    }

    public void upSize()
    {
        StartCoroutine(sizeUpgrade());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == ball)
        {
            AudioManager.instance.PlaySFX(0);
        }

    }
    private IEnumerator sizeUpgrade()
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 2, transform.localScale.z);
        Debug.Log("Sizing..");
        yield return new WaitForSeconds(boostTime);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 2, transform.localScale.z);
        Debug.Log("Sizing ended....");
        
    }
    private IEnumerator wait()
    {
        speed = twoSpeed;
        Debug.Log("Boosting..");
        yield return new WaitForSeconds(boostTime);
        speed = startingSpeed;
        Debug.Log("Boost ended....");
        
    }
}
