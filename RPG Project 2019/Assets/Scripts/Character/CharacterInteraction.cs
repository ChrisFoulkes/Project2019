using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    public LayerMask mask;

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

            RaycastHit2D[] interactables = Physics2D.CircleCastAll(this.transform.position, 2f, new Vector2(0f, 0f), Mathf.Infinity, mask);

            if (interactables.Length != 0)
            {
                GameObject target = interactables[0].transform.gameObject;
                Iinteractable[] interacts = target.GetComponents<Iinteractable>();

                foreach (Iinteractable interact in interacts)
                {
                    interact.Interact();
                }
            }

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
