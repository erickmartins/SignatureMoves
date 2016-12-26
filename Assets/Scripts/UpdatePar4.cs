using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UpdatePar4 : MonoBehaviour {
    private bool needupdate = false;
    public List<GameObject> allinstances = new List<GameObject>();
    public GameObject gobbler;
    private GameObject thespawner;
    private SpawnScript thescript;
    private AttractorScript tmp;
    private AttractorGobbler tmp_gob;
	// Use this for initialization
	void Start () {
        thespawner = GameObject.Find("Spawner");
        thescript = thespawner.GetComponent<SpawnScript>();
        tmp_gob = gobbler.GetComponent<AttractorGobbler>();
        allinstances = thescript.allclones;
        if (allinstances.Count < 2)
        {
            needupdate = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
	    if (needupdate == true)
        {
            allinstances = thescript.allclones;
            needupdate = false;
        }
	}

    public void updater(float newval)
    {
        tmp_gob.setpar4(newval);
        for (int i = 0; i < allinstances.Count; i++)
        {
            tmp = thescript.allclones[i].GetComponent<AttractorScript>();
            tmp.setpar4(newval);
        }
    }
}
