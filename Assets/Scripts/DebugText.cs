using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DebugText : MonoBehaviour {
    public Text text;
    public GameObject thesphere;
    AttractorScript thescript;
    private float val1;
	// Use this for initialization
	void Start () {
        thescript = thesphere.GetComponent<AttractorScript>();
	}
	
	// Update is called once per frame
	void Update () {
        val1 = thescript.par1;
        text.text = val1.ToString();
	}
}
