using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour
{
    [SerializeField] private GameObject _cardBack;

    void Start()
    {
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
