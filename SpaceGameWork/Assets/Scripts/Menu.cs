using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public bool isPaused = false;

    [SerializeField]
    GameObject menu;

	// Use this for initialization
	void Start () {
        if (menu.activeSelf)
            menu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
            GameMenu();  
	}

    void GameMenu()
    {
        if (isPaused)
        {
            menu.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
            
            Cursor.visible = false;
        }
        else
        {
            menu.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
            
            Cursor.visible = true;
        }
    }

    public void GameExit()
    {
        Debug.Log("exit");
        Application.Quit();
    }

    public void GameRestart()
    {
        Debug.Log("restart");
        SceneManager.LoadScene(0);

        GameMenu();
    }
}
