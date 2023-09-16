using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckScrollPosition : MonoBehaviour
{
    [SerializeField] private AddProfileSlots _addProfileSlots;
    public ScrollRect scrollRect;
    private int _number = 1;

    private void Start()
    {
        Check();
    }

    private void Check()
    {
        if (scrollRect.verticalNormalizedPosition < 0.1f && scrollRect.verticalNormalizedPosition != 0)
        {
            _addProfileSlots.Add(_number * 20);
            _number++;
        }
        Invoke(nameof(Check), 1f);
    }
}
