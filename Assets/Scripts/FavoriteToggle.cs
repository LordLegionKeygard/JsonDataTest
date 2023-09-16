using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class FavoriteToggle : MonoBehaviour
{
    [Inject] private FavoriteSlots _favoriteSlots;
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _starOn;
    [SerializeField] private Sprite _starOff;
    [SerializeField] private bool _isFavoriteSlot;
    private bool _isFavorite;
    private BaseSlot _baseSlot;
    private bool _canUpdateView;

    private void Awake()
    {
        _baseSlot = GetComponent<BaseSlot>();
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);
        UpdateFavoriteView();
        _canUpdateView = true;
    }

    private void OnEnable()
    {
        if(_canUpdateView) UpdateFavoriteView();
    }

    public void UpdateFavoriteView()
    {
        if (_favoriteSlots.IsFavorite(int.Parse(_baseSlot.Id)))
        {
            _isFavorite = true;
            _image.sprite = _starOn;
        }
        else
        {
            _isFavorite = false;
            _image.sprite = _starOff;
        }
    }

    public void ChangeFavorite()
    {
        if (_isFavorite)
        {
            _image.sprite = _starOff;
            _favoriteSlots.RemoveFavorite(int.Parse(_baseSlot.Id));
        }
        else
        {
            _image.sprite = _starOn;
            _favoriteSlots.AddNewFavorite(int.Parse(_baseSlot.Id));
        }
        _isFavorite = !_isFavorite;

        if (_isFavoriteSlot) _favoriteSlots.UpdateFavoriteSlots();
    }
}
