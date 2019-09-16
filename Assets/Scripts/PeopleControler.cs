using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleControler : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 start;
    Vector3 end;
    void Start()
    {
        start = transform.position;
        end = new Vector3(1, 1, 1);
        //IEnumerator enumerator = load();
        //StartCoroutine(enumerator);
        if (Application.platform == RuntimePlatform.Android)
        {
            //  StartCoroutine(getAssetAndroid());

        }
        else if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            // StartCoroutine(getWindowsEditor());
        }
        GameObject game = Resources.Load<GameObject>("8PS01145");
        Instantiate(game);
        game.transform.parent = transform.parent;
        game.transform.position = end;
        //game.transform.localScale = new Vector3(1,1,1);
        Debug.Log("==="+ game.GetComponent<MeshRenderer>().bounds.size.z);

    }
    private IEnumerator getAssetAndroid()
    {
#if UNITY_IOS
       
#elif UNITY_ANDROID

#elif UNITY_EDITOR
    
#endif 

        //WWW www =  WWW.LoadFromCacheOrDownload("http://www.unity.kim/ChinarAssetBundles/chinar/sprite.unity3d",1);
        //  WWW www =  WWW.LoadFromCacheOrDownload("file://D:/Down/DemoUnity/DemoProject/Assets/AssetBundles/assetbundles.unity3d",1);
        //WWW www = new WWW("file://D:/Down/DemoUnity/DemoProject/Assets/AssetBundles/assetbundles.unity3d");
        AssetBundle assetBundle = AssetBundle.LoadFromFile("D:/Down/DemoUnity/DemoProject/AssetBundles/assetbundles.unity3d");
        GameObject sphereHead = assetBundle.LoadAsset("GW") as GameObject;
        Instantiate(sphereHead);
        yield return 0;
        //GameObject.FindGameObjectWithTag

    }

    private IEnumerator getWindowsEditor()
    {
#if UNITY_IOS
       
#elif UNITY_ANDROID

#elif UNITY_EDITOR
    
#endif 

        //WWW www =  WWW.LoadFromCacheOrDownload("http://www.unity.kim/ChinarAssetBundles/chinar/sprite.unity3d",1);
        //  WWW www =  WWW.LoadFromCacheOrDownload("file://D:/Down/DemoUnity/DemoProject/Assets/AssetBundles/assetbundles.unity3d",1);
        //WWW www = new WWW("file://D:/Down/DemoUnity/DemoProject/Assets/AssetBundles/assetbundles.unity3d");
        AssetBundle assetBundle = AssetBundle.LoadFromFile("D:/Down/DemoUnity/DemoProject/AssetBundles/assetbundles.unity3d");
        GameObject sphereHead = assetBundle.LoadAsset("GW") as GameObject;
        Instantiate(sphereHead);
        assetBundle.Unload(false);
        yield return 0;

    }

    private IEnumerator load()
    {
        ResourceRequest request = Resources.LoadAsync("GW");
        yield return request;

        if (request != null)

        {

            if (request.isDone)

            {
                GameObject gameObject = request.asset as GameObject;
                Instantiate(gameObject);
                Debug.Log(gameObject.ToString() + "" + request.asset.ToString());
            }
        }
    }
    // Update is called once per frame
    float ShootSpeed = 1.5f;
    void Update()
    {

        //  transform.position = Vector3.Lerp(start, end, Time.time);


        if (Input.GetKey(KeyCode.A))
        {

            transform.Translate(Vector3.forward * ShootSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {

            transform.Translate(Vector3.right * ShootSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {

            transform.Translate(Vector3.back * ShootSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.W))
        {

            transform.Translate(Vector3.left * ShootSpeed * Time.deltaTime, Space.World);
        }
    }
}
