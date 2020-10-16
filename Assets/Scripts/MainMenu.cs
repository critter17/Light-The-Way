using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public GameObject startButton;
    public GameObject creditsButton;
    public GameObject quitButton;
    public GameObject credits;

    public void OnStartButton()
    {
        SceneManager.LoadScene("Game Scene", LoadSceneMode.Single);
    }

    public void OnCreditsButton()
    {
        credits.SetActive(true);
        gameObject.SetActive(false);

        EventSystem.current.SetSelectedGameObject(credits.GetComponent<Credits>().backButton);
    }

    public void OnQuitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
