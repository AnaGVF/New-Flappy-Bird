using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public static GameControl instance;
    public GameObject gameOverText;
    public Text scoreText;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;
    public AudioClip scoreClip;

    private int score = 0;
    private AudioSource audioPlayer;

	// Use this for initialization
	void Awake () {
		if(instance == null) {
            instance = this;
        } else if(instance != this) {
            Destroy(gameObject);
        }
	}

    void Start() {
        audioPlayer = GetComponent<AudioSource>();        
    }

    // Update is called once per frame
    void Update () {

		if(gameOver == true && (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}

    public void BirdScored() {
        if(gameOver) {
            return;      
        }
        score++;
        scoreText.text = "Score: " + score.ToString();
        audioPlayer.clip = scoreClip;
        audioPlayer.Play();
    }

    public void BirdDied() {
        gameOverText.SetActive(true);
        gameOver = true;
    }
}
