using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class player : MonoBehaviour
{
    Rigidbody2D rb; 
    public float speed;
    Transform node; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //var h = Input.GetAxis("Horizontal") * speed;
        var h = Input.GetAxis("Mouse X") * speed;
        rb.velocity = new Vector2(h, 0);

        //if (Input.GetKeyDown(KeyCode.Space))
        if (Input.GetMouseButtonDown(0))
        {
            RayCheck();
        }//else if (Input.GetKeyUp(KeyCode.Space))
        else if (Input.GetMouseButtonUp(0))
        {
            node = null;
        }

        if (node != null)
        {
            var v = new Vector2(transform.position.x, node.position.y);
            node.position = v;
        }
    }

    void RayCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.down * 1.1f, Vector2.down, Mathf.Infinity); 

        if (hit != null)
        {
            Debug.Log(hit.transform.name);
            node = hit.transform.GetComponent<nodescol>().PlayerConnect();
        }
    }
}
