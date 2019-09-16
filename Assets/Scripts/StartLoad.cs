using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class StartLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       


    }
    IEnumerator Get()
    {
        var uri = new System.Uri(Path.Combine(Application.streamingAssetsPath, "data.json"));
        UnityWebRequest webRequest = UnityWebRequest.Get("http://www.baidu.com");

        yield return webRequest.SendWebRequest();

        if (webRequest.isHttpError || webRequest.isNetworkError)
            Debug.Log(webRequest.error);
        else
        {
            Debug.Log(webRequest.downloadHandler.text);
        }

    }

    IEnumerator Post()
    {
        WWWForm form = new WWWForm();
        //键值对
        form.AddField("key", "value");
        form.AddField("name", "mafanwei");
        form.AddField("blog", "qwe25878");

        UnityWebRequest webRequest = UnityWebRequest.Post("http://www.baidu.com", form);

        yield return webRequest.SendWebRequest();

        if (webRequest.isHttpError || webRequest.isNetworkError)
            Debug.Log(webRequest.error);
        else
        {
            Debug.Log(webRequest.downloadHandler.text);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
