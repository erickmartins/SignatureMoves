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
    public List<GameObject> allmappers = new List<GameObject>();

    void Start()
    {
        SetupSpawn();
       
    }

    public void SetupSpawn()
    {

        switch (myDropdown.value)
        {
            case 0:
                SpawnSpheres(numberOfObjects, false, prefab_common, 0.1f);
                break;
            case 1:
                SpawnSpheres(numberOfObjects, false, prefab_common, 10.0f);
                break;

           
            case 2:
                SpawnSpheres(numberOfObjects, false, prefab_common, 10.0f);
                break;
            case 3:
                SpawnSpheres(numberOfObjects, false, prefab_common, 10.0f);
                break;
            case 4:
                SpawnSpheres(numberOfObjects, false, prefab_common, 10.0f);
                break;
            case 5:
                SpawnSpheres(numberOfObjects, false, prefab_common, 10.0f);
                break;
            

            case 6:
                SpawnSpheres(5, true, prefab_mapping, 0);
                break;
        }
        
    }

    

    public void SpawnSpheres(int num, bool isMapping, GameObject prefab, float radius)
    {
        Vector3 pos = new Vector3();
        Object test;
        if (isMapping == true)
        {
            if (allmappers.Count > 1)
            {
                for (int i = 0; i < num; i++)
                {

                    pos.Set(Random.Range(-1.0f * radius, 1.0f * radius), Random.Range(-1.0f * radius, 1.0f * radius), Random.Range(-1.0f * radius, 1.0f * radius));
                    allmappers[i].GetComponent<Transform>().position = pos;

                }
            }else
            {
                for (int i = 0; i < num; i++)
                {

                    pos.Set(0f, 0f, 0f);
                    test = Instantiate(prefab, pos, Quaternion.identity);
                    allmappers.Add((GameObject)test);
                }
            }

                
        }else
        {
            if (allclones.Count > 1)
            {
                
                
                for (int i = 0; i < num; i++)
                {
                    //Debug.Log(i);
                    //Debug.Log(allclones[i]);
                    pos.Set(Random.Range(-1.0f * radius, 1.0f * radius), Random.Range(-1.0f * radius, 1.0f * radius), Random.Range(-1.0f * radius, 1.0f * radius));
                    if (allclones[i] == null)
                    {
                        test = Instantiate(prefab, pos, Quaternion.identity);
                        allclones[i] = (GameObject)test;
                    }else
                    {
                        allclones[i].GetComponent<Transform>().position = pos;
                    }
                    

                }
            }
            else
            {
                for (int i = 0; i < num; i++)
                {

                    pos.Set(Random.Range(-1.0f * radius, 1.0f * radius), Random.Range(-1.0f * radius, 1.0f * radius), Random.Range(-1.0f * radius, 1.0f * radius));
                    test = Instantiate(prefab, pos, Quaternion.identity);
                    allclones.Add((GameObject)test);

                }
                
            }
            
        }
        
    }

    // Update is called once per frame
    void Update () {
	
	}
}
