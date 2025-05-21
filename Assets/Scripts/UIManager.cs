using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Text resultText;

    void Awake()
    {
        Instance = this;
        resultText.gameObject.SetActive(false);
    }

    public void ShowGameResult(string message)
    {
        resultText.text = message;
        resultText.gameObject.SetActive(true);
    }
}
