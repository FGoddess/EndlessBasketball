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
        _coinsAmount = PlayerPrefs.GetInt("Coins", _coinsAmount);
        _highScore = PlayerPrefs.GetInt("HighScore", _highScore);
        _highScoreText.text = $"HighScore: {_highScore}";
        _coinsText.text = $"Coins: {_coinsAmount}";
    }

    [SerializeField] private int _coinsAmount;
    [SerializeField] private int _highScore;
    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;

    public void AddCoins()
    {
        _coinsText.text = $"Coins: {++_coinsAmount}";
        PlayerPrefs.SetInt("Coins", _coinsAmount);
    }

    public void UpdateScore(int score)
    {
        _scoreText.text = $"Score: {score}";
        if(score > _highScore)
            _highScoreText.text = $"HighScore: {score}";
    }

    public void UpdateHighScore(int hs)
    {
        PlayerPrefs.SetInt("HighScore", hs);
    }

}
