using UnityEngine;

public class PathLog : MonoBehaviour
{
    void Start()
    {
        Debug.Log(Application.dataPath);
        Debug.Log(Application.persistentDataPath);
        Debug.Log(Application.streamingAssetsPath);
        Debug.Log(Application.temporaryCachePath);
    }
}