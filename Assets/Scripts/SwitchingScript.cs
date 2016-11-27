using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class SwitchingScript : MonoBehaviour {
    public Dropdown myDropdown;

    public List<GameObject> allinstances = new List<GameObject>();
    public List<GameObject> allmaps = new List<GameObject>();
    private GameObject thespawner;
    private SpawnScript thescript;
    GameObject par1_sl, par2_sl, par3_sl, par4_sl, par1_txt, par2_txt, par3_txt, par4_txt;

    // Use this for initialization
    void Start () {
        par1_sl = GameObject.Find("par1_slider");
        par2_sl = GameObject.Find("par2_slider");
        par3_sl = GameObject.Find("par3_slider");
        par4_sl = GameObject.Find("par4_slider");

        par1_txt = GameObject.Find("par1_text");
        par2_txt = GameObject.Find("par2_text");
        par3_txt = GameObject.Find("par3_text");
        par4_txt = GameObject.Find("par4_text");
        myDropdown.onValueChanged.AddListener(delegate {
            myDropdownValueChangedHandler(myDropdown);
        });
        thespawner = GameObject.Find("Spawner");
        thescript = thespawner.GetComponent<SpawnScript>();
        allinstances = thescript.allclones;
        AdjustUI(myDropdown.value);
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
        
        
        
       
        thescript.SetupSpawn();
        allinstances = thescript.allclones;
        allmaps = thescript.allmappers;
        if (target.value != 6)
        {
            
            for (int i = 0; i < allinstances.Count; i++)
            {
                thescript.allclones[i].GetComponent<AttractorScript>().SwitchAttractor(target.value);
                thescript.allclones[i].SetActive(true);
            }
            for (int i = 0; i < allmaps.Count; i++)
            {
                thescript.allmappers[i].SetActive(false);
            }

        }
        else
        {
            
            for (int i = 0; i < allmaps.Count; i++)
            {
                thescript.allmappers[i].GetComponent<AttractorScript>().SwitchAttractor(target.value);
                thescript.allmappers[i].SetActive(true);
            }
            for (int i = 0; i < allinstances.Count; i++)
            {
                
                thescript.allclones[i].SetActive(false);
            }
        }
        
        
        AdjustUI(target.value);


    }

    void AdjustUI(int num)
    {
        switch (num)
        {
            case 0:
                par1_sl.gameObject.SetActive(true);
                par2_sl.gameObject.SetActive(true);
                par3_sl.gameObject.SetActive(true);
                par4_sl.gameObject.SetActive(false);

                par1_sl.GetComponent<Slider>().minValue = 0.01f;
                par1_sl.GetComponent<Slider>().maxValue = 50.0f;
                par1_sl.GetComponent<Slider>().value = 10.0f;

                par2_sl.GetComponent<Slider>().minValue = 0.01f;
                par2_sl.GetComponent<Slider>().maxValue = 50.0f;
                par2_sl.GetComponent<Slider>().value = 28.0f;

                par3_sl.GetComponent<Slider>().minValue = 0.01f;
                par3_sl.GetComponent<Slider>().maxValue = 10.0f;
                par3_sl.GetComponent<Slider>().value = 2.66f;

                par1_txt.SetActive(true);
                par2_txt.SetActive(true);
                par3_txt.SetActive(true);
                par4_txt.SetActive(false);
                break;

            case 1:
                par1_sl.gameObject.SetActive(true);
                par2_sl.gameObject.SetActive(true);
                par3_sl.gameObject.SetActive(true);
                par4_sl.gameObject.SetActive(false);

                par1_sl.GetComponent<Slider>().minValue = 0.01f;
                par1_sl.GetComponent<Slider>().maxValue = 1.0f;
                par1_sl.GetComponent<Slider>().value = 0.1f;

                par2_sl.GetComponent<Slider>().minValue = 0.01f;
                par2_sl.GetComponent<Slider>().maxValue = 1.0f;
                par2_sl.GetComponent<Slider>().value = 0.1f;

                par3_sl.GetComponent<Slider>().minValue = 0.01f;
                par3_sl.GetComponent<Slider>().maxValue = 30.0f;
                par3_sl.GetComponent<Slider>().value = 14.0f;

                par1_txt.SetActive(true);
                par2_txt.SetActive(true);
                par3_txt.SetActive(true);
                par4_txt.SetActive(false);
                break;

            case 2:
                par1_sl.gameObject.SetActive(true);
                par2_sl.gameObject.SetActive(true);
                par3_sl.gameObject.SetActive(false);
                par4_sl.gameObject.SetActive(false);

                par1_sl.GetComponent<Slider>().minValue = 0.01f;
                par1_sl.GetComponent<Slider>().maxValue = 2.0f;
                par1_sl.GetComponent<Slider>().value = 0.1f;

                par2_sl.GetComponent<Slider>().minValue = 0.01f;
                par2_sl.GetComponent<Slider>().maxValue = 2.0f;
                par2_sl.GetComponent<Slider>().value = 0.98f;

                

                par1_txt.SetActive(true);
                par2_txt.SetActive(true);
                par3_txt.SetActive(false);
                par4_txt.SetActive(false);
                break;

            case 3:
                par1_sl.gameObject.SetActive(true);
                par2_sl.gameObject.SetActive(false);
                par3_sl.gameObject.SetActive(false);
                par4_sl.gameObject.SetActive(false);

                par1_sl.GetComponent<Slider>().minValue = 0.02f;
                par1_sl.GetComponent<Slider>().maxValue = 0.3f;
                par1_sl.GetComponent<Slider>().value = 0.2f;

                



                par1_txt.SetActive(true);
                par2_txt.SetActive(false);
                par3_txt.SetActive(false);
                par4_txt.SetActive(false);
                break;

            case 4:
                par1_sl.gameObject.SetActive(true);
                par2_sl.gameObject.SetActive(true);
                par3_sl.gameObject.SetActive(false);
                par4_sl.gameObject.SetActive(false);

                par1_sl.GetComponent<Slider>().minValue = 0.01f;
                par1_sl.GetComponent<Slider>().maxValue = 1.5f;
                par1_sl.GetComponent<Slider>().value = 0.85f;

                par2_sl.GetComponent<Slider>().minValue = 0.01f;
                par2_sl.GetComponent<Slider>().maxValue = 1.0f;
                par2_sl.GetComponent<Slider>().value = 0.5f;
                

                par1_txt.SetActive(true);
                par2_txt.SetActive(true);
                par3_txt.SetActive(false);
                par4_txt.SetActive(false);
                break;

            case 5:
                par1_sl.gameObject.SetActive(true);
                par2_sl.gameObject.SetActive(true);
                par3_sl.gameObject.SetActive(true);
                par4_sl.gameObject.SetActive(true);

                par1_sl.GetComponent<Slider>().minValue = 0.01f;
                par1_sl.GetComponent<Slider>().maxValue = 5f;
                par1_sl.GetComponent<Slider>().value = 1f;

                par2_sl.GetComponent<Slider>().minValue = 0.01f;
                par2_sl.GetComponent<Slider>().maxValue = 10.0f;
                par2_sl.GetComponent<Slider>().value = 3f;

                par3_sl.GetComponent<Slider>().minValue = 0.01f;
                par3_sl.GetComponent<Slider>().maxValue = 5.0f;
                par3_sl.GetComponent<Slider>().value = 1f;

                par4_sl.GetComponent<Slider>().minValue = -10f;
                par4_sl.GetComponent<Slider>().maxValue = 10.0f;
                par4_sl.GetComponent<Slider>().value = 5f;

                par1_txt.SetActive(true);
                par2_txt.SetActive(true);
                par3_txt.SetActive(true);
                par4_txt.SetActive(true);
                break;




            case 6:
                par1_sl.gameObject.SetActive(false);
                par2_sl.gameObject.SetActive(false);
                par3_sl.gameObject.SetActive(false);
                par4_sl.gameObject.SetActive(false);

                par1_txt.SetActive(false);
                par2_txt.SetActive(false);
                par3_txt.SetActive(false);
                par4_txt.SetActive(false);
                break;

        }
    }
    
}
