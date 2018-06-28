using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour
{
    [SerializeField] private GameObject _cardBack;
    [SerializeField] private Sprite _image;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = _image;
    }

    void Update()
    {
    }

    public void OnMouseDown()
    {
        if (_cardBack.activeSelf)
        {
            _cardBack.SetActive(false);
        }
    }
}
