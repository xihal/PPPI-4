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
    public Slider fuelSlider;
    public Slider playerFuelIndicator;



    void Start()
    {
        startButton.onClick.AddListener(OnStartButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
        Instance = this;
    }

    public void UpdateFuel(float currentFuel, float maxFuel)
    {
        fuelSlider.maxValue = maxFuel;
        fuelSlider.value = currentFuel;
    }

    public void UpdateTurboFuel(float currentFuel)
    {
        playerFuelIndicator.value = currentFuel;
    }

    void OnStartButtonClicked()
    {
        if (GameManager.Instance.IsGameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            // Приховуємо меню і запускаємо гру
            gameObject.SetActive(false);
            GameManager.Instance.StartGame(); // Фіксовані параметри
        }
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
