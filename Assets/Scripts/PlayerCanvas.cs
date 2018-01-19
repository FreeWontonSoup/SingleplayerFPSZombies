using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCanvas : MonoBehaviour 
{
    public static PlayerCanvas canvas;
    public Text pointsValue;
    public Text scoreValue;
    public Text zombiesLeft;
    public Text countdown;
    public Text roundValue;

    public GameObject buyHeavy08Display;

    void Awake()
    {
        if(canvas == null)
        {
            canvas = this;
        }
        else if(canvas != this)
        {
            Destroy(gameObject);
        }
    }

    public void SetPoints(int amount)
    {
        pointsValue.text = amount.ToString();
    }

    public void SetScore(int amount)
    {
        scoreValue.text = amount.ToString();
    }

    public void SetZombiesLeft(int amount)
    {
        zombiesLeft.text = amount.ToString();
    }

    public void SetCountdown(int amount)
    {
        countdown.text = amount.ToString();
    }

    public void SetRound(int amount)
    {
        roundValue.text = amount.ToString();
    }

    public void SetHeavyActive(bool isActive)
    {
        buyHeavy08Display.SetActive(isActive);
    }

    void Reset()
    {
        pointsValue = GameObject.Find("PointsValue").GetComponent<Text>();
        scoreValue = GameObject.Find("ScoreValue").GetComponent<Text>();
        zombiesLeft = GameObject.Find("ZombiesLeftValue").GetComponent<Text>();
        countdown = GameObject.Find("CountdownValue").GetComponent<Text>();
        roundValue = GameObject.Find("RoundValue").GetComponent<Text>();
    }
}
