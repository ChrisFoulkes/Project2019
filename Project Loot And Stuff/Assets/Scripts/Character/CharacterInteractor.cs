using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class CharacterInteractor : MonoBehaviour
{
    public PlayerMovement playerMovement;
    LayerMask mask;


    Vector2 interactionPoint;
    Collider2D clickedObject;
    public bool interactionOpened = false;
    // Start is called before the first frame update
    void Start()
    {
        mask = LayerMask.GetMask("Interactable");
    }

    // Update is called once per frame
    void Update()
    {

        /*
        if (Input.GetKeyDown(KeyCode.E)) {
            RaycastHit2D[] interactables = Physics2D.CircleCastAll(this.transform.position, 2f, new Vector2(0f, 0f), Mathf.Infinity, mask);
            if (interactables.Length != 0) {
                GameObject target = interactables[0].transform.gameObject;
                //target.GetComponent<NpcCharacter>().Interact();
                target.GetComponent<IInteractable>().GetActions();
            }
        }
        */

        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

           
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

     
            if (hit.collider != null)
            {

                clickedObject = hit.collider;

                if (clickedObject.GetComponent<IInteractable>() != null)
                {
                    if (Vector2.Distance(transform.position, mousePos2D) < 2f)
                    {
                        OpenPanel();

                    }else
                    {
                        InteractionPanel.Instance.Enabled(false);
                        interactionOpened = false;

                        playerMovement.SetDirection(mousePos2D);

                        interactionPoint = mousePos2D;
                        StartCoroutine("InteractionCheck");
                    }
                }
                else
                {
                    InteractionPanel.Instance.Enabled(false);
                    interactionOpened = false;
                }

            }
            else {


                if (interactionOpened == false)
                {

                    playerMovement.SetDirection(mousePos);
                }

                InteractionPanel.Instance.Enabled(false);
                interactionOpened = false;
            }
        }
        
    }
    void OpenPanel() {
        playerMovement.StopPath();
        InteractionPanel.Instance.Enabled(true); // has to disables all active buttons for set position shift
        clickedObject.GetComponent<IInteractable>().SetActions();
        InteractionPanel.Instance.SetPosition();
        interactionOpened = true;
    }

    //interaction proximity check 
    IEnumerator InteractionCheck()
    {

        for (; ; )
        {
            if (Vector2.Distance(transform.position, interactionPoint) < 2f)
            {
                OpenPanel();
                yield break;
            }
            yield return new WaitForSeconds(.3f);
        }
    }
}
