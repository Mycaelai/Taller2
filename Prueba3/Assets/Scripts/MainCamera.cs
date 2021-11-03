using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    Transform target;
    //float tLX, tLY, bRX, bRY;
    
    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            target.position.x, 
            target.position.y, 
            transform.position.z);

        /*transform.position = new Vector3(
            Mathf.Clamp(target.position.x, tLX, bRX),
            Mathf.Clamp(target.position.y, tLY, bRY),
            transform.position.z);*/
    }

    /*public void SetBound (GameObject map)
    {
        SuperTiled2Unity.SuperMap config = map.GetComponent<SuperTiled2Unity.SuperMap>();
        float cameraSize = Camera.main.orthographicSize;

        tLX = map.transform.position.x + cameraSize;
        tLY = map.transform.position.y - cameraSize; 
        bRX = map.transform.position.x + config.m_Width - cameraSize;
        bRY = map.transform.position.y - config.m_Height + cameraSize;
    }*/
}
