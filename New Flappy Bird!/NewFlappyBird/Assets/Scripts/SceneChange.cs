using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

    public int num;

	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown("space")) {
            SceneManager.LoadScene(num);
        }		
	}
}
