using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    
    LayerMask mask;

    Animator animator;

    MovementController controller;


    //Is the Character Currently Interacting
    private bool Interacting = false;

    // Start is called before the first frame update
    void Start()
    {
        mask = LayerMask.GetMask("Interactable");
        animator = transform.Find("Character Sprite").GetComponent<Animator>();
        controller = GetComponent<MovementController>();
    }


    //Called by the animation statemachine to signal animation completion
    public void PickupAnimationComplete() {

        Interacting = false;
    }


    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("Pickup", 0);
  


        if ((Input.GetKeyDown(KeyCode.E)) && (Interacting == false))
        {

            Interacting = true;
       
            
                RaycastHit2D[] interactables = Physics2D.CircleCastAll(this.transform.position, 2f, new Vector2(0f, 0f), Mathf.Infinity, mask);

                if (interactables.Length != 0)
                {
                    GameObject target = interactables[0].transform.gameObject;
                    Iinteractable[] interacts = target.GetComponents<Iinteractable>();

                    foreach (Iinteractable interact in interacts)
                    {
                        interact.Interact(gameObject);

                    }
                }
            


            if (controller.facing == 1)
            {
                animator.SetInteger("Pickup", 1);
            }
            else if (controller.facing == 4)
            {
                animator.SetInteger("Pickup", 4);
            }
            else if (controller.facing == 2)
            {
                animator.SetInteger("Pickup", 2);
            }
            else if (controller.facing == 3)
            {
                animator.SetInteger("Pickup", 3);
            }



        }


    }
    


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 2);
    }
}
