using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Warp : MonoBehaviour
{
    public GameObject target;

    public GameObject targetMap;
    // Start is called before the first frame update

    void Awake()
    {
        Assert.IsNotNull(target);

        GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;

        Assert.IsNotNull(targetMap);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        col.transform.position = target.transform.GetChild(0).transform.position;

        //Camera.main.GetComponent<MainCamera>().SetBound(targetMap);
    }
}
