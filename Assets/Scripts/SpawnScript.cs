using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnScript : MonoBehaviour {

    public GameObject prefab;
    public int numberOfObjects = 100;
    public float radius = 50f;
    public List<GameObject> allclones = new List<GameObject>();
    
    void Start()
    {
        
        for (int i = 0; i < numberOfObjects; i++)
        {
            
            Vector3 pos = new Vector3(Random.Range(-1.0f*radius, 1.0f * radius), Random.Range(-1.0f * radius, 1.0f * radius), Random.Range(-1.0f * radius, 1.0f * radius));
           Object test= Instantiate(prefab, pos, Quaternion.identity);
            allclones.Add((GameObject)test);
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
