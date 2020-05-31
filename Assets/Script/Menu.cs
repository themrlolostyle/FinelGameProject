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

    private void OnEnable()
    {
        _gamePanel.GetComponent<Game>().WinGame += Win;
        _gamePanel.GetComponent<Game>().LoseGame += Lose;
    }
    private void OnDisable()
    {
        _gamePanel.GetComponent<Game>().WinGame -= Win;
        _gamePanel.GetComponent<Game>().LoseGame -= Lose;
    }

    public void StartGame(int maxStep)
    {
        _gamePanel.GetComponent<PuzzleGeneration>().Generate();
        _gamePanel.GetComponent<Game>().MaxStep = maxStep;
        _gamePanel.SetActive(true);
        _startMenuPanel.SetActive(false);
    }

    public void Restart()
    {
        Application.LoadLevel("SampleScene");
    }

    public void Win()
    {
        _gamePanel.SetActive(false);
        _winPanel.SetActive(true);
    }

    public void Lose()
    {
        _gamePanel.SetActive(false);
        _losePanel.SetActive(true);
    }
}
