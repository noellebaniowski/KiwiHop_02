using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{

    public Rigidbody2D rb2d;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // if(moveLeft == true){
       //     rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
       // }
       // else
       // {
       //    rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
       // }
        rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);

    }
}
