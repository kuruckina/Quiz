using UnityEngine;
[CreateAssetMenu(fileName = "question", menuName = "Questions")]
public class Questions : ScriptableObject
{
    [SerializeField]
    private string _question;
    [SerializeField]
    private string _answer1;
    [SerializeField]
    private string _answer2;
    [SerializeField]
    private string _answer3;
    [SerializeField]
    private string _rightAnswer;

    public string Question
    {
        get
        {
            return _question;
        }
    }
    
    public string Answer1
    {
        get
        {
            return _answer1;
        }
    }
    public string Answer2
    {
        get
        {
            return _answer2;
        }
    }
    public string Answer3
    {
        get
        {
            return _answer3;
        }
    }
    public string RightAnswer
    {
        get
        {
            return _rightAnswer;
        }
    }

}