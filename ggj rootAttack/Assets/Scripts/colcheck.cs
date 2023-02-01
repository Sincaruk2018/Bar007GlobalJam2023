using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colcheck : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.GetComponent<nodescol>().Connect(transform.position);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<nodescol>().Disconnect();
    }
}
