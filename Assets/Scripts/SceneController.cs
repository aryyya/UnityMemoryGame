using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField] private MemoryCard _originalCard;
    [SerializeField] private Sprite[] _images;
    [SerializeField] private TextMesh _characterSelectedText;
    [SerializeField] private float _revealLength = 1.0f;

    private MemoryCard _firstRevealed;
    private MemoryCard _secondRevealed;

    public bool canReveal
    {
        get
        {
            return _secondRevealed == null;
        }
    }

    public const int gridRows = 4;
    public const int gridColumns = 10;
    public const float offsetX = 1.9f;
    public const float offsetY = 2.0f;

    void Start()
    {
        List<int> idPairs = GetIdPairs(_images.Length);
        Utility.Shuffle(idPairs);

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

                int index = j * gridColumns + i;
                int id = idPairs[index];
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

    private List<int> GetIdPairs(int length)
    {
        List<int> idPairs = new List<int>();
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                idPairs.Add(i);
            }
        }
        return idPairs;
    }

    public void ShowName(string name)
    {
        _characterSelectedText.text = name;
    }

    public void CardRevealed(MemoryCard card)
    {
        if (_firstRevealed == null)
        {
            _firstRevealed = card;
        }
        else
        {
            _secondRevealed = card;
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {
        if (_firstRevealed.id == _secondRevealed.id)
        {

        }
        else
        {
            yield return new WaitForSeconds(_revealLength);
            _firstRevealed.Unreveal();
            _secondRevealed.Unreveal();
        }
        _firstRevealed = null;
        _secondRevealed = null;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
}
