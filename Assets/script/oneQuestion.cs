using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneQuestion : MonoBehaviour
{
    [SerializeField]
    private Questions question; // 1

    private void OnMouseDown() // 2
    {
        Debug.Log(question._question); // 3
        Debug.Log(question.Description); // 3
        Debug.Log(question.Icon.name); // 3
        Debug.Log(question.GoldCost); // 3
        Debug.Log(question.AttackDamage); // 3
    }
}
