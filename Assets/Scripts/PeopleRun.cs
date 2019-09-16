
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class PeopleRun : MonoBehaviour
{



    // Start is called before the first frame update

    LatLng peoplelatLng;
    Hashtable targets = new Hashtable();
    Hashtable objects = new Hashtable();





    void Start()
    {


        peoplelatLng = new LatLng();
        peoplelatLng.lat = 23.181951666666667f;
        peoplelatLng.lng = 113.41667166666667f;

        add(23.181951666666667f, 113.41667166666667f);
        add(23.181896666666667, 113.41678666666667f);
        add(23.18197333333333f, 113.41662333333333);
        //add(23.178791892385668f, 113.42220589197976f);
        //add(23.178685867071817f, 113.42249557054842f);

        // targets.Add(peoplelatLng.getKey(), peoplelatLng);

    }
    private void add(double lat, double lng)
    {
        LatLng latLng = new LatLng();
        latLng.lat = lat;
        latLng.lng = lng;
        targets.Add(latLng.getKey(), latLng);
    }
    private void Awake()
    {

    }

    private float speed = 10;
    private void addObject()
    {
        //System.Random ran = new System.Random();
        //int hsnt = ran.Next(0, 100);
        //double addx = hsnt * 0.000005f;
        //double x = 113.4224016932345f + addx;
        //double y = 23.1786735385415f;
        //double tempx = myx - x;
        //double tempy = myy - y;
        //Debug.Log(camera.transform.position.x);
        //Debug.Log(camera.transform.position.z);

        //if (System.Math.Abs(tempx) < 0.00001 || Math.Abs(tempx) < 0.00001)
        //{
        //    GameObject gameObject0 = Instantiate(people, new Vector3(500, 10, 500), people.transform.rotation, terrain.transform) as GameObject;

        //    //gameObject0.transform.position = new Vector3(500, 10, 500);
        //}


    }

    public void fromAndroidMoveto(String s)
    {

        String[] strs = s.Split(new char[] { '+' });
        if (strs.Length > 1)
        {
            double lat = Convert.ToSingle(strs[0]);
            double lng = Convert.ToSingle(strs[1]);
            peoplelatLng.lat = lat;
            peoplelatLng.lng = lng;
            //getXY();
            updateLocation();
        }

    }
    void OnGUI()
    {

        if (GUI.Button(new Rect(10, 300, 100, 100), "Forward"))
        {
            //Application.Quit();
            System.Random ran = new System.Random();
            int hsnt = ran.Next(0, 100);
            double x = hsnt * 0.000005f;

            double lng = peoplelatLng.lng + x;

            double lat = peoplelatLng.lat;
            fromAndroidMoveto(lat + "+" + lng);

            //addObject();

            //terrain.transform.position = new Vector3(terrain.transform.position.x, 0, terrain.transform.position.z + speed);

        }

        if (GUI.Button(new Rect(10, 400, 100, 100), "Add"))
        {


            updateLocation();

        }

    }


    private void updateLocation()
    {
        foreach (DictionaryEntry entry in targets)
        {


            LatLng latLng = (LatLng)entry.Value;

            double tempy = latLng.lat - peoplelatLng.lat;
            double tempx = latLng.lng - peoplelatLng.lng;
            GameObject game = (GameObject)objects[latLng.getKey()];

            if (System.Math.Abs(tempx) < 0.0005 || Math.Abs(tempy) < 0.0005)
            {
                tempy = tempy * 100000;
                tempx = tempx * 100000;
                Vector3 vector = new Vector3((float)(500 + tempx), 10, (float)(500 + tempy));
                LOG.e((float)(500 + tempx)+"==");
                //Vector3 vector = new Vector3((float)(500 + 20), 0, (float)(500 + 10));
                if (game == null)
                {
                    //game = (GameObject)Instantiate(Resources.Load("664PS1148"));
                     game = (GameObject)Instantiate(Resources.Load("PS01148"));
                    game.transform.parent = transform;
                    game.transform.position = vector;
                    //  game = Instantiate(people, vector, people.transform.rotation, terrain.transform) as GameObject;
                    objects.Add(latLng.getKey(), game);
                }
                else
                {
                    //Debug.Log(latLng.getKey() + "value=1==" + tempy + "==" + peoplelatLng.lat + "==" + peoplelatLng.lng);
                    game.transform.position = vector;
                }
            }
            else
            {

                if (game != null)
                {
                    Destroy(game);
                }
            }

        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}

