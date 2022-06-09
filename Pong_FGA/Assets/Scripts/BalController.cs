using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalController : MonoBehaviour
{
    //getcomponent rigibody
    private Rigidbody2D rig;
    //deklarasi vector2d untuk speed
    public Vector2 speed;
    // Start is called before the first frame update
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();  
        rig.velocity = speed;

    }

    // Update is called once per frame
    private void Update()
    {



    }
}
