using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PointsUi : MonoBehaviour
{
    [SerializeField]Text pointUi;
    private int score = 0;

    public void UpdateScore()
    {
        score++;
        pointUi.text = score.ToString();
    }
}
