using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AI_S : MonoBehaviour
{

    public Transform Target;
    public float speed = 20f;
    public float nextWayPointDistance = 3f;

    Path path;
    int currnetWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;
    
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
        UpdatePath();
    }

    private void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, Target.position, OnPathComplete); 
        }
        
    }

    void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }

        if (currnetWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return; 
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currnetWaypoint] - rb.position).normalized;  

        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currnetWaypoint]);

        if (distance < nextWayPointDistance)
        {
            currnetWaypoint++;
        }
    }

    void OnPathComplete(Path p){
        if (!p.error)
        {
            path = p;
            currnetWaypoint =0;
        }
    }
}
