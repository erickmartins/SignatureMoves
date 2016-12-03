using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class SwitchingScript : MonoBehaviour {
    public Dropdown myDropdown;
    public Text helptext;
    private List<GameObject> allinstances = new List<GameObject>();
    private List<GameObject> allmaps = new List<GameObject>();
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
        allmaps = thescript.allmappers;
        AdjustUI(myDropdown.value);
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    /*void Destroy()
    {
        myDropdown.onValueChanged.RemoveAllListeners();
    }*/

    public void SetDropdownIndex(int index)
    {
        myDropdown.value = index;
    }

    private void myDropdownValueChangedHandler(Dropdown target)
    {


        Vector3 pos = new Vector3();
        float radius = 1.0f;
        //Debug.Log(target.value);
        //thescript.SetupSpawn();
        allinstances = thescript.allclones;
        allmaps = thescript.allmappers;
        if (target.value < 6)
        {
            
            for (int i = 0; i < allinstances.Count; i++)
            {
                if (thescript.allclones[i] != null)
                {
                    thescript.allclones[i].GetComponent<AttractorScript>().SwitchAttractor(target.value);
                    pos.Set(Random.Range(-1.0f * radius, 1.0f * radius), Random.Range(-1.0f * radius, 1.0f * radius), Random.Range(-1.0f * radius, 1.0f * radius));
                    allinstances[i].GetComponent<Transform>().position = pos;
                    thescript.allclones[i].GetComponent<MeshRenderer>().enabled = true;
                    thescript.allclones[i].GetComponent<TrailRenderer>().enabled = true;
                }
                
                //thescript.allclones[i].SetActive(true);    //not working fine, maybe just change alpha?
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
                
                thescript.allmappers[i].SetActive(true);
            }
            for (int i = 0; i < allinstances.Count; i++)
            {
                if (thescript.allclones[i] != null)
                {
                    //thescript.allclones[i].SetActive(false);
                    thescript.allclones[i].GetComponent<MeshRenderer>().enabled = false;
                    thescript.allclones[i].GetComponent<TrailRenderer>().enabled = false;
                }
                
            }
        }

        //Debug.Log(thescript.allmappers[0].active);
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
                helptext.text = @"
                                The Lorenz Attractor is a set of three
                                differential equations that have chaotic solutions
                                for some values of the three parameters. It was
                                studied by Edward Lorenz, and it's known for its
                                distinctive butterfly-like shape.

                                The initial set of parameters(10, 28, 2.66) should
                                yield chaotic solutions. Try(10, 50, 9) and see
                                how different the solution looks!";
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
                helptext.text = @"
                                The Rössler Attractor is also a set of three
                                differential equations, also with three parameters. 
                                The name comes from Otto Rössler. It's similar to the
                                Lorenz, but easier to analyze mathematically.

                                The shape on the Rössler attractor is quite robust to
                                changes in the parameters. Give it some time to evolve - 
                                it needs a while to expand from the centre and reach its
                                final form!";
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
                helptext.text = @"
                                The Rabinovich–Fabrikant equations are weird and
                                I'm not sure I understand them any better than 
                                you do.";
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
                helptext.text = @"
                                Thomas' cyclically symmetric attractor is really beautiful
                                and simple. It's probably my favourite. It only takes one
                                parameter and a couple of sine functions, and it generates
                                all sorts of behaviours and amazing images.

                                Essentially, the higher the parameter goes, the more 
                                stable it is. Going close to 0.3 makes it almost become
                                a couple of cycles, going close to 0 makes it wander aimlessly
                                through the space, and the things in between make things
                                in between.";
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
                helptext.text = @"
                                This is not a Hénon map strictly speaking; it's a formulation
                                of that in the shape of differential equations. I don't 
                                understand it very well either, but it looks cool sometimes.";
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
                helptext.text = @"
                                The Hindmarsh-Rose model is normally used to
                                describe the spiking behaviour of neuronal
                                activity. I use it to draw cool-looking tubes.
                                This thing uses 8 parameters that actually have
                                analogues in physical variables inside our brains.
                                I've hidden 4 of them so that we don't end up with
                                a huge number of sliders and analysis-paralysis.";
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
                helptext.text = @"
                                Quadratic maps are different from all the rest here.
                                Instead of describing trajectories, they describe rules
                                for 'point-jumping'. The cool shapes come not from 
                                tracing particles in space, but by the cumulative positions
                                of the particles.

                                These guys take THIRTY parameters and there's no guarantee 
                                that they will be stable nor interesting. Instead of thirty
                                sliders, the way to input those is a 30-character long string
                                where each letter maps to a parameter value.

                                (If you're not seeing anything, move back. They're there.)";
                break;

        }
    }
    
}
