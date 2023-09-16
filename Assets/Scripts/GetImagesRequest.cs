using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class GetImagesRequest : MonoBehaviour
{
    [SerializeField] private ReadJsonData _readJsonData;
    private Texture2D[] _textures;
    private SaveTextures _saveTextures;
    private SpriteHolder _spriteHolder;

    private void Awake()
    {
        _saveTextures = GetComponent<SaveTextures>();
        _spriteHolder = GetComponent<SpriteHolder>();
    }

    public async Task GetTexAsync()
    {
        for (int i = 0; i < WorldProjectInfo.ImageLength; i++)
        {
            _textures[i] = await GetImage();
        }
        SaveTextures();
    }

    public async Task<Texture2D> GetImage()
    {
        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(AllUrl.ImageUrl))
        {
            var asyncOperation = request.SendWebRequest();
            while (asyncOperation.isDone == false)
            {
                await Task.Delay(1000);
            }

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
                _readJsonData.PrepareProfileSlots();
                return null;
            }
            else
            {
                return DownloadHandlerTexture.GetContent(request);
            }
        }
    }

    private void SaveTextures()
    {
        for (int i = 0; i < _textures.Length; i++)
        {
            _saveTextures.Save(_textures[i], i);
            _spriteHolder.ConvertToSprite(_textures[i], i);
        }
    }
}


