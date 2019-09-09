using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombie;

    void Start()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        Instantiate(zombie, transform.position, Quaternion.identity);
        StartCoroutine("Spawn");
    }
}
