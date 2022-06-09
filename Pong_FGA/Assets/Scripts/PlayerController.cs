using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //getcomponent rigibody
    private Rigidbody2D rig;

    //deklarasi keycode biar bisa diganti
    public KeyCode upKey;
    public KeyCode downKey;

    //deklarasi vector2d untuk speed
    public int speed;

    // Start is called before the first frame update
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //getinput
        //move object
        MoveObject(GetInput());
    }

    private Vector2 GetInput()
    {

        //get input

        if (Input.GetKey(upKey))
        {
            // ke atas 
            return Vector2.up * speed;
        }
        if (Input.GetKey(downKey))
        {
            // ke bawah 
            return Vector3.down * speed;
        }

        return Vector2.zero;
    }
    private void MoveObject(Vector2 movement)
    {
        //MOVE OBJECT
        rig.velocity = movement;
    }
}
