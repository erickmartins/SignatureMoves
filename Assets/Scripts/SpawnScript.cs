using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SpawnScript : MonoBehaviour {
    public Dropdown myDropdown;
    public GameObject prefab_common;
    public GameObject prefab_mapping;
    public int numberOfObjects = 100;
    public float radius = 50f;
    public List<GameObject> allclones = new List<GameObject>();
    
    void Start()
    {
        SetupSpawn();
       
    }

    public void SetupSpawn()
    {
        if (myDropdown.value == 1)
        {
            SpawnSpheres(5, true, prefab_mapping);
        }
        else
        {
            SpawnSpheres(numberOfObjects, false, prefab_common);
        }
    }

    public void DestroySpheres()
    {
        allclones= new List<GameObject>();
    }

    public void SpawnSpheres(int num, bool isMapping, GameObject prefab)
    {
        if (isMapping == true)
        {
            for (int i = 0; i < num; i++)
            {

                Vector3 pos = new Vector3(0f,0f,0f);
                Object test = Instantiate(prefab, pos, Quaternion.identity);
                allclones.Add((GameObject)test);
            }
        }else
        {
            for (int i = 0; i < num; i++)
            {

                Vector3 pos = new Vector3(Random.Range(-1.0f * radius, 1.0f * radius), Random.Range(-1.0f * radius, 1.0f * radius), Random.Range(-1.0f * radius, 1.0f * radius));
                Object test = Instantiate(prefab, pos, Quaternion.identity);
                allclones.Add((GameObject)test);
            }
        }
        
    }

    // Update is called once per frame
    void Update () {
	
	}
}
