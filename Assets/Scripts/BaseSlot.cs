using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaseSlot : MonoBehaviour
{
    public Sprite Sprite;
    public string Id;
    public string FirstName;
    public string LastName;
    public string Email;
    public string Gender;
    public string IpAddress;
    public Image ProfileIcon;
    [SerializeField] private TextMeshProUGUI _nameText;

    public virtual void SetView()
    {
        _nameText.text = FirstName + " " + LastName;
    }
}
