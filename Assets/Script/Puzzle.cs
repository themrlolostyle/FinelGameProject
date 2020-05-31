using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Puzzle : MonoBehaviour
{
    [HideInInspector] public Sprite HideSprite;
    [HideInInspector] public int Index;

    private State _state = State.Close;
    private Image _image;
    private Sprite _visibleSprite;

    public bool NotClickable { get; private set; }

    private void Start()
    {
        _image = GetComponent<Image>();
        _visibleSprite = _image.sprite;
    }

    public void Click()
    {
        switch (_state)
        {
            case State.Close:
                Open();
                break;
            case State.Open:
                Close();
                break;
        }
    }

    private void Open()
    {
        _state = State.Open;
        _image.sprite = HideSprite;
    }

    private void Close()
    {
        _state = State.Close;
        _image.sprite = _visibleSprite;
    }

    public void Found()
    {
        _state = State.Found;
        NotClickable = true;
    }
}
