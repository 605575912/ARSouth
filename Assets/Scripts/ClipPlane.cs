using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClipPlane : MonoBehaviour
{
    private Material m;
    Vector3 size;
    private Slider slidery;//Slider 对象
    private Slider sliderx;//Slider 对象
    private Slider sliderz;//Slider 对象
    float maxY = -9999;
    float maxX = -9999;
    float maxZ = -9999;
    float minY = 9990;
    float minX = 9990;
    float minZ = 9990;
    float sacale = 0.012f;
    // Start is called before the first frame update
    void Start()
    {
        Shader shader = (Shader.Find("Unlit/CilpShader"));
        if (shader != null)
        {

        }
        slidery = GameObject.Find("SliderY").GetComponent<Slider>();
        sliderx = GameObject.Find("SliderX").GetComponent<Slider>();
        sliderz = GameObject.Find("SliderZ").GetComponent<Slider>();

        foreach (Transform child in gameObject.transform)
        {
            if (child.name.Equals("logo") || child.name.Equals("tree_04"))
            {
                continue;
            }
            MeshRenderer meshRenderer = child.GetComponent<MeshRenderer>();

           // Location location = child.gameObject.AddComponent<Location>();
            if (meshRenderer != null)
            {
                float y = meshRenderer.bounds.size.y / 2 + child.transform.position.y;
                float _y = child.transform.position.y - meshRenderer.bounds.size.y / 2;
                if (!child.name.Equals("LH_43") && !child.name.Equals("B_01") && !child.name.Equals("B_02") && !child.name.Equals("B_03"))
                {
                    float x = meshRenderer.bounds.size.x / 2 + child.transform.position.x;
                    float _x = child.transform.position.x - meshRenderer.bounds.size.x / 2;


                    float z = meshRenderer.bounds.size.z / 2 + child.transform.position.z;
                    float _z = child.transform.position.z - meshRenderer.bounds.size.z / 2;

                    if (minX > _x)
                    {
                        minX = _x;
                    }
                    if (x > maxX)
                    {
                        maxX = x;
                    }
                    if (minZ > _z)
                    {
                        minZ = _z;
                    }
                    if (z > maxZ)
                    {
                        maxZ = z;
                    }

                }
                if (y > maxY)
                {
                    maxY = y;
                }
                if (minY > _y)
                {
                    minY = _y;
                }
                List<Material> materials = new List<Material>();
                meshRenderer.GetSharedMaterials(materials);
                foreach (Material material in materials)
                {


                    material.shader = shader;
                    material.SetFloat("_clip", 1);

                }

            }

        }
        //if (transform.position.y < 0)
        //{
        //    Debug.Log(minY + "---" + maxY + "=@==" + transform.position.y);
        //    minY = minY - transform.position.y;
        //    maxY = maxY - transform.position.y;
        //    transform.position = new Vector3(transform.position.x, 0, transform.position.z);


        //    Debug.Log(minY + "---" + maxY + "=@==" + transform.position.y);
        //}
        //   Debug.Log(minX + "===" + maxX);
        Debug.Log(minZ + "---" + maxZ + "=@==" + transform.position.z);
        //   maxX = maxX + 1 * sacale;
        maxZ = maxZ - 1 * sacale;
        //setX(0);
        //setY(0);

    }
    void OnGUI()
    {


    }
    private float sy = -1;
    private float sx = 0;
    private float sz = 0;
    // Update is called once per frame
    int index = 0;
    void Update()
    {
        if (sy != slidery.value)
        {
            index = 0;
            sy = slidery.value;
        }
        else
        if (sx != sliderx.value)
        {
            index = 1;
            sx = sliderx.value;
        }
        else
        if (sz != sliderz.value)
        {
            index = 2;
            sz = sliderz.value;
        }
        foreach (Transform child in gameObject.transform)
        {

            MeshRenderer meshRenderer = child.GetComponent<MeshRenderer>();
 
            if (meshRenderer != null)
            {
               // location.lat =0;
                List<Material> materials = new List<Material>();
                meshRenderer.GetSharedMaterials(materials);
                foreach (Material material in materials)
                {
                    if (index == 0)
                    {
                        _topVector(slidery.value, material);
                        //float silier = slidery.value;
                        //silier = 1 - silier;

                        //float y = meshRenderer.bounds.size.x / 2 + child.transform.position.x;
                        //float _y = child.transform.position.x - meshRenderer.bounds.size.x / 2;

                        //float _Y = (maxY - minY) * silier + minY;

                        //material.SetVector("_topVector", new Vector4(-y, minY - 0 * sacale, -13 * sacale + transform.position.z, 0));
                        //material.SetVector("_topMaxVector", new Vector4(y, _Y + 0 * sacale, 30f * sacale + transform.position.z, 0));
                    }
                    else
                    if (index == 1)
                    {
                        _topXVector(sliderx.value, material);
                    }
                    else
                    if (index == 2)
                    {
                        _topZVector(sliderz.value, material);
                    }

                }

            }

        }

    }
    private void _topVector(float silier, Material m)
    {
        silier = 1 - silier;
        float _Y = (maxY - minY) * silier + minY;
        m.SetVector("_topVector", new Vector4(-16 * sacale + transform.position.x, minY - 0 * sacale, -13 * sacale + transform.position.z, 0));
        m.SetVector("_topMaxVector", new Vector4(12f * sacale + transform.position.x, _Y + 0 * sacale, 30f * sacale + transform.position.z, 0));
    }
    private void _topXVector(float silier, Material m)
    {
        float _Y = (maxX - minX) * silier + minX;
        m.SetVector("_topVector", new Vector4(minX - 1 * sacale, -0 * sacale + transform.position.y, -13 * sacale + transform.position.z, 0));
        m.SetVector("_topMaxVector", new Vector4(_Y, 0 * sacale + transform.position.y, 30f * sacale + transform.position.z, 0));
    }
    private void _topZVector(float silier, Material m)
    {
        float _Y = (maxZ - minZ) * silier + minZ;
        m.SetVector("_topVector", new Vector4(-16 * sacale + transform.position.x, -0 * sacale + transform.position.y, minZ, 0));
        m.SetVector("_topMaxVector", new Vector4(12f * sacale + transform.position.x, 0 * sacale + transform.position.y, _Y, 0));
    }
}
