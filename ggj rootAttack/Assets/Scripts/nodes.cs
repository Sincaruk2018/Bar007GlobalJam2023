using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nodes : MonoBehaviour, nodescol
{
    private bool isPlayerConnected = false;
    public List<GameObject> lazers;
    public bool isFirst = false; 

    void toggleLazer(bool b)
    {
        foreach(var l in lazers)
        {
            l.SetActive(b);
        }
    }
    public void Connect(Vector2 pos)
    {
        if (isFirst) return;
        if (!isPlayerConnected)
        {
            var v = new Vector3(pos.x, transform.position.y);
            transform.position = v;
            toggleLazer(true);
        }else
        {
            isPlayerConnected = false;
        }
    }

    public Transform PlayerConnect()
    {
        isPlayerConnected = true;
        return transform;
    }

    public void Disconnect()
    {
        if (isFirst) return;
        toggleLazer(false);
    }

    /*    private void OnTriggerStay2D(Collider2D collision)
        {
            collision.GetComponent<nodescol>().Connect(target.position);
            isPlayerConnected = false;
        }
    */
}
