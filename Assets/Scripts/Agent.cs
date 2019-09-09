using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject target;
    public GameObject blood;
    
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        agent.SetDestination(target.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Projectile")
        {
            Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
