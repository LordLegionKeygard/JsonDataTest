using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SlotImageColor : MonoBehaviour
{
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }
    private void Start()
    {
        if (transform.GetSiblingIndex() % 2 == 0)
        {
            _image.color = Color.white;
        }
    }


}
