using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{

    Animator animator;

    MovementController controller;

    private Vector2 currentDirection;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<MovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("Pickup", 0);

        if (Input.GetKeyDown(KeyCode.E))
        {
            currentDirection = controller.GetDirection();
            if ((currentDirection.x == 0 && currentDirection.y == 0) || (currentDirection.y == 1))
            {
                animator.SetInteger("Pickup", 1);
            }
            else if (currentDirection.y == -1) {
                animator.SetInteger("Pickup", 4);
            }
            else if (currentDirection.x == -1)
            {
                animator.SetInteger("Pickup", 2);
            }
            else if (currentDirection.x == 1)
            {
                animator.SetInteger("Pickup", 3);
            }




        }


    }

    private void FixedUpdate()
    {
        

    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 2);
    }
}
