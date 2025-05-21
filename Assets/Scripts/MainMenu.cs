using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance;
    public Button startButton;
    public Button exitButton;

    void Start()
    {
        startButton.onClick.AddListener(OnStartButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
        Instance = this;
    }

    void OnStartButtonClicked()
    {
        // Приховуємо меню і запускаємо гру
        gameObject.SetActive(false);
        GameManager.Instance.StartGame(); // Фіксовані параметри
    }

    void OnExitButtonClicked()
    {
        // Вихід із гри
        Application.Quit();
    }

    public void ViewMenu()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }

    public void ViewStartButton()
    {
        startButton.enabled = !startButton.enabled;
    }
}
