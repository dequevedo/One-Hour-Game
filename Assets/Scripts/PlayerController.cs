using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody rigidbody;
    public GameObject projectile;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement();
        MouseLook();
        if (Input.GetMouseButtonDown(0)) Shoot();
    }

    void Movement()
    {
        float h = Input.GetAxis("Horizontal") * speed;
        float v = Input.GetAxis("Vertical") * speed;

        Vector3 force = new Vector3(h, 0, v).normalized;

        rigidbody.AddForce(force, ForceMode.Impulse);
    }

    public LayerMask hitLayers;

    void MouseLook()
    {
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, hitLayers))
        {
            var lookPos = hit.point - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 100);
        }
    }

    void Shoot()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }
}
