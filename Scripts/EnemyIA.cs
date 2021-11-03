using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyIA : MonoBehaviour
{
    public Transform traget;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    private Path payh;
    private int CurrentWaypoint = 0;
    private bool reachedEndOfPhat = false;

    private Seeker seeker;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
