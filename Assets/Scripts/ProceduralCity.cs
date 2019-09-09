using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralCity : MonoBehaviour
{
    public GameObject citySphere;
    public float connectionDistance;
    public int cityDistance = 20;

    private List<GameObject> cities = new List<GameObject>();

    void Awake()
    {
        for (int i = -cityDistance; i < cityDistance+1; i++)
        {
            for (int j = -cityDistance; j < cityDistance+1; j++)
            {
                Vector3 myPosition = new Vector3(i, 0, j); 

                float distance = Vector3.Distance(myPosition, new Vector3(0, 0, 0));

                float probability = -5f * distance + 100;

                float random = Random.Range(0, 100);

                if(random < probability)
                {
                    float jitter = Random.RandomRange(-2, 2);
                    GameObject city = Instantiate(citySphere, new Vector3(
                        i * connectionDistance + jitter, 
                        0, 
                        j * connectionDistance + jitter), 
                        Quaternion.identity);
                    cities.Add(city);
                }
            }
        }
    }

    Transform GetClosestEnemy(Vector3 currentPos)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;

        foreach (GameObject t in cities)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist && dist != 0)
            {
                tMin = t.transform;
                minDist = dist;
            }
        }
        return tMin;
    }

    void Update()
    {
        foreach (GameObject x in cities)
        {
            Debug.DrawLine(x.transform.position, GetClosestEnemy(x.transform.position).position, Color.red);
        }
    }
}
