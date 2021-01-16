using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("INSTANCE IS NULL");

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
        coinsAmount = PlayerPrefs.GetInt("Coins", coinsAmount);
        highScore = PlayerPrefs.GetInt("HighScore", highScore);
        highScoreText.text = $"HighScore: {highScore}";
        coinsText.text = $"Coins: {coinsAmount}";
    }

    [SerializeField] private int coinsAmount;
    [SerializeField] private int highScore;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    public void AddCoins()
    {
        coinsText.text = $"Coins: {++coinsAmount}";
        PlayerPrefs.SetInt("Coins", coinsAmount);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = $"Score: {score}";
        if(score > highScore)
            highScoreText.text = $"HighScore: {score}";
    }

    public void UpdateHighScore(int hs)
    {
        PlayerPrefs.SetInt("HighScore", hs);
    }

}
