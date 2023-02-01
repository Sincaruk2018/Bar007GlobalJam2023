using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Aabstract : MonoBehaviour, Icontext
{
    public float life;
    public string name;
    public int age;

    Rigidbody rb; 

    protected void init()
    {
        rb = GetComponent<Rigidbody>();
    }

    public int explode(Vector3 dir)
    {
        rb.velocity = (transform.position - dir).normalized * 1000;
        return 1; 
    }

    protected void fuckit()
    {
        Debug.Log("fuckit");
    }
}
