using UnityEngine;
using TMPro;
using Zenject;

public class EmployeeSlot : BaseSlot
{
    [SerializeField] private TextMeshProUGUI _mailIpText;
    [Inject] private ShowProfileSlot _showProfileSlot;

    public override void SetView()
    {
        base.SetView();
        _mailIpText.text = Email + "   " + IpAddress;
        ProfileIcon.sprite = Sprite;
    }

    public void OpenProfileSlot()
    {
        _showProfileSlot.SetProfileSlotInfo(int.Parse(Id) - 1);
    }
}
