﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UpdatePar2 : MonoBehaviour {
    private bool needupdate = false;
    public List<GameObject> allinstances = new List<GameObject>();
    private GameObject thespawner;
    private SpawnScript thescript;
	// Use this for initialization
	void Start () {
        thespawner = GameObject.Find("Spawner");
        thescript = thespawner.GetComponent<SpawnScript>();
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
        for (int i = 0; i < allinstances.Count; i++)
        {
            AttractorScript tmp = thescript.allclones[i].GetComponent<AttractorScript>();
            tmp.setpar2(newval);
        }
    }
}