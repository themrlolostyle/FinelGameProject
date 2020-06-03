using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Game))]
public class PuzzleGenerator : MonoBehaviour
{
    [SerializeField] private Sprite[] _puzzleSprites;

    private Puzzle[] _puzzles;

    public void Generate()
    {
        AddElementToPuzzleArray();

        GetComponent<Game>().PuzzleEqualsCountToWin = (_puzzles.Length / 2);
    }

    private void AddElementToPuzzleArray()
    {
        _puzzles = new Puzzle[transform.childCount];

        for (int i = 0; i < _puzzles.Length; i++)
        {
            _puzzles[i] = transform.GetChild(i).GetComponent<Puzzle>();
        }

        FillingPuzzleArray();
    }

    private void FillingPuzzleArray()
    {
        int index = 0;
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < _puzzles.Length / 2; j++)
            {
                _puzzles[index].HideSprite = _puzzleSprites[j];
                _puzzles[index].Index = j;
                index++;
            }
        }

        GenerationRandomPuzzles();
    }

    private void GenerationRandomPuzzles()
    {
        int randomIndex;
        Sprite puzzleSpriteIndex;
        int puzzleIndexIndex;

        for (int i = 0; i < _puzzles.Length; i++)
        {
            randomIndex = Random.Range(0, _puzzles.Length);

            puzzleSpriteIndex = _puzzles[randomIndex].HideSprite;
            puzzleIndexIndex = _puzzles[randomIndex].Index;

            _puzzles[randomIndex].HideSprite = _puzzles[i].HideSprite;
            _puzzles[randomIndex].Index = _puzzles[i].Index;

            _puzzles[i].HideSprite = puzzleSpriteIndex;
            _puzzles[i].Index = puzzleIndexIndex;
        }

    }
}
