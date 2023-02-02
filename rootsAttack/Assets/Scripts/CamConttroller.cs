using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamConttroller : MonoBehaviour
{
    private float m_currentXRot;
    private float m_currentYRot;

    [SerializeField] private Transform m_target;
    [SerializeField] private float m_distance;
    [SerializeField] private float m_viewHeight;
    [SerializeField] private float m_height;
    [SerializeField] private float m_rotSpeedX;
    [SerializeField] private float m_rotSpeedY;
    [SerializeField] private float m_minClampY;
    [SerializeField] private float m_maxClampY;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        m_currentXRot += Input.GetAxis("Mouse X") * m_rotSpeedX;
        m_currentYRot -= Input.GetAxis("Mouse Y") * m_rotSpeedY;

        m_currentYRot = Mathf.Clamp(m_currentYRot, m_minClampY, m_maxClampY);
        //m_currentYRot = y;

        var q = Quaternion.Euler(m_currentYRot, m_currentXRot, 0);

        transform.position = m_target.position - q * Vector3.forward * DistanceLimit(m_distance) + Vector3.up * m_height;

        transform.LookAt(m_target.position + Vector3.up * m_viewHeight);
    }

    float DistanceLimit(float d)
    {
        RaycastHit hit;
        var dir = transform.position - m_target.position;

        if (Physics.Raycast(m_target.position, dir, out hit, d))
        {
            return hit.distance - 0.5f;
        }

        return d;
    }
}
