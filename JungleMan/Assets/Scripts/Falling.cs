using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Falling : MonoBehaviour {

    public GameObject player;

	// Update is called once per frame
	void Update () {
		if (player.transform.position.y < 25)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
	}
}
