using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

public class SaveLoadFavoriteSlots : MonoBehaviour
{
    private FavoriteSlots _favoriteSlots;

    private void Awake()
    {
        _favoriteSlots = GetComponent<FavoriteSlots>();
        LoadList();
    }

    public void SaveList()
    {
        var jsonStr = JsonConvert.SerializeObject(_favoriteSlots.FavoriteList);

        byte[] bytes = Encoding.ASCII.GetBytes(jsonStr);
        var dirPath = Application.persistentDataPath;
        var filename = "text.json";
        var filepath = Path.Combine(dirPath, filename);

        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }

        File.WriteAllBytes(filepath, bytes);
    }

    public void LoadList()
    {
        var dirPath = Application.persistentDataPath;
        var filename = "text.json";
        var filepath = Path.Combine(dirPath, filename);

        if (Directory.Exists(dirPath))
        {
            var jsonStrRead = File.ReadAllText(filepath);
            var deserializedList = JsonConvert.DeserializeObject<List<int>>(jsonStrRead);
            _favoriteSlots.FavoriteList = deserializedList;
        }

    }
}
