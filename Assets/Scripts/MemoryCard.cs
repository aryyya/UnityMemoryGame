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
        Debug.Log("Memory card clicked.");
    }
}
