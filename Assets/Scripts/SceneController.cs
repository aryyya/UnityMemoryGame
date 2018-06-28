using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private MemoryCard _originalCard;
    [SerializeField] private Sprite[] _images;

    public const int gridRows = 2;
    public const int gridColumns = 4;
    public const float offsetX = 2.0f;
    public const float offsetY = 2.5f;

    void Start()
    {
        Vector3 startingPosition = _originalCard.transform.position;

        for (int i = 0; i < gridColumns; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                MemoryCard card;
                if (i == 0 && j == 0)
                {
                    card = _originalCard;
                }
                else
                {
                    card = Instantiate(_originalCard) as MemoryCard;
                }

                int id = Random.Range(0, _images.Length);
                card.SetCard(id, _images[id]);

                float positionX = (offsetX * i) + startingPosition.x;
                float positionY = -(offsetY * j) + startingPosition.y;
                card.transform.position = new Vector3(positionX, positionY, startingPosition.z - 1);
            }
        }
    }

    void Update()
    {
    }
}
