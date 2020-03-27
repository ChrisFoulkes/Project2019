using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class PlayerMovement : MonoBehaviour
{

    
    public float movespeed = 2f;
    public float nextWaypointDistance = 0.5f;

    public CharacterInteractor characterInteractor;
    public Seeker seeker;
    public AstarPath astar;
    public Rigidbody2D rbody;



    private Path path;
    private int currentWaypoint;

    bool reachedEndOfPath = true;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(astar.data.gridGraph.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);


            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<IInteractable>() == null)
                {
                    SetDirection(mousePos2D);

                }
            }
            else
            {
                if (characterInteractor.interactionOpened == false)
                {
                    SetDirection(mousePos2D);
                }
            }
        }
        
    }

    private void FixedUpdate()
    {

      //  astar.data.gridGraph.center = transform.position;
        Move();
    }

    public void SetDirection(Vector2 pos)
    {
        //astar.Scan();
        // seeker.CancelCurrentPathRequest(true);
       
        seeker.StartPath(transform.position, pos, OnPathComplete);
   
    }

    public void StopPath() {
        path = null;
    }

    void OnPathComplete(Path p) {
        if (!p.error) {
            path = p;
            currentWaypoint = 0; 
        }

    }
    void Move()
    {

        if (path == null) {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else {
            reachedEndOfPath = false;
        }


        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rbody.position).normalized;
        transform.position = new Vector2(transform.position.x, transform.position.y) + (direction * movespeed * Time.fixedDeltaTime);

        float distance = Vector2.Distance(rbody.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance) {
            currentWaypoint++;
        }
    }
}
