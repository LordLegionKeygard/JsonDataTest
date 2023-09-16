using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowProfileSlot : MonoBehaviour
{
    [SerializeField] private ReadJsonData _readJsonData;
    [SerializeField] private ProfileSlot _profileSlot;
    [SerializeField] private GameObject _profileSlotObject;
    public void SetProfileSlotInfo(int number)
    {
        _profileSlot.Id = _readJsonData.Data[number].id;
        _profileSlot.FirstName = _readJsonData.Data[number].first_name;
        _profileSlot.LastName = _readJsonData.Data[number].last_name;
        _profileSlot.Email = _readJsonData.Data[number].email;
        _profileSlot.Gender = _readJsonData.Data[number].gender;
        _profileSlot.IpAddress = _readJsonData.Data[number].ip_address;
        _profileSlot.Sprite = _readJsonData.Data[number].sprite;
        _profileSlot.SetView();
        _profileSlotObject.SetActive(true);
    }
}
