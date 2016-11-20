using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AttractorScript : MonoBehaviour {
    //public ParticleSystem Emitter;
    //private ParticleSystem m_currentParticleEffect;
    //private Rigidbody rb;
    //public Text debugText;
    public Text debugText2;
    public float par1, par2, par3;
    Hashtable dictionary = new Hashtable();

    // Use this for initialization
    void Start () {
        //rb = GetComponent<Rigidbody>();
        // debugText.text = "";
        //debugText2.text = "";
        FillDictionary();
        
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
        transform.position = CalculateFabrikant(transform.position);
        //debugText.text = transform.position.ToString();
      //  m_currentParticleEffect.SetParticles(ParticleList, m_currentParticleEffect.particleCount);
    }

    


    public Vector3 CalculateLorenz(Vector3 currpos)
    {
        par1 = 10f;
        par2 = 28f;
        par3 = 8.0f / 23.0f;
        float _h = 0.01f;
        float _x0, _y0, _z0, _x1, _y1, _z1 = 0.0f;
        _x0 = currpos.x;
        _y0 = currpos.y;
        _z0 = currpos.z;
        Vector3 result = new Vector3();
        
        _x1 = _x0 + _h * par1 * (_y0 - _x0);
        
        _y1 = _y0 + _h * (_x0 * (par2 - _z0) - _y0);
        _z1 = _z0 + _h * (_x0 * _y0 - par3 * _z0);
        _x0 = _x1;
        _y0 = _y1;
        _z0 = _z1;
        result = new Vector3(_x0, _y0, _z0);
        //debugText2.text = result.ToString();
        

        return result;
    }


    public Vector3 CalculateRoessler(Vector3 currpos)
    {
        par1 = 0.1f;
        par2 = 0.1f;
        par3 = 14f;
        float _h = 0.01f;
        float _x0, _y0, _z0, _x1, _y1, _z1 = 0.0f;
        _x0 = currpos.x;
        _y0 = currpos.y;
        _z0 = currpos.z;
        Vector3 result = new Vector3();

        _x1 = _x0 + _h * (- _y0 - _z0);
        _y1 = _y0 + _h * (_x0 + par1 * _y0);
        _z1 = _z0 + _h * (par2 + _z0 * (_x0 - par3) );
        _x0 = _x1;
        _y0 = _y1;
        _z0 = _z1;
        result = new Vector3(_x0, _y0, _z0);
        //debugText2.text = result.ToString();


        return result;
    }

    public Vector3 CalculateChen(Vector3 currpos)
    {
        par1 = 36f;
        par2 = 20f;
        par3 = 3f;
        float par4 = -15.15f;
        float _h = 0.01f;
        float _x0, _y0, _z0, _x1, _y1, _z1 = 0.0f;
        _x0 = currpos.x;
        _y0 = currpos.y;
        _z0 = currpos.z;
        Vector3 result = new Vector3();

        _x1 = _x0 + _h * par1 * (_y0 - _x0);
        _y1 = _y0 + _h * ( _x0 - _x0 * _z0 + par3 * _y0 + par4);
        _z1 = _z0 + _h * (_x0 * _y0 - par2 * _z0);
        _x0 = _x1;
        _y0 = _y1;
        _z0 = _z1;
        result = new Vector3(_x0, _y0, _z0);
        //debugText2.text = result.ToString();


        return result;
    }

    public Vector3 CalculateFabrikant(Vector3 currpos)
    {
        par1 = 0.87f;
        par2 =1.1f;
        par3 = 3f;
        float par4 = -15.15f;
        float _h = 0.01f;
        float radius = 0.1f;
        float _x0, _y0, _z0, _x1, _y1, _z1 = 0.0f;
        _x0 = currpos.x;
        _y0 = currpos.y;
        _z0 = currpos.z;
        Vector3 result = new Vector3();

        _x1 = _x0 + _h * ( _y0 * _x0 - _y0 + _y0 * _x0 * _x0 + par1 * _x0 );
        _y1 = _y0 + _h * ( 3 * _x0 * _z0 + _x0 - _x0 * _x0 * _x0 + par1 * _y0);
        _z1 = _z0 + _h * ( -2f * _z0 * par2 - 2f * _z0 * _x0 * _y0 );
        _x0 = _x1;
        _y0 = _y1;
        _z0 = _z1;
        result = new Vector3(_x0, _y0, _z0);
        if (result.magnitude > 100f)
        {
            result = new Vector3(Random.Range(-1.0f * radius, 1.0f * radius), Random.Range(-1.0f * radius, 1.0f * radius), Random.Range(-1.0f * radius, 1.0f * radius));
        }
        //debugText2.text = result.ToString();


        return result;
    }

    public Vector3 CalculateThomas(Vector3 currpos)
    {
        par1 = 0.2f;
        par2 = 0.98f;
        par3 = 3f;
        float par4 = -15.15f;
        float _h = 0.1f;
        float _x0, _y0, _z0, _x1, _y1, _z1 = 0.0f;
        _x0 = currpos.x;
        _y0 = currpos.y;
        _z0 = currpos.z;
        Vector3 result = new Vector3();

        _x1 = _x0 + _h * (Mathf.Sin(_y0) - par1 * _x0 );
        _y1 = _y0 + _h * (Mathf.Sin(_z0) - par1 * _y0);
        _z1 = _z0 + _h * (Mathf.Sin(_x0) - par1 * _z0);
        _x0 = _x1;
        _y0 = _y1;
        _z0 = _z1;
        result = new Vector3(_x0, _y0, _z0);
        //debugText2.text = result.ToString();


        return result;
    }

    public Vector3 CalculateHenon(Vector3 currpos)
    {
        par1 = 0.85f;
        par2 = 0.5f;
        par3 = 3f;
        float par4 = -15.15f;
        float _h = 0.01f;
        float _x0, _y0, _z0, _x1, _y1, _z1 = 0.0f;
        _x0 = currpos.x;
        _y0 = currpos.y;
        _z0 = currpos.z;
        Vector3 result = new Vector3();

        _x1 = _x0 + _h * (_y0);
        _y1 = _y0 + _h * (_x0  - _x0 *_z0 - par1 * _y0);
        _z1 = _z0 + _h * (_x0 * _x0 - par2 * _z0 );
        _x0 = _x1;
        _y0 = _y1;
        _z0 = _z1;
        result = new Vector3(_x0, _y0, _z0);
        //debugText2.text = result.ToString();


        return result;
    }

    public Vector3 CalculateMapping(Vector3 currpos)
    {
        float[] pars = new float[30];
        GameObject mark;
        string code = "JKRADSXGDBHIJTQJJDICEJKYSTXFNU";
        pars = DecodePars(code);
        float _x0, _y0, _z0, _x1, _y1, _z1 = 0.0f;
        _x0 = currpos.x;
        _y0 = currpos.y;
        _z0 = currpos.z;
        Vector3 result = new Vector3();

        _x1 = pars[0] + pars[1] * _x0 + pars[2] * _x0 * _x0 + pars[3] * _x0 * _y0 + pars[4] * _x0 * _z0 + pars[5] * _y0 + pars[6] * _y0 * _y0 + pars[7] * _y0 * _z0 + pars[8] * _z0 + pars[9] * _z0 * _z0;
        _y1 = pars[10] + pars[11] * _x0 + pars[12] * _x0 * _x0 + pars[13] * _x0 * _y0 + pars[14] * _x0 * _z0 + pars[15] * _y0 + pars[16] * _y0 * _y0 + pars[17] * _y0 * _z0 + pars[18] * _z0 + pars[19] * _z0 * _z0;
        _z1 = pars[20] + pars[21] * _x0 + pars[22] * _x0 * _x0 + pars[23] * _x0 * _y0 + pars[24] * _x0 * _z0 + pars[25] * _y0 + pars[26] * _y0 * _y0 + pars[27] * _y0 * _z0 + pars[28] * _z0 + pars[29] * _z0 * _z0;
        _x0 = _x1;
        _y0 = _y1;
        _z0 = _z1;
        result = new Vector3(_x0, _y0, _z0);
        mark = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        mark.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        mark.transform.position = result;
        //debugText2.text = result.ToString();


        return result;
    }

    

    private float[] DecodePars(string code)
    {
        float[] decoded = new float[30];
        int i = 0;
        for (i = 0; i < code.Length; i++)
        {
            char current = code[i];
            decoded[i] = (float)dictionary[current.ToString()];

        }

        return decoded;
    }

    private void FillDictionary()
    {
        dictionary.Add("A", -1.2f);
        dictionary.Add("B", -1.1f);
        dictionary.Add("C", -1.0f);
        dictionary.Add("D", -0.9f);
        dictionary.Add("E", -0.8f);
        dictionary.Add("F", -0.7f);
        dictionary.Add("G", -0.6f);
        dictionary.Add("H", -0.5f);
        dictionary.Add("I", -0.4f);
        dictionary.Add("J", -0.3f);
        dictionary.Add("K", -0.2f);
        dictionary.Add("L", -0.1f);
        dictionary.Add("M", 0.0f);
        dictionary.Add("N", 0.1f);
        dictionary.Add("O", 0.2f);
        dictionary.Add("P", 0.3f);
        dictionary.Add("Q", 0.4f);
        dictionary.Add("R", 0.5f);
        dictionary.Add("S", 0.6f);
        dictionary.Add("T", 0.7f);
        dictionary.Add("U", 0.8f);
        dictionary.Add("V", 0.9f);
        dictionary.Add("W", 1.0f);
        dictionary.Add("X", 1.1f);
        dictionary.Add("Y", 1.2f);
        dictionary.Add("Z", 1.3f);


    }

}
