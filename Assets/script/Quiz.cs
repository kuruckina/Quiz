using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class Quiz : MonoBehaviour
{
    public QuestionList[] Questions;
    public TextMeshProUGUI QuestionLabel;
    public TextMeshProUGUI[] AnswersLabel;
    public Button[] AnswerButton;
    public TextMeshProUGUI LifesLabel;

    public Button RestartButton;

    private List<object> _qList;
    private QuestionList _currentQuestion;
    private int _randQuestion;
    private int _trueUserAnswers;
    private int _falseUserAnswers;

    private void Start()
    {
        _qList = new List<object>(Questions);
        QuestionGenerate();

        AnswerButton[0].onClick.AddListener(() => AnswersButtonsMethod(0));
        AnswerButton[1].onClick.AddListener(() => AnswersButtonsMethod(1));
        AnswerButton[2].onClick.AddListener(() => AnswersButtonsMethod(2));
        RestartButton.onClick.AddListener(RestartGameScene);
    }

    private void QuestionGenerate()
    {
        if (_qList.Count > 0)
        {
            _randQuestion = Random.Range(0, _qList.Count);
            _currentQuestion = _qList[_randQuestion] as QuestionList;
            QuestionLabel.text = _currentQuestion.Question;
            List<string> answers = new List<string>(_currentQuestion.Answers);
            for (int i = 0; i < _currentQuestion.Answers.Length; i++)
            {
                int rand = Random.Range(0, answers.Count);
                AnswersLabel[i].text = answers[rand];
                answers.RemoveAt(rand);
            }
        }
        else
        {
            RestartButton.gameObject.SetActive(true);
            QuestionLabel.text = $"Верных ответов: {_trueUserAnswers}\n\n Неверных ответов: {_falseUserAnswers}";
            for (int i = 0; i < AnswerButton.Length; i++)
            {
                AnswerButton[i].gameObject.SetActive(false);
            }
        }
    }

    private void AnswersButtonsMethod(int index)
    {
        if (AnswersLabel[index].text.ToString() == _currentQuestion.Answers[0])
        {
            Debug.Log("Правильный ответ");
            _trueUserAnswers++;
        }
        else
        {
            Debug.Log("Неправильный ответ");
            _falseUserAnswers++;
            if (_falseUserAnswers == 1)
            {
                LifesLabel.text = "+ +";
            }
            else if (_falseUserAnswers == 2)
            {
                LifesLabel.text = "+";
            }
            else
            {
                SceneManager.LoadScene("Scenes/end");
            }
            
        }

        _qList.RemoveAt(_randQuestion);
        QuestionGenerate();
    }

    private void RestartGameScene()
    {
        SceneManager.LoadScene("Scenes/quiz");
    }
}

[System.Serializable]
public class QuestionList
{
    public string Question;
    public string[] Answers = new string [3];
}