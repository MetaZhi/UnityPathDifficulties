using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class Appload
{
    static Appload()
    {
        bool hasKey = PlayerPrefs.HasKey("洪流学堂");
        if (hasKey == false)
        {
            PlayerPrefs.SetInt("洪流学堂", 1);
            WelcomeScreen.ShowWindow();
        }
    }
}

public class WelcomeScreen : EditorWindow
{
    private Texture mSamplesImage;
    private Rect imageRect = new Rect(30f, 90f, 350f, 350f);
    private Rect textRect = new Rect(15f, 15f, 380f, 100f);

    public void OnEnable()
    {
        mSamplesImage = LoadTexture("qrcode.jpg");
    }


    Texture LoadTexture(string name)
    {
        string path = "Assets/Unity-Logs-Viewer/Reporter/Editor/";
        return (Texture)AssetDatabase.LoadAssetAtPath(path + name, typeof(Texture));
    }

    public void OnGUI()
    {
        GUIStyle style = new GUIStyle
        {
            fontSize = 14,
            normal = {textColor = Color.white}
        };

        if (mSamplesImage == null)
        {
            mSamplesImage = LoadTexture("qrcode.jpg");
        }

        GUI.Label(textRect, "欢迎扫一扫关注关注洪流学堂微信公众号\n更多教程持续更新中，让你学Unity更简单！\n这个页面只会显示一次", style);
        GUI.DrawTexture(imageRect, mSamplesImage);
    }

    public static void ShowWindow()
    {
        WelcomeScreen window = GetWindow<WelcomeScreen>(true, "洪流学堂，让你快人几步");
        window.minSize = window.maxSize = new Vector2(410f, 470f);
        DontDestroyOnLoad(window);
    }
}


