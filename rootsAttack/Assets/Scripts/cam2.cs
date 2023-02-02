using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam2 : MonoBehaviour
{

    public Transform target;
    public float distance; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var t = target.position;
        t.y = transform.position.y;
        t.z -= distance;
        transform.position = t; 
    }
}
