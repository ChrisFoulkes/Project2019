using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector2 direction;
    public float movespeed = 2f; 

    Rigidbody2D rbody; 
    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.zero;
        rbody = GetComponentInChildren<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = Vector2.zero;
        SetDirection();
    }

    private void FixedUpdate()
    {
        rbody.velocity = new Vector2(0, 0);

        Move();
    }
    public Vector2 GetDirection()
    {
        // might need to impliment some form of directional to check if a direction is colliding so walking animations are cancelled if walking into a wall
        return direction;
    }
    void SetDirection()
    {

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
    }


    void Move()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y) + (direction * movespeed * Time.fixedDeltaTime);
    }
}
