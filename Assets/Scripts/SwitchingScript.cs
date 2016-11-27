using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class SwitchingScript : MonoBehaviour {
    public Dropdown myDropdown;

    public List<GameObject> allinstances = new List<GameObject>();
    private GameObject thespawner;
    private SpawnScript thescript;

    // Use this for initialization
    void Start () {
        myDropdown.onValueChanged.AddListener(delegate {
            myDropdownValueChangedHandler(myDropdown);
        });
        thespawner = GameObject.Find("Spawner");
        thescript = thespawner.GetComponent<SpawnScript>();
        allinstances = thescript.allclones;
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void Destroy()
    {
        myDropdown.onValueChanged.RemoveAllListeners();
    }

    public void SetDropdownIndex(int index)
    {
        myDropdown.value = index;
    }

    private void myDropdownValueChangedHandler(Dropdown target)
    {
        
        for (int i = 0; i < allinstances.Count; i++)
        {
            Destroy(thescript.allclones[i]);

        }
        thescript.DestroySpheres();
        thescript.SetupSpawn();
        allinstances = thescript.allclones;
        for (int i = 0; i < allinstances.Count; i++)
        {
            thescript.allclones[i].GetComponent<AttractorScript>().SwitchAttractor(target.value);

        }
    }
    
}
