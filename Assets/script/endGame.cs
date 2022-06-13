using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour
{
    public Button RestartGameButton;

    void Start()
    {
        RestartGameButton.onClick.AddListener(RestartGameScene);
    }

    private void RestartGameScene()
    {
        SceneManager.LoadScene("Scenes/quiz");
    }
}