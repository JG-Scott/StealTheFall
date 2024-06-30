using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndgameCanvasScript : MonoBehaviour
{
    public TextMeshProUGUI seconds;

    public TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
        seconds.text = "" + GameManager.gm.time;
        score.text  = "" + GameManager.gm.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
