using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class CheckLocalSaveDataImages : MonoBehaviour
{
    private string _fullPath;
    private GetImagesRequest _getImagesRequest;
    private SpriteHolder _spriteConverter;

    private void Awake()
    {
        _getImagesRequest = GetComponent<GetImagesRequest>();
        _spriteConverter = GetComponent<SpriteHolder>();
    }

    private void Start()
    {
        GetImages();
    }

    public void GetImages()
    {
        var dirPath = Application.persistentDataPath;

        for (int i = 0; i < WorldProjectInfo.ImageLength; i++)
        {
            _fullPath = Path.Combine(dirPath, i + ".png");

            if (File.Exists(_fullPath))
            {
                byte[] data = File.ReadAllBytes(_fullPath);

                Texture2D texture = new Texture2D(200, 200);

                texture.LoadImage(data);

                _spriteConverter.ConvertToSprite(texture, i);
            }
            else
            {
                Task task = _getImagesRequest.GetTexAsync();
                return;
            }
        }
    }
}
