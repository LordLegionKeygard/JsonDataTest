using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FavoriteSlots : MonoBehaviour
{
    [Inject] DiContainer _diContainer;
    public List<int> FavoriteList = new List<int>();
    [SerializeField] private GameObject _favoriteSlotPrefab;
    [SerializeField] private Transform _parentTransform;
    [SerializeField] private ReadJsonData _jsonData;
    private SaveLoadFavoriteSlots _saveLoadFavoriteSlots;
    private List<GameObject> FavoriteObjectList = new List<GameObject>();

    private void Awake()
    {
        _saveLoadFavoriteSlots = GetComponent<SaveLoadFavoriteSlots>();
    }

    public void AddNewFavorite(int id)
    {
        FavoriteList.Add(id);
        _saveLoadFavoriteSlots.SaveList();
    }

    public void RemoveFavorite(int id)
    {
        FavoriteList.Remove(id);
        _saveLoadFavoriteSlots.SaveList();
    }

    public void UpdateFavoriteSlots()
    {
        ClearSlots();

        for (int i = 0; i < FavoriteList.Count; i++)
        {
            var slot = _diContainer.InstantiatePrefab(_favoriteSlotPrefab, _parentTransform);
            var k = slot.GetComponent<EmployeeSlot>();

            var idSlot = FavoriteList[i] - 1;
            k.Id = _jsonData.Data[idSlot].id;
            k.FirstName = _jsonData.Data[idSlot].first_name;
            k.LastName = _jsonData.Data[idSlot].last_name;
            k.Email = _jsonData.Data[idSlot].email;
            k.Gender = _jsonData.Data[idSlot].gender;
            k.IpAddress = _jsonData.Data[idSlot].ip_address;
            k.Sprite = _jsonData.Data[idSlot].sprite;
            k.SetView();

            FavoriteObjectList.Add(slot);
        }

    }

    private void ClearSlots()
    {
        for (int i = 0; i < FavoriteObjectList.Count; i++)
        {
            Destroy(FavoriteObjectList[i]);
        }
    }

    public bool IsFavorite(int id)
    {
        for (int i = 0; i < FavoriteList.Count; i++)
        {
            if (FavoriteList[i] == id) return true;
        }
        return false;
    }
}
