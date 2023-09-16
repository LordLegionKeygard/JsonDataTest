using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PanelsToggle : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _titletext;
    [SerializeField] private FavoriteSlots _favoriteSlots;
    [SerializeField] private GameObject[] _scrollView;
    [SerializeField] private Image[] _images;
    public void ScrollViewToggle(bool state)
    {
        _scrollView[0].SetActive(!state);
        _scrollView[1].SetActive(state);
        if (state)
        {
            _images[1].color = Color.white;
            _images[0].color = new Color(1, 1, 1, 0.39f);
            _favoriteSlots.UpdateFavoriteSlots();
            _titletext.text = "|  FAVORITE  |";
        }
        else
        {
            _images[0].color = Color.white;
            _images[1].color = new Color(1, 1, 1, 0.39f);
            _titletext.text = "|  EMPLOYEE DATA  |";
        }
    }
}
