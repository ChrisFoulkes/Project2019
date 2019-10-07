using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    public Vector2 direction;
    public int facing = 1;


    Rigidbody2D rbody;
    Animator animator;
    //Controls the Character Movement Speed
    float movespeed = 2f;

    
  


    void Start()
    {
        direction = Vector2.zero;
        rbody = GetComponentInChildren<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        direction = Vector2.zero;

        // Directional controls 

        //Checks if the character is in a walking transitionable animation
        // potentially the animation integer changes should be in this if statement 
        // not the directional setting this would better allow for animation shifting and direction animation interuption.

        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Walking")) {
            SetDirection();
        }
    
        //Move Function Call
       

        
    }

    void FixedUpdate()
    {
        Move();
    }


    public Vector2 GetDirection() {
        return direction;
    }

    void SetDirection() {
       
        if (Input.GetKey(KeyCode.W))
        {
            direction.y += 1;

        }

        if (Input.GetKey(KeyCode.S))
        {
            direction.y -= 1;

        }

        if (Input.GetKey(KeyCode.A))
        {
            direction.x -= 1;

        }
        if (Input.GetKey(KeyCode.D))
        {
            direction.x += 1;

        }

        if (direction.y > 0)
        {
            animator.SetInteger("Walking", 1);
            facing = 1;
        }
        if (direction.y < 0)
        {
            animator.SetInteger("Walking", 4);
            facing = 4;
        }

        if (direction.x > 0 && (direction.y == 0))
        {
            animator.SetInteger("Walking", 3);
            facing = 3;
        }
        if ((direction.x < 0) && (direction.y == 0))
        {
            animator.SetInteger("Walking", 2);
            animator.SetInteger("Facing", 2);
            facing = 2;
        }


        if ((direction.y == 0) && (direction.x == 0))
        {
            animator.SetInteger("Walking", 0);
        }
    }
    void Move() {
        rbody.transform.Translate(direction * movespeed * Time.fixedDeltaTime);
    }

}
