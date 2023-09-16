using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProfileSlot : BaseSlot
{
    [SerializeField] private TextMeshProUGUI _genderText;
    [SerializeField] private TextMeshProUGUI _mailText;
    [SerializeField] private TextMeshProUGUI _ipText;

    public override void SetView()
    {
        base.SetView();
        _genderText.text = Gender;
        _mailText.text = Email;
        _ipText.text = IpAddress;
        ProfileIcon.sprite = Sprite;
    }
}
