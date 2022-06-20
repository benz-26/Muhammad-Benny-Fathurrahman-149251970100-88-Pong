using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUPController : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    public float magnitude = 3f;
    private float timer;


    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison == ball && !manager.activationBallSpeed)
        {
            manager.activationBallSpeed = true;
            manager.ballMagnitude = magnitude;
            ball.GetComponent<BalController>().ActivationPUSpeedUp(magnitude);
            manager.RemovePowerUp(gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
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
