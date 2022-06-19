using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Vector2 speed;
    private Rigidbody2D rig;
    public Vector2 resetPosition;
    [SerializeField]
    private PowerUpManager PU;
    [SerializeField]
    private PaddleController right, left;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = speed;
    }


    // Update is called once per frame
    void Update()
    {
    }

    public void ResetBall()
    {
        transform.position = new Vector3(resetPosition.x, resetPosition.y, this.transform.position.z);
        rig.velocity = speed;
        right.speed = right.startingSpeed;
        left.speed = left.startingSpeed;
        right.transform.localScale = new Vector3(transform.localScale.x, 3, transform.localScale.z);
        left.transform.localScale = new Vector3(transform.localScale.x, 3, transform.localScale.z);
    }

    public void ActivatePUSpeedUp(float magnitude)
    {
        rig.velocity *= magnitude;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("rightPaddle"))
        {
            PU.switchPaddle(true);
            /*Debug.Log("Hitting right..");*/
        }
        else
        {
            PU.switchPaddle(false);
            /*Debug.Log("Hitting left..");*/
        }
    }
}
