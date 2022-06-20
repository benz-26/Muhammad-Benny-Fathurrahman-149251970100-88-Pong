using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalController : MonoBehaviour
{
    //getcomponent rigibody
    private Rigidbody2D rig;
    public Vector2 startSpeed;
    //deklarasi vector2d untuk speed
    public Vector2 speed;
    public Vector3 resetPosition;
    public bool isLeft = false;


    public void ActivationPUSpeedUp(float magnitude)
    {

        rig.velocity *= magnitude;
    }

    public void DeactivationPUSpeedUp(float magnitude)
    {
        rig.velocity /= magnitude;
    }

    // Start is called before the first frame update
    private void Start()
    {
        startSpeed.x = speed.x;
        rig = GetComponent<Rigidbody2D>();  
        rig.velocity = speed;

    }

    // Update is called once per frame
    public void ResetBall()
    {
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 2);
        if (rig.velocity.x < 0)
        {
            speed = startSpeed;
            rig.velocity = new Vector2(speed.x * -1, speed.y);
        }
        else if (rig.velocity.x > 0)
        {
            speed = startSpeed;
            rig.velocity = new Vector2(speed.x * 1, speed.y);
        }
    }


    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PaddleKiri")
        {
            isLeft = true;
        }
        else
        {
            isLeft = false;
        }
    }
}
