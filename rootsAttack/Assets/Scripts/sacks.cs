using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sacks : MonoBehaviour
{
    public int score;
    public vegType requiredType;

    private void OnTriggerStay(Collider other)
    {
        var ic = other.GetComponent<Icollect>();
        Debug.Log("Collider");
        if (ic != null)
        {
            if (ic.WhichVeg().Equals(requiredType))
            {
                //add 1 to score
            }
            else
            {
                //sub 1 to score
            }

            ic.DestroyVeg();
        }
    }
}
