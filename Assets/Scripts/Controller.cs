using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject cursor;
    public Rigidbody rigidBody;
    int layerMask;
    public float distance;

    void Awake()
    {
        layerMask = LayerMask.GetMask("Ground");
        rigidBody = cursor.GetComponent<Rigidbody>();
    }

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit, distance, layerMask))
        {
            Debug.Log(hit.collider.gameObject.name);
            Debug.Log(hit.point);
            //cursor.transform.position = hit.point;
            rigidBody.MovePosition(hit.point);
        }
    }
}
