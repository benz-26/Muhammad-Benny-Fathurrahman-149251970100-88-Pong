using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUPController : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    public float magnitude;
    private float timer;


    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison == ball)
        {
            //speed up the ball
            ball.GetComponent<BalController>().ActivatePUSpeedUp(magnitude);
            manager.RemovePowerUp(gameObject);
        }
        
        if (timer == 0.5)
        {
            //remove up the 
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
            Debug.Log("OK");
            manager.RemovePowerUp(gameObject);
        }
    }
}
