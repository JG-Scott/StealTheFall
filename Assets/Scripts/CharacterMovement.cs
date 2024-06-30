using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public int charges;

    public bool hasClicked = false;

    public Rigidbody2D rb;

    public GameObject arrow;

    public Vector2 currentMousePosition;

    public Vector2 clickedMousePosition;

    public float timer = 3;


    public float jumpForce;

    public Animator spriteAnimator;

    public Transform playerSprite;

    public int score = 0; 

    public AudioClip chargeClip;

    public AudioClip LaunchClip;

    public AudioClip Explosion;

    public AudioClip collect;

    public AudioSource AS;

    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        currentMousePosition = Input.mousePosition;
        if(Input.GetMouseButtonDown(0) && !hasClicked && charges > 0)    {
            clickedMousePosition = Input.mousePosition;
            hasClicked = true;
            arrow.SetActive(true);
            Time.timeScale = 0.5f;
            charges--;
            if(rb.velocity.x <= 0) {
                spriteAnimator.PlayInFixedTime("rollLeft");
            } else {
                spriteAnimator.PlayInFixedTime("rollRight");
            }
            AS.clip = chargeClip;
            AS.volume = 0.05f;
            AS.Play();
   
        }

            Vector2 directionVector = clickedMousePosition - currentMousePosition;
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, directionVector);
        if(hasClicked && arrow.activeSelf) {

            arrow.transform.rotation = Quaternion.RotateTowards(arrow.transform.rotation, toRotation, 100000000 * Time.deltaTime);


        }

        if(Input.GetMouseButtonUp(0) && hasClicked) {
            playerSprite.rotation = Quaternion.RotateTowards(playerSprite.rotation, toRotation, 100000000 * Time.deltaTime);
            hasClicked = false;
            arrow.SetActive(false);
            rb.velocity = Vector2.zero;
            rb.AddForce(directionVector.normalized* jumpForce, ForceMode2D.Impulse);
            Time.timeScale = 1;
            spriteAnimator.Play("LaunchThenSpin");
            if(rb.velocity.x <= 0) {
                spriteAnimator.SetBool("movingRight", true);
            } else {
                spriteAnimator.SetBool("movingRight", false);
            }
            AS.clip = LaunchClip;
            AS.volume = .05f;
            AS.Play();
        }

        if(hasClicked) {
            timer -= Time.deltaTime;
            if(timer <= 0) {
                //do something
            }
        }
    }


    public void addCharge() {
        charges+=1;
    }

    public void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "leaf") {
            Destroy(col.gameObject);
            score++;
            GameManager.gm.score  = score;
            CanvasManager.cm.UpdateScore(score);
            AS.clip = collect;
            AS.volume = 1f;
            AS.Play();
        } else if(col.tag == "grenade") {
            col.GetComponentInChildren<GrenadeHandler>().explode();
            AS.clip = Explosion;
            AS.volume = 1f;
            AS.Play();
            die();
        }        
    }

    public void die() {

        GetComponentInChildren<PlayerParticleHandler>().GibletExplosion();
        GameManager.gm.endGame();
    }


}
