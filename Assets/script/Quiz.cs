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
    /*public Button HelpButton;*/

    public Button RestartButton;

    /*public Color MainColor = Color.white;
    public Color TrueColor = Color.green;
    public Color FalseColor = Color.red;*/

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
        /*HelpButton.onClick.AddListener(HelpButtonMethod);*/
    }

    private void QuestionGenerate()
    {
        for (int i = 0; i < AnswerButton.Length; i++)
        {
            AnswerButton[i].gameObject.GetComponent<Graphic>().color= Color.white;
        }
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
            AnswerButton[index].gameObject.GetComponent<Graphic>().color = Color.green;
            _trueUserAnswers++;
        }
        else
        {
            Debug.Log("Неправильный ответ");
            AnswerButton[index].gameObject.GetComponent<Graphic>().color =  Color.red;
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
        Invoke("QuestionGenerate", 3f);
    }

    private void RestartGameScene()
    {
        SceneManager.LoadScene("Scenes/quiz");
    }

    /*private void HelpButtonMethod()
    {
        List<string> answers = new List<string>(_currentQuestion.Answers);
        int rand = Random.Range(1, answers.Count);
        AnswerButton[rand].gameObject.SetActive(false);
    }*/
}

//ипользовать регионы, и вместо моей логики лучше ScriptableObject
