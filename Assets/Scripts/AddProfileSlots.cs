using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AddProfileSlots : MonoBehaviour
{
    [Inject] DiContainer _diContainer;
    [SerializeField] private ReadJsonData _jsonData;
    [SerializeField] private Transform _parentTransform;
    [SerializeField] private GameObject _profileSlotPrefab;

    public void Add(int startNumber)
    {
        if(startNumber + 20 > 2000) return;
        for (int i = startNumber; i < startNumber + 20; i++)
        {
            var slot = _diContainer.InstantiatePrefab(_profileSlotPrefab, _parentTransform);
            var k = slot.GetComponent<EmployeeSlot>();

            k.Id = _jsonData.Data[i].id;
            k.FirstName = _jsonData.Data[i].first_name;
            k.LastName = _jsonData.Data[i].last_name;
            k.Email = _jsonData.Data[i].email;
            k.Gender = _jsonData.Data[i].gender;
            k.IpAddress = _jsonData.Data[i].ip_address;
            k.Sprite = _jsonData.Data[i].sprite;
            k.SetView();
        }
    }
}
