using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPaddleSpeed : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D paddleRight,paddleLeft,ball;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == ball)
        {
            if (manager.GetComponent<PowerUpManager>().getPaddle() == true)
            {
                AudioManager.instance.PlaySFX(1);
                paddleRight.GetComponent<PaddleController>().boostSpeed();
                manager.RemovePowerUp(gameObject);
            }else if (manager.GetComponent<PowerUpManager>().getPaddle() == false)
            {
                AudioManager.instance.PlaySFX(1);
                paddleLeft.GetComponent<PaddleController>().boostSpeed();
                manager.RemovePowerUp(gameObject);
            }
        }
    }
}
