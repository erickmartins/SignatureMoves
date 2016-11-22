using UnityEngine;
using System.Collections;

public class TurnOffColliders : MonoBehaviour {
    int size = 1000;
	// Use this for initialization
	void Start () {

        foreach (Collider c in GetComponents<Collider>())
        {
            c.enabled = false;
     }
        Texture3D tex = new Texture3D(size, size, size, TextureFormat.ARGB32, true);
        var cols = new Color[size * size * size];
        //float mul = 1.0f / (size - 1);
        //int idx = 0;
        //Color col = Color.white;
        //tex.SetPixels(cols);
        //tex.Apply();
        GetComponent<Renderer>().material.SetTexture("_Volume", tex);
        transform.GetComponent<Renderer>().material.color=new Color(0.0f,0.0f,0.0f,0.0f);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
