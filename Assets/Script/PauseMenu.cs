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
    public AudioSource buttonClick;

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
                playerCharacter.GetComponent<PlayerCombat>().enableAttack();
                Resume();
                howToPlayUI.SetActive(false);
            } else
            {
                playerCharacter.GetComponent<PlayerCombat>().disableAttack();
                playerCharacter.GetComponent<CharacterController>().enabled = false;
                Pause();
                pauseMenuUI.SetActive(true);
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
        playerCharacter.GetComponent<PlayerCombat>().enableAttack();
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

    public void buttonSFX()
    {
        buttonClick.Play();
    }
}
