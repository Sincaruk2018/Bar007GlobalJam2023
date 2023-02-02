using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Veggies : MonoBehaviour, Icollect
{

    public vegType myType; 
    Transform target;
    public float speed; 
    Rigidbody m_rb;
    bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!OnGround()) { return; }
        canMove = transform.parent == null ? true : false;

        if (!canMove)
        {
            transform.localPosition = Vector3.zero;
            return;
        }
        var d = (target.position - transform.position).normalized * speed;
        d.y = m_rb.velocity.y;

        m_rb.velocity = d;
    }

    bool OnGround()
    {
        Debug.DrawRay(transform.position, Vector3.down * 1);
        if (Physics.Raycast(transform.position, Vector3.down, 1))
        {
            return true;
        }

        return false;
    }

    public void DestroyVeg()
    {
        Destroy(gameObject);
    }

    public void SetTarget(Transform t)
    {
        target = t;
    }

    public vegType WhichVeg()
    {
        return myType;
    }

    public void GrabVeg(Transform parent)
    {
        Debug.Log("item grabbing");
        transform.parent = parent;
    }

    public void Throw(Vector3 dir)
    {
        m_rb.velocity = dir;
    }
}
