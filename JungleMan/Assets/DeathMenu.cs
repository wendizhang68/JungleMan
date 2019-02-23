using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

    public GameObject player;
    public GameObject deathMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < -10)
        {
            deathMenuUI.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
