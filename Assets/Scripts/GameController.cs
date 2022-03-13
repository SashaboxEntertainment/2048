using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public static int Points { get; private set; }
    public static bool GameStarted { get; private set; }

    [SerializeField] private TextMeshProUGUI _gameResult;
    [SerializeField] private TextMeshProUGUI _pointsText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        _gameResult.text = "";

        SetPoints(0);
        GameStarted = true;

        Field.Instance.GenerateField();
    }

    public void Win()
    {
        GameStarted = false;
        _gameResult.text = "You Win!";
    }

    public void Lose()
    {
        GameStarted = false;
        _gameResult.text = "You Lose!";
    }

    public void AddPoints(int points)
    {
        SetPoints(Points + points);
    }

    private void SetPoints(int points)
    {
        Points = points;
        _pointsText.text = Points.ToString();
    }
}
