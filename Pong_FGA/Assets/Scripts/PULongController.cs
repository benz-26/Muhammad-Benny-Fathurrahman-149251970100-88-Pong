using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PULongController : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D bola;
    public BalController touch;
    float timer;


    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison == bola)
        {
           
            if (touch.isLeft && !manager.activationScaleUpPaddleLeft)
            {
                manager.activationScaleUpPaddleLeft = true;
                manager.PaddleKiri.GetComponent<PlayerController>().ScaleUp(manager.PaddleKiri);
                manager.RemovePowerUp(gameObject);
            }
            if (!touch.isLeft && !manager.activationScaleUpPaddleRight)
            {
                manager.activationScaleUpPaddleRight = true;
                manager.PaddleKanan.GetComponent<PlayerController>().ScaleUp(manager.PaddleKanan);
                manager.RemovePowerUp(gameObject);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > manager.DeleteInterval)
        {
            manager.RemovePowerUp(gameObject);
        }
    }
}
