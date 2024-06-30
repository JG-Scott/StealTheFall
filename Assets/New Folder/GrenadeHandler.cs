using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeHandler : MonoBehaviour
{
    public ParticleSystem ps;

    public bool hasExploded = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hasExploded && !ps.isPlaying) {
            GetComponentInParent<GrenadeScript>().destroy();
        }
    }

    public void explode() {
        ps.Play();
        hasExploded = true;
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
