using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUTurboUpController : MonoBehaviour
{
    public PowerUpManager manager;

    private float timer;
    public Collider2D bola;
    [SerializeField] Collider2D paddleKiri;
    [SerializeField] Collider2D padlleKanan;
    public BalController touch;


    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison == bola)
        {
            
            if (touch.isLeft && !manager.activationSpeedUpPaddleLeft)
            {
                manager.activationSpeedUpPaddleLeft = true;
                manager.PaddleKiri.GetComponent<PlayerController>().SpeedUpPad();
                manager.RemovePowerUp(gameObject);
                Debug.Log("kena kiri");
            }
            if (!touch.isLeft && !manager.activationSpeedUpPaddleRight)
            {
                manager.activationSpeedUpPaddleRight = true;
                manager.PaddleKanan.GetComponent<PlayerController>().SpeedUpPad();
                manager.RemovePowerUp(gameObject);
                Debug.Log("kena kanan");
            }
        }
    }

        // Start is called before the first frame update


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

