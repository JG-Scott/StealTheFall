using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticleHandler : MonoBehaviour
{

    public ParticleSystem puffSmoke;
    public ParticleSystem giblet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOnPuffSmoke() {
            puffSmoke.Play();
    }

    public void TurnOffPuffSmoke() {
            puffSmoke.Stop();
    }
    public void GibletExplosion() {
        GetComponent<SpriteRenderer>().enabled = false;
        giblet.Play();
    }
    
}
