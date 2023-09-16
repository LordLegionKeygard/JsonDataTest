using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveTextures : MonoBehaviour
{
    public void Save(Texture2D tex, int number)
    {
        byte[] bytes = tex.EncodeToPNG();
        var dirPath = Application.persistentDataPath;
        var filename = number.ToString() + ".png";
        var filepath = Path.Combine(dirPath, filename);

        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }
        
        File.WriteAllBytes(filepath, bytes);
    }
}
