using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class BasicEnemyAi : MonoBehaviour
{


    public Transform target;
    public Seeker seeker;
    public Rigidbody2D rbody;


    public float movespeed = 1f;
    public float nextWaypointDistance = 0.5f;

    private Path path;
    private int currentWaypoint;

    bool reachedEndOfPath = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("InteractionCheck");
    }

    // Update is called once per frame
    void Update()
    {
}

    private void FixedUpdate()
    {
        Move();
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }

    }
    void Move()
    {

        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }


        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rbody.position).normalized;
        transform.position = new Vector2(transform.position.x, transform.position.y) + (direction * movespeed * Time.fixedDeltaTime);

        float distance = Vector2.Distance(rbody.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }


    IEnumerator InteractionCheck()
    {

        for (; ; )
        {
            if (Vector2.Distance(transform.position, target.position) < 10f)
            {
            
                    seeker.StartPath(transform.position, target.position, OnPathComplete);

                //yield break;
            }
            yield return new WaitForSeconds(1f);
        }
    }

}
