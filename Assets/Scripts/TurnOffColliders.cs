using UnityEngine;
using System.Collections;

public class TurnOffColliders : MonoBehaviour {

	// Use this for initialization
	void Start () {
        foreach (Collider c in GetComponents<Collider>())
        {
            c.enabled = false;
     }
        transform.GetComponent<Renderer>().material.color=new Color(0.0f,0.0f,0.0f,0.0f);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
