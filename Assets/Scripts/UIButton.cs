using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    [SerializeField] private GameObject _targetObject;
    [SerializeField] private string _targetMessage;
    public Color highlightColor = Color.cyan;

    void Start()
    {
    }

    void Update()
    {
    }

    public void OnMouseEnter()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = highlightColor;
        }
    }

    public void OnMouseExit()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = Color.white;
        }
    }

    public void OnMouseDown()
    {
        Scale(+0.1f);
    }

    public void OnMouseUp()
    {
        Scale(-0.1f);
        if (_targetObject != null)
        {
            _targetObject.SendMessage(_targetMessage);
        }
    }

    private void Scale(float percentage)
    {
        float newX = transform.localScale.x + transform.localScale.x * percentage;
        float newY = transform.localScale.y + transform.localScale.y * percentage;
        float newZ = transform.localScale.z + transform.localScale.z * percentage;
        transform.localScale = new Vector3(newX, newY, newZ);
    }
}
