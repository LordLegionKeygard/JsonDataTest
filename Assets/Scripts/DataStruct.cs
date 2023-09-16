using UnityEngine;

[System.Serializable]
public struct DataWrapper
{
    public DataStruct[] data;
}

[System.Serializable]
public struct DataStruct
{
    public string id;
    public string first_name;
    public string last_name;
    public string email;
    public string gender;
    public string ip_address;
    public Sprite sprite;
}
