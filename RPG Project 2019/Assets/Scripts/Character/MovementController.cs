using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    public Vector2 direction;

    Rigidbody2D rbody;
    Animator animator;
    //Controls the Character Movement Speed
    float movespeed = 3f;
  

  
    void Start()
    {
        direction = Vector2.zero;
        rbody = GetComponentInChildren<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {

        // Directional controls 

        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W)){
            direction.y += 1;
      
        }

        if (Input.GetKey(KeyCode.S)) {
            direction.y -= 1;
         
        }

        if (Input.GetKey(KeyCode.A)) {
            direction.x -= 1;

        }
        if (Input.GetKey(KeyCode.D)) {
            direction.x += 1;

        }

        if ((direction.y > 0) && (direction.x == 0)) {
            animator.SetInteger("Walking", 1);
        }
        if ((direction.y < 0) && (direction.x == 0))
        {
            animator.SetInteger("Walking", 4);
        }

        if (direction.x > 0)
        {
            animator.SetInteger("Walking", 3);
        }
        if (direction.x < 0)
        {
            animator.SetInteger("Walking", 2);
        }


        if ((direction.y == 0) && (direction.x == 0))
        {
            animator.SetInteger("Walking", 0);
        }
        //Move Function Call
        Move();

        
    }

    void Move() {
        rbody.transform.Translate(direction * movespeed * Time.deltaTime);
    }

}
