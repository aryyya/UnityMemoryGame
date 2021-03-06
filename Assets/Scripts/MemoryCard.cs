﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour
{
    [SerializeField] private GameObject _cardBack;
    [SerializeField] private Sprite _image;
    [SerializeField] private SceneController _sceneController;

    private int _id;
    public int id
    {
        get
        {
            return _id;
        }
    }

    void Start()
    {
       // GetComponent<SpriteRenderer>().sprite = _image;
    }

    void Update()
    {
    }

    public void OnMouseDown()
    {
        if (_cardBack.activeSelf && _sceneController.canReveal)
        {
            _cardBack.SetActive(false);
            _sceneController.ShowName(Utility.GetNameWithSpace(GetComponent<SpriteRenderer>().sprite.name));
            _sceneController.CardRevealed(this);
        }
    }

    public void Unreveal()
    {
        _cardBack.SetActive(true);
        _sceneController.ShowName("");
    }

    public void SetCard(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }
}
