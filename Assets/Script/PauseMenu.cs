using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject howToPlayUI;
    public GameObject StageClearUI;
    public GameObject StageLoseUI;
    public GameObject playerCharacter;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
                howToPlayUI.SetActive(false);
            } else
            {
                Pause();
                pauseMenuUI.SetActive(true);
                playerCharacter.GetComponent<CharacterController>().enabled = false;
            }
        }

        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            Pause();
            StageClearUI.SetActive(true);

        }

        if (GameObject.FindGameObjectsWithTag("Player").Length <= 0)
        {
            Pause();
            StageLoseUI.SetActive(true);

        }
    }

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        playerCharacter.GetComponent<CharacterController>().enabled = true;
    }

    void Pause ()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void stageChange()
    {
        Resume();
        StageClearUI.SetActive(false);
    }
}
