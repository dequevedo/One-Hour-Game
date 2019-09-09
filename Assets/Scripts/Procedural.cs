using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procedural : MonoBehaviour
{
    public GameObject grassPrefab;
    public int grassQuantity;
    public float grassRange;


    void Awake()
    {
        for(int i = 0; i < grassQuantity; i++)
        {
            Instantiate(
                grassPrefab, 
                new Vector3(
                    Random.Range(-grassRange, grassRange),
                    0, 
                    Random.Range(-grassRange, grassRange)),
                Quaternion.identity);
        }
    }
}
