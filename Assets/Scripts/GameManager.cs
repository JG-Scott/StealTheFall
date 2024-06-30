using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;


    public AudioSource womp;

    public int score;

    public int time;
    // Start is called before the first frame update
    void Start()
    {
            if(gm == null) {
                gm = this;
                DontDestroyOnLoad(gameObject);
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver() {
        SceneManager.LoadScene("EndScreen");
    }

    public void endGame() {
        // turn off player
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().enabled = false;
        womp.Play();
        StartCoroutine(waitThenEnd());
    }

    public IEnumerator waitThenEnd() {
        yield return new WaitForSeconds(1.5f);
        GameOver();
    }
}
