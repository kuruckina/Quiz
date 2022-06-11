using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class Quiz : MonoBehaviour
{
    public QuestionList[] Questions;
    public TextMeshProUGUI QuestionLabel;
    public TextMeshProUGUI[] AnswersLabel;
    public Button[] AnswerButton;
    private List<object> _qList;
    private int _randQuestion;

    private void Start()
    {
        _qList = new List<object>(Questions);
        QuestionGenerate();
        for (int i = 0; i < AnswerButton.Length; i++)
        {
            AnswerButton[i].onClick.AddListener(AnswersButtonsMethod);
        }
    }

    private void QuestionGenerate()
    {
        _randQuestion = Random.Range(0, _qList.Count);
        QuestionList currentQuestion = _qList[_randQuestion] as QuestionList;
        QuestionLabel.text = currentQuestion.Question;
        for (int i = 0; i < currentQuestion.Answers.Length; i++)
        {
            AnswersLabel[i].text = currentQuestion.Answers[i];
        }
    }

    private void AnswersButtonsMethod()
    {
        _qList.RemoveAt(_randQuestion);
        QuestionGenerate();
    }

    //QuestionLabel.text = Questions[Random.Range(0, Questions.Length)].Question;
}

[System.Serializable]
public class QuestionList
{
    public string Question;
    public string[] Answers = new string [3];
}