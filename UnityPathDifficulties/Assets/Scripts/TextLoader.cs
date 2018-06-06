using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class TextLoader : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start ()
	{
	    var textPath = Path.Combine(Application.streamingAssetsPath, "text.txt");
        Debug.Log(textPath);

        // by UnityWebRequest
        var webRequest = UnityWebRequest.Get(textPath);
	    yield return webRequest.SendWebRequest();

        Debug.Log(webRequest.downloadHandler.text);

        // by WWW
	    var www = new WWW(textPath);
	    yield return www;

	    Debug.Log(www.text);

        // by File
	    var text = File.ReadAllText(textPath);
        Debug.Log(text);

	    text += "\n学Unity更简单！";
        File.WriteAllText(textPath, text);

	    // by WWW
	    www = new WWW(Application.dataPath + "/StreamingAssets/text.txt");
	    yield return www;

	    Debug.Log(www.text);
    }
}
