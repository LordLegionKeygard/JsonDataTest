
using System.Collections.Generic;
using UnityEngine;

public class AllUrl
{
    public static readonly string ImageUrl = "https://picsum.photos/200";


    public static T CreateFromJSON<T>(string jsonString)
    {
        return JsonUtility.FromJson<T>(jsonString);
    }
}
