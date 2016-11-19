using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AttractorScript : MonoBehaviour {
    //public ParticleSystem Emitter;
    //private ParticleSystem m_currentParticleEffect;
    //private Rigidbody rb;
    //public Text debugText;
    //public Text debugText2;
    public float a = 10f;
    public float b = 28f;
    public float c = 8.0f / 23.0f;
    private float _h = 0.01f;
    private float _x0, _y0, _z0, _x1, _y1, _z1 = 0.0f;
    // Use this for initialization
    void Start () {
        //rb = GetComponent<Rigidbody>();
       // debugText.text = "";
        //debugText2.text = "";
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
        transform.position = CalculateLorenz(transform.position);
        //debugText.text = transform.position.ToString();
      //  m_currentParticleEffect.SetParticles(ParticleList, m_currentParticleEffect.particleCount);
    }


    public Vector3 CalculateLorenz(Vector3 currpos)
    {
        _x0 = currpos.x;
        _y0 = currpos.y;
        _z0 = currpos.z;
        Vector3 result = new Vector3();
        
        _x1 = _x0 + _h * a * (_y0 - _x0);
        
        _y1 = _y0 + _h * (_x0 * (b - _z0) - _y0);
        _z1 = _z0 + _h * (_x0 * _y0 - c * _z0);
        _x0 = _x1;
        _y0 = _y1;
        _z0 = _z1;
        result = new Vector3(_x0, _y0, _z0);
        //debugText2.text = result.ToString();
        

        return result;
    }
}
