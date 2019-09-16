using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOG
{
    static AndroidJavaClass jc;
    static AndroidJavaObject jo;
    public static void e(string msg)
    {
        ShowMessage(msg);
    }
    static void ShowMessage(string msg)
    {
        Debug.Log(msg);
        try {
            if (jc == null)
            {
                jc = new AndroidJavaClass("com.south.ar.ModuleApplication");
            }
            if (jo == null && jc != null)
            {
                jo = jc.GetStatic<AndroidJavaObject>("unity");
            }
            if (jo != null)
            {
                jo.Call("ShowMessage", msg);
            }
        }
        catch (System.Exception e) { }
      

    }

}
