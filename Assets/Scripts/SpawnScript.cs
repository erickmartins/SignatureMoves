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
    public Text helptext;
    public GameObject gobbler;

    void Start()
    {
        SetupSpawn(numberOfObjects,prefab_common,radius,prefab_mapping);
        
       
    }

    public void SetupSpawn(int num, GameObject prefab, float radius, GameObject prefabmap)
    {
        gobbler.GetComponent<AttractorGobbler>().SwitchAttractor(myDropdown.value);

        Vector3 pos = new Vector3();
        pos.Set(Random.Range(-1.0f * radius, 1.0f * radius), Random.Range(-1.0f * radius, 1.0f * radius), Random.Range(-1.0f * radius, 1.0f * radius));
        gobbler.GetComponent<Transform>().position = pos;
        Object test;
        for (int i = 0; i < 5; i++)
        {

            pos.Set(0f, 0f, 0f);
            test = Instantiate(prefabmap, pos, Quaternion.identity);
            
            allmappers.Add((GameObject)test);
            allmappers[i].GetComponent<AttractorScript>().SwitchAttractor(6);
        }

        for (int i = 0; i < num; i++)
        {

            pos.Set(Random.Range(-1.0f * radius, 1.0f * radius), Random.Range(-1.0f * radius, 1.0f * radius), Random.Range(-1.0f * radius, 1.0f * radius));
            test = Instantiate(prefab, pos, Quaternion.identity);
            allclones.Add((GameObject)test);
            

        }

        if (myDropdown.value < 6)
        {
            
            for (int i = 0; i < 5; i++)
            {
                allmappers[i].SetActive(false);
            }

            switch (myDropdown.value)
            {
                case 0:
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
                    helptext.text = @"
                                The Rabinovich–Fabrikant equations are weird and
                                I'm not sure I understand them any better than 
                                you do.";
                    break;

                case 3:
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
                    helptext.text = @"
                                This is not a Hénon map strictly speaking; it's a formulation
                                of that in the shape of differential equations. I don't 
                                understand it very well either, but it looks cool sometimes.";
                    break;

                case 5:
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
        else
        {

            for (int i = 0; i < num; i++)
            {
               
                allclones[i].GetComponent<MeshRenderer>().enabled = false;
                allclones[i].GetComponent<TrailRenderer>().enabled = false;
                

            }
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
                    
                    pos.Set(Random.Range(-1.0f * radius, 1.0f * radius), Random.Range(-1.0f * radius, 1.0f * radius), Random.Range(-1.0f * radius, 1.0f * radius));
                    if (allclones[i] == null)
                    {
                        test = Instantiate(prefab, pos, Quaternion.identity);
                        allclones[i] = (GameObject)test;
                    }else
                    {
                        allclones[i].GetComponent<Transform>().position = pos;
                    }

                    //Debug.Log(i);
                   // Debug.Log(allclones[i]);
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
        Debug.Log(allclones);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
