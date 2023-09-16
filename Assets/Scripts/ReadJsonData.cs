using UnityEngine;

public class ReadJsonData : MonoBehaviour
{
    [SerializeField] private SpriteHolder _spriteHolder;
    [SerializeField] private AddProfileSlots _addProfileSlots;
    public DataStruct[] Data;
    
    public void PrepareProfileSlots()
    {
        ReadJson();
        SetSprite();
        _addProfileSlots.Add(0);
    }

    private void ReadJson()
    {
        var targetFile = Resources.Load<TextAsset>(WorldProjectInfo.JsonData);

        Data = AllUrl.CreateFromJSON<DataWrapper>(targetFile.ToString()).data;
    }

    private void SetSprite()
    {
        for (int i = 0; i < Data.Length; i++)
        {
            Data[i].sprite = _spriteHolder.GetSpriteForProfileSlot();
        }
    }
}
