using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public float speed;
    public float jumpheight;
    public float swingVelocity; // Angular velocity
    public float swingDelay; // Swing

    public Transform cam;
    public Transform OLS; // over lapping sphere

    Rigidbody m_rb;
    Rigidbody m_stick;
    Vector3 m_move;
    Transform m_orient;
    GameObject veggie;
    GameObject stick;

    // Start is called before the first frame update
    void Start()
    {
        stick = GameObject.Find("WoodStick");
        stick.SetActive(false);
        m_rb = GetComponent<Rigidbody>();
        m_stick = stick.GetComponent<Rigidbody>();
        m_orient = new GameObject("Player Orientation").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (m_move.sqrMagnitude > 1)
            LookForward();

        if (Input.GetMouseButtonDown(0))
            GrabVeggie();
    }

    void Movement()
    {
        m_orient.eulerAngles = new Vector3(0, cam.eulerAngles.y, 0);

        var h = Input.GetAxis("Horizontal") * speed;
        var v = Input.GetAxis("Vertical") * speed;

        m_move = new Vector3(h, m_rb.velocity.y, v);
        m_move = m_orient.transform.TransformDirection(m_move);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_move.y += jumpheight;
        }

        m_rb.velocity = m_move;

        /* Added code for the attack*/
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            
        }
    }

    void LookForward()
    {
        var v = new Vector3(m_move.x, 0, m_move.z);
        var r = Quaternion.LookRotation(v);
        var q = Quaternion.Slerp(transform.rotation, r, 15 * Time.deltaTime);

        transform.rotation = q; 
    }

    void GrabVeggie()
    {
        if (veggie == null)
        {
            /* This is interesting, I'll ask Noly later about it*/
            var c = Physics.OverlapSphere(OLS.position, OLS.localScale.x);
            foreach (var obj in c)
            {
                Debug.Log(obj.name);
                var ic = obj.GetComponent<Icollect>();
                if (ic != null)
                {
                    veggie = obj.gameObject; 
                    ic.GrabVeg(OLS);
                    break;
                }
            }
        }
        else
        {
            var ic = veggie.GetComponent<Icollect>();
            var d = (transform.forward + Vector3.up * 0.5f) * 15;
            ic.GrabVeg(null);
            ic.Throw(d);
            veggie = null;
            Debug.Log("Thown");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(OLS.position, OLS.localScale.x);
    }

    IEnumerator SwingStick()
    {
        stick.SetActive(true);
        yield return new WaitForSeconds(swingDelay);


    }
}
