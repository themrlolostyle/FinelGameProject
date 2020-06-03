using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _startMenuPanel;
    [SerializeField] private GameObject _inGameMenuPanel;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;

    private Game _game;

    private void OnEnable()
    {
        _game = _gamePanel.GetComponent<Game>();
        _game.WinGame += OnWin;
        _game.LoseGame += OnLose;
    }
    private void OnDisable()
    {
        _game.WinGame -= OnWin;
        _game.LoseGame -= OnLose;
    }

    public void StartGame(int maxStep)
    {
        _gamePanel.GetComponent<PuzzleGenerator>().Generate();
        _game.MaxStep = maxStep;
        _gamePanel.SetActive(true);
        _startMenuPanel.SetActive(false);
    }

    public void Restart()
    {
        Application.LoadLevel("SampleScene");
    }

    public void OnWin()
    {
        _gamePanel.SetActive(false);
        _winPanel.SetActive(true);
    }

    public void OnLose()
    {
        _gamePanel.SetActive(false);
        _losePanel.SetActive(true);
    }
}
