using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    public float upForce = 200f;
    public AudioClip dieClip;
    public bool alreadyPlayed = false;
    public AudioClip flapClip;

    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;
    private AudioSource audioPlayer;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		if(isDead == false) {
            if(Input.GetMouseButtonDown(0) || Input.GetKeyDown("space")) {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
                audioPlayer.clip = flapClip;
                audioPlayer.Play();
            }
        }
	}

    void OnCollisionEnter2D() {
        rb2d.velocity = Vector2.zero;
        isDead = true;
        anim.SetTrigger("Die");
        GameControl.instance.BirdDied();
        audioPlayer.clip = dieClip;
            if(!alreadyPlayed) {
                audioPlayer.PlayOneShot(dieClip);
                alreadyPlayed = true;
            }
    }
}
