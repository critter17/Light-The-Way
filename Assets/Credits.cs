using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Credits : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject backButton;

    public void OnBackButton()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
        EventSystem.current.SetSelectedGameObject(mainMenu.GetComponent<MainMenu>().creditsButton);
    }
}
