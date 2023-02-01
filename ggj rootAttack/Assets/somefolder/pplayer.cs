using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pplayer : Aabstract
{

    // Start is called before the first frame update
    private void Start()
    {
        init();
    }
    // Update is called once per frame
    void Update()
    {
  
        var h = Input.GetAxis("Horizontal") * 10;
        var v = Input.GetAxis("Vertical") * 10;

      //  var move = new Vector3(h, rb.velocity.y, v);
       //s rb.velocity = move; 
    }
}
