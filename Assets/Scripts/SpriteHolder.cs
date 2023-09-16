using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SpriteHolder : MonoBehaviour
{
    [SerializeField] private ReadJsonData _readJsonData;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Sprite _defaultSprite;
    private int _currentSpriteNumber;
    private bool _firstSprite = true;

    private void Awake()
    {
        _currentSpriteNumber = PlayerPrefs.GetInt(WorldProjectInfo.SpriteNumber, -1);
    }

    public void ConvertToSprite(Texture2D texture, int number)
    {
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, 200, 200), new Vector2(0.5f, 0.5f));

        _sprites[number] = sprite;

        if (number == _sprites.Length - 1) _readJsonData.PrepareProfileSlots();
    }

    public Sprite GetSpriteForProfileSlot()
    {
        if(_sprites[0] == null) return _defaultSprite;
        if (_currentSpriteNumber == -1)
        {
            _currentSpriteNumber = Random.Range(0, _sprites.Length);
            PlayerPrefs.SetInt(WorldProjectInfo.SpriteNumber, _currentSpriteNumber);
        }
        else
        {
            if (_firstSprite)
            {
                _firstSprite = false;
                return _sprites[_currentSpriteNumber];
            }
            _currentSpriteNumber++;
            if (_currentSpriteNumber >= _sprites.Length) _currentSpriteNumber = 0;
        }
        _firstSprite = false;
        return _sprites[_currentSpriteNumber];
    }
}
