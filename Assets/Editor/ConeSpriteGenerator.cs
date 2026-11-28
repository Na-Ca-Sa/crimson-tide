using UnityEditor;
using UnityEngine;
using System.IO;

public class Cone : MonoBehaviour
{
    [MenuItem("Tools/Generate Cone Sprite")]
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    static void Generate()
    {
        int size = 512;
        float outerAngle = 60f;
        float soft = 0.08f;

        var tex = new Texture2D(size, size, TextureFormat.RGBA32, false);
        float c = (size - 1) / 2f;
        float half = outerAngle * 0.5f;

        for (int y = 0; y < size; y++)
            for (int x = 0; x < size; x++)
            {
                float dx = (x - c) / c;
                float dy = (y - c) / c;
                float dist = Mathf.Sqrt(dx * dx + dy * dy);
                float ang = Mathf.Abs(Mathf.Atan2(dx,dy)) * Mathf.Rad2Deg;

                float aAngle = 1f - Mathf.InverseLerp(half * (1f - soft), half, ang);
                float aDist = 1f - Mathf.InverseLerp(1f - soft, 1f, dist);
                float a = Mathf.Clamp01(Mathf.Min(aAngle, aDist));
                tex.SetPixel(x, y, new Color(1, 1, 1, a));
            }
        tex.Apply();
        File.WriteAllBytes("Assets/ConeMask.png", tex.EncodeToPNG());
        AssetDatabase.ImportAsset("Assets/ConeMask.png");

    }
}