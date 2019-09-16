using UnityEngine;
public class LatLng
{
    private double lat0;
    private double lng0;
    public double lat
    {
        get
        {
            return lat0;
        }
        set
        {
            lat0 = value;
        }
    }

    public double lng
    {
        get
        {
            return lng0;
        }
        set
        {
            lng0 = value;
        }
    }
    public string getKey()
    {
        return lat0 + "_" + lng0;
    }
}