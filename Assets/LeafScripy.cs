using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafScripy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "floor") {
            GameManager.gm.endGame();
        }
    }
}
