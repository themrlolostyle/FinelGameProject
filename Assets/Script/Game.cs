using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Game : MonoBehaviour, IPointerClickHandler
{
    public int MaxStep { private get; set; }

    private Puzzle _firstElement;
    private Puzzle _secondElement;
    private int _clickOnSecondPuzzleCount;

    public int PuzzleEqualsCountToWin { private get; set; }

    public event UnityAction LoseGame;
    public event UnityAction WinGame;

    public void OnPointerClick(PointerEventData eventData)
    {
        var clickElement = eventData.pointerCurrentRaycast.gameObject.GetComponent<Puzzle>();

        ChangeElementState(clickElement);
    }

    private void ChangeElementState(Puzzle puzzle)
    {
        if (puzzle.Interacteble == true)
        {
            return;
        }

        if (FirsElementAdd(puzzle) == true && SecondElementAdd(puzzle) == true)
        {
            Reset();
        }

        FindEqualsPuzzle();
        EndGame();
    }

    public bool FirsElementAdd(Puzzle puzzle)
    {
        if (_firstElement == null)
        {
            _firstElement = puzzle;
            _firstElement.ChangeState();
            return false;
        }
        else if (_firstElement == puzzle && _secondElement == null)
        {
            _firstElement.ChangeState();
            _firstElement = null;
            return false;
        }
        return true;
    }

    private bool SecondElementAdd(Puzzle puzzle)
    {
        if (_secondElement == null)
        {
            _secondElement = puzzle;
            _secondElement.ChangeState();
            _clickOnSecondPuzzleCount++;
            return false;
        }
        return true;
    }

    private void Reset()
    {
        _firstElement.ChangeState();
        _secondElement.ChangeState();
        _firstElement = null;
        _secondElement = null;
    }

    private void FindEqualsPuzzle()
    {
        if (_firstElement != null && _secondElement != null)
        {
            if (_firstElement.Index == _secondElement.Index)
            {
                _firstElement.Found();
                _secondElement.Found();
                _firstElement = null;
                _secondElement = null;

                PuzzleEqualsCountToWin--;
            }
        }
    }

    private void EndGame()
    {
        if (PuzzleEqualsCountToWin == 0)
        {
            WinGame?.Invoke();
        }

        if (_clickOnSecondPuzzleCount >= MaxStep)
        {
            LoseGame?.Invoke();
        }
    }
}
