using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Button StartGameButton;

    void Start()
    {
        StartGameButton.onClick.AddListener(StartGameScene);
    }

    private void StartGameScene()
    {
        SceneManager.LoadScene("Scenes/quiz");
    }
}