using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyAI : MonoBehaviour {

    public Transform target;
    
    public float updateRate = 2f;

    private Seeker seeker;
    private Rigidbody2D rb;
    private EnemyAttack enemyAttack;
    public Path path;

    public float speed = 3f;
    public ForceMode2D fMode;
    
    bool pathIsEnded = false;


    bool moving = true;

    private int currentWaypoint = 0;

    public float nextWaypointDistance = 3;

    public float targetDistance = 2;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        enemyAttack = GetComponent<EnemyAttack>();

        GameObject targetgo = GameObject.FindGameObjectWithTag("Player");

        target = targetgo.transform;
        if (target == null) {
            Debug.Log("Target not Found!");

        }

        seeker.StartPath(transform.position, target.position, OnPathComplete);

        StartCoroutine(UpdatePath());

    }


    public void OnPathComplete(Path p) {
        //Debug.Log("We got a  path. Did it error ? " + p.error);
        if (!p.error) {
            path = p;
            currentWaypoint = 0;
        }
    }

    IEnumerator UpdatePath() {
        if (target == null) {
            //TODO: Insert a path search here.
            yield return false;
        }



        seeker.StartPath(transform.position, target.position, OnPathComplete);

        yield return new WaitForSeconds(1f / updateRate);
        StartCoroutine(UpdatePath());
    }


    void FixedUpdate()
    {
        //this might not be desireable it might be useful to allow certain enemies to attack while moving!
        if (enemyAttack.attacking == false)
        {

            enemyAttack.TryAttack();

            if (Vector2.Distance(transform.position, target.position) <= targetDistance)
            {
                moving = false;

            }
            else
            {
                moving = true;
            }


            if (moving)
            {

                Move();
            }

        }
    }


    private void Move()
    {
        if (target == null)
        {
            return;
        }

        if (path == null)
        {
            return;
        }
     
        if (currentWaypoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
            {
                return;
            }

            // Debug.Log("End of path reached.");

            pathIsEnded = true;
            return;
        }

        pathIsEnded = false;

        //Direction to the next waypoint
       
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;

  
        dir *= speed * Time.fixedDeltaTime;
        dir.z = 0;
     
        transform.position = new Vector3(transform.position.x, transform.position.y) + (dir);

        float dist = (Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]));

        if (dist < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }
    }


   
}
