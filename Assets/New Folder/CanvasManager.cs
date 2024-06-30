using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{

    public static CanvasManager cm;
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI timerText;

    public float timerFloat;

    public int TotalTime;
    // Start is called before the first frame update
    void Start()
    {
        if(cm == null) {
            cm = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timerFloat += Time.deltaTime;
        if(timerFloat >= 1) {
            timerFloat = 0;
            TotalTime +=1;
            UpdateTimer();
        }
    }

    public void UpdateTimer() {
        if(timerText != null) {
        timerText.text = "" + TotalTime;

        GameManager.gm.time = TotalTime;
        }
    }

    public void UpdateScore(int score) {
        scoreText.text =  "Score: " + score;
    }

    public void mainmenu() {
        SceneManager.LoadScene("mainmenu");
    }

    public void playagain() {
        SceneManager.LoadScene("SampleScene");
    }

}
