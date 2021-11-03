using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 mewPos = new Vector3(target.position.x,target.position.y,-10f);
        transform.position = Vector3.Slerp(transform.position,mewPos,FollowSpeed*Time.deltaTime);
    }
}
