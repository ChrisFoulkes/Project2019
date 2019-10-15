using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyAI : MonoBehaviour {

    public Transform target;

    public float updateRate = 2f;

    private Seeker seeker;
    private Rigidbody2D rb;

    public Path path;

    public float speed = 300f;
    public ForceMode2D fMode;
    
    public bool pathIsEnded = false;


    public bool moving = true;
    public bool attacking = true;

    private int currentWaypoint = 0;

    public float nextWaypointDistance = 3;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

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
       // AiAttack();


        if (Vector2.Distance(transform.position, target.position) <= 2f)
        {
            moving = false;

        }
        else {
            moving = true;
        }


        if (moving)
        {
         
            Move();
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
        rb.AddForce(dir);
       
        //transform.position = transform.position* speed * Time.fixedDeltaTime;
        rb.AddForce(dir, fMode);


        //if (dir.y > 0.1)
        //{
        //    dir = new Vector2(dir.x, 20f);

        //}
        //else
        //{
        //   rb.AddForce(dir, fMode);
        //}

        float dist = (Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]));

        if (dist < nextWaypointDistance)
        {
            Debug.Log("moving!");
            currentWaypoint++;
            return;
        }
    }


    //basic Attack


    public void AiAttack() {
        if(CanAttack())
        gameObject.GetComponent<Animator>().Play("AttackAnimation");

    }

    public bool CanAttack() {
        return true;
    }
}
