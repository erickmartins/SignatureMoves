using UnityEngine;
using System.Collections;
using UnityEngine.UI;
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class AttractorGobbler : MonoBehaviour {
    //public ParticleSystem Emitter;
    //private ParticleSystem m_currentParticleEffect;
    //private Rigidbody rb;
    
    public int currentAttractor;
    
    
    
    int counter = 0;
    
    public float par1, par2, par3,par4, par5, par6, par7, par8;
    float _x0, _y0, _z0, _x1, _y1, _z1 = 0.0f;
    float _h;
    float radius;
    Vector3 result = new Vector3();
    float phi, psi;
    
    float[] pars = new float[30];



    public void SwitchAttractor(int attractor)
    {
        currentAttractor = attractor;
        switch (currentAttractor)
        {
            case 0:
                StartLorenz();
                break;
            case 1:
                StartRoessler();
                break;
            
            case 2:
                StartFabrikant();
                break;
            case 3:
                StartThomas();
                break;
            case 4:
                StartHenon();
                break;
            case 5:
                StartHindmarsh();
                break;
            

        }
    }



    public void setpar1(float newval)
    {
        par1 = newval;
    }
    public void setpar2(float newval)
    {
        par2 = newval;
    }
    public void setpar3(float newval)
    {
        par3 = newval;
    }
    public void setpar4(float newval)
    {
        par4 = newval;
    }

    void StartLorenz()
    {
        par1 = 10f;
        par2 = 28f;
        par3 = 8.0f / 3.0f;

    }

    void StartRoessler()
    {
        par1 = 0.1f;
        par2 = 0.1f;
        par3 = 14f;

    }

   
    void StartFabrikant()
    {
        par1 = 0.87f;
        par2 = 1.1f;
        

    }

    void StartThomas()
    {
        par1 = 0.2f;
        

    }

    void StartHenon()
    {
        par1 = 0.85f;
        par2 = 0.5f;
       

    }

    void StartHindmarsh()
    {
        par1 = 1f;
        par2 = 3f;
        par3 = 1f;
        par4 = 5f;

    }


    
    
    // Use this for initialization
    void Start () {
        //rb = GetComponent<Rigidbody>();
        
        
        switch (currentAttractor)
        {
            case 0:
                StartLorenz();
                break;
            case 1:
                StartRoessler();
                break;
            
            case 2:
                StartFabrikant();
                break;
            case 3:
                StartThomas();
                break;
            case 4:
                StartHenon();
                break;
            case 5:
                StartHindmarsh();
                break;
           

        }
        //StartMapping();
        //par1slider = GameObject.Find("par1_slider").GetComponent<Slider>();
        //par2slider = GameObject.Find("par2_slider").GetComponent<Slider>();
        //par3slider = GameObject.Find("par3_slider").GetComponent<Slider>();

    }

    // Update is called once per frame
    void Update () {
        //m_currentParticleEffect = (ParticleSystem)GetComponent("ParticleSystem");
        //ParticleSystem.Particle[] ParticleList = new ParticleSystem.Particle[m_currentParticleEffect.particleCount];
        // m_currentParticleEffect.GetParticles(ParticleList);
        //for (int i = 0; i < ParticleList.Length; ++i)
        // {

        //     ParticleList[i].position = CalculateLorenz(ParticleList[i].position);
        // }
        // par1 = par1slider.value;
        // par2 = par2slider.value;
        //par3 = par3slider.value;
        switch (currentAttractor)
        {
            case 0:
                UpdateLorenz();
                break;
            case 1:
                UpdateRoessler();
                break;
            
            case 2:
                UpdateFabrikant();
                break;
            case 3:
                UpdateThomas();
                break;
            case 4:
                UpdateHenon();
                break;
            case 5:
                UpdateHindmarsh();
                break;
            

        }
        

        //transform.position = CalculateLorenz(transform.position);



        //debugText.text = transform.position.ToString();
      //  m_currentParticleEffect.SetParticles(ParticleList, m_currentParticleEffect.particleCount);
    }

    void UpdateLorenz()
    {
        transform.position = CalculateLorenz(transform.position);
    }

    void UpdateRoessler()
    {
        transform.position = CalculateRoessler(transform.position);
    }

    

    void UpdateFabrikant()
    {
        transform.position = CalculateFabrikant(transform.position);
    }

    void UpdateThomas()
    {
        transform.position = CalculateThomas(transform.position);
    }

    void UpdateHenon()
    {
        transform.position = CalculateHenon(transform.position);
    }

    void UpdateHindmarsh()
    {
        transform.position = CalculateHindmarsh(transform.position);
    }

    


    public Vector3 CalculateLorenz(Vector3 currpos)
    {
        //par1 = 10f;
        //par2 = 28f;
        //par3 = 8.0f / 3.0f;
        _h= 0.01f;
        
        _x1 = 0.0f;
        _y1 = 0.0f;
        _z1 = 0.0f;
        _x0 = currpos.x;
        _y0 = currpos.y;
        _z0 = currpos.z;
        
        
        _x1 = _x0 + _h * par1 * (_y0 - _x0);
        
        _y1 = _y0 + _h * (_x0 * (par2 - _z0) - _y0);
        _z1 = _z0 + _h * (_x0 * _y0 - par3 * _z0);
        _x0 = _x1;
        _y0 = _y1;
        _z0 = _z1;
        result.Set(_x0, _y0, _z0);
        //debugText2.text = result.ToString();
        

        return result;
    }


    public Vector3 CalculateRoessler(Vector3 currpos)
    {
        
        _h = 0.01f;
        _x1 = 0.0f;
        _y1 = 0.0f;
        _z1 = 0.0f;
        _x0 = currpos.x;
        _y0 = currpos.y;
        _z0 = currpos.z;
        

        _x1 = _x0 + _h * (- _z0 - _y0);
        _z1 = _z0 + _h * (_x0 + par1 * _z0);
        _y1 = _y0 + _h * (par2 + _y0 * (_x0 - par3) );
        _x0 = _x1;
        _y0 = _y1;
        _z0 = _z1;
        result.Set(_x0, _y0, _z0);
        radius = 1.0f;
        if (result.magnitude > 1000f)
        {
            result.Set(Random.Range(-1.0f * radius, 1.0f * radius), Random.Range(-1.0f * radius, 1.0f * radius), Random.Range(-1.0f * radius, 1.0f * radius));
        }
        //debugText2.text = result.ToString();


        return result;
    }

   

    public Vector3 CalculateFabrikant(Vector3 currpos)
    {
        
        _h = 0.001f;
        radius = 0.1f;
        _x1 = 0.0f;
        _y1 = 0.0f;
        _z1 = 0.0f;
        _x0 = currpos.x;
        _y0 = currpos.y;
        _z0 = currpos.z;
       

        _x1 = _x0 + _h * ( _y0 * _x0 - _y0 + _y0 * _x0 * _x0 + par1 * _x0 );
        _y1 = _y0 + _h * ( 3 * _x0 * _z0 + _x0 - _x0 * _x0 * _x0 + par1 * _y0);
        _z1 = _z0 + _h * ( -2f * _z0 * par2 - 2f * _z0 * _x0 * _y0 );
        _x0 = _x1;
        _y0 = _y1;
        _z0 = _z1;
        result.Set(_x0, _y0, _z0);
        if (result.magnitude > 100f)
        {
            result.Set(Random.Range(-1.0f * radius, 1.0f * radius), Random.Range(-1.0f * radius, 1.0f * radius), Random.Range(-1.0f * radius, 1.0f * radius));
        }
        //debugText2.text = result.ToString();


        return result;
    }

    public Vector3 CalculateThomas(Vector3 currpos)
    {
        
        _h = 0.1f;
        _x1 = 0.0f;
        _y1 = 0.0f;
        _z1 = 0.0f;
        _x0 = currpos.x;
        _y0 = currpos.y;
        _z0 = currpos.z;
        

        _x1 = _x0 + _h * (Mathf.Sin(_y0) - par1 * _x0 );
        _y1 = _y0 + _h * (Mathf.Sin(_z0) - par1 * _y0);
        _z1 = _z0 + _h * (Mathf.Sin(_x0) - par1 * _z0);
        _x0 = _x1;
        _y0 = _y1;
        _z0 = _z1;
        result.Set(_x0, _y0, _z0);
        //debugText2.text = result.ToString();


        return result;
    }

    public Vector3 CalculateHenon(Vector3 currpos)
    {
        
        _h = 0.1f;
        _x1 = 0.0f;
        _y1 = 0.0f;
        _z1 = 0.0f;
        _x0 = 0.1f*currpos.x;
        _y0 = 0.1f * currpos.y;
        _z0 = 0.1f * currpos.z;
        

        _x1 = _x0 + _h * (_y0);
        _y1 = _y0 + _h * (_x0  - _x0 *_z0 - par1 * _y0);
        _z1 = _z0 + _h * (_x0 * _x0 - par2 * _z0 );
        _x0 = 10f*_x1;
        _y0 = 10f * _y1;
        _z0 = 10f * _z1;
        result.Set(_x0, _y0, _z0);
        radius = 1.0f;
        if (result.magnitude > 1000f)
        {
            result.Set(Random.Range(-1.0f * radius, 1.0f * radius), Random.Range(-1.0f * radius, 1.0f * radius), Random.Range(-1.0f * radius, 1.0f * radius));
        }
        //debugText2.text = result.ToString();


        return result;
    }

    

    public Vector3 CalculateHindmarsh(Vector3 currpos)
    {
        float noiseradius = 0.000001f;
        par5 = 10f;
        par6 = 0.001f;
        par7 = 4f;
        par8 = -8f/5f;
        _h = 0.01f;
        _x1 = 0.0f;
        _y1 = 0.0f;
        _z1 = 0.0f;
        _x0 = currpos.x;
        _y0 = currpos.y;
        _z0 = currpos.z;
        phi = -par1 * _x0 * _x0 * _x0 + par2 * _x0 * _x0;
        psi = par3 - par4 * _x0 * _x0;
        

        _x1 = _x0 + _h * (_y0 + phi - _z0 + par5);
        _y1 = _y0 + _h * (psi - _y0);
        _z1 = _z0 + _h * par6 * (par7 * (_x0 - par8) - _z0 );
        _x0 = _x1+ Random.Range(-1.0f * noiseradius, 1.0f * noiseradius);
        _y0 = _y1+ Random.Range(-1.0f * noiseradius, 1.0f * noiseradius);
        _z0 = _z1+ Random.Range(-1.0f * noiseradius, 1.0f * noiseradius);
        result.Set(_x0, _y0, _z0);
        radius = 1.0f;
        if (result.magnitude > 1000f)
        {
            result.Set(Random.Range(-1.0f * radius, 1.0f * radius), Random.Range(-1.0f * radius, 1.0f * radius), Random.Range(-1.0f * radius, 1.0f * radius));
        }
        //debugText2.text = result.ToString();


        return result;
    }

    

}
