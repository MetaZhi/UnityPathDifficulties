using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
    public RawImage image1;
    public RawImage image2;
    public RawImage image3;

    IEnumerator Start ()
	{
	    var path = Path.Combine(Application.streamingAssetsPath, "image.png");
        Debug.Log(path);

        // by UnityWebRequest
        var webRequest = UnityWebRequestTexture.GetTexture(path);
	    yield return webRequest.SendWebRequest();

	    image1.texture = (webRequest.downloadHandler as DownloadHandlerTexture).texture;

        // by WWW
	    var www = new WWW(path);
	    yield return www;
	    image2.texture = www.texture;

        // by File
	    var bytes = File.ReadAllBytes(path);
        Texture2D tex = new Texture2D(1,1);
        tex.LoadImage(bytes);
        tex.Apply();

	    image3.texture = tex;
	}
}
