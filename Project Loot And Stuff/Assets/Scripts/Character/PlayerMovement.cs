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

        astar.data.gridGraph.center = transform.position;
        
        if (Input.GetMouseButtonDown(1))
        {
          
      
  
        }
    }

    private void FixedUpdate()
    {

        Move();
    }

    public void SetDirection(Vector2 pos)
    {
     
      
        astar.Scan();
        seeker.StartPath(transform.position, pos, OnPathComplete);
       
    }

    public void StopPath() {
        currentWaypoint = 100;
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
