﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public float smoothTime = 3;

    Transform target;
    float tLX, tLY, bRX, bRY;

    Vector2 velocity;
    
    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        /*float posX = Mathf.Round(
            Mathf.SmoothDamp(transform.position.x, target.position.x, ref velocity.x, smoothTime)* 100 / 100);

        float posY = Mathf.Round(
            Mathf.SmoothDamp(transform.position.y, target.position.y, ref velocity.y, smoothTime) * 100 / 100);*/

        transform.position = new Vector3(
            target.position.x,
            target.position.y,
            transform.position.z);

        /*transform.position = new Vector3(
            Mathf.Clamp(target.position.x, tLX, bRX),
            Mathf.Clamp(target.position.y, tLY, bRY),
            transform.position.z);*/
    }

    public void SetBound (GameObject map)
    {
        SuperTiled2Unity.SuperMap config = map.GetComponent<SuperTiled2Unity.SuperMap>();
        float cameraSize = Camera.main.orthographicSize;

        tLX = map.transform.position.x + cameraSize;
        tLY = map.transform.position.y - cameraSize; 
        bRX = map.transform.position.x + config.m_Width - cameraSize;
        bRY = map.transform.position.y - config.m_Height + cameraSize;
    }
}
