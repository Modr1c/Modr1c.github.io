using UnityEngine;
using System.Collections;

/// <summary>
/// 查找子物体
/// </summary>
public class GlobalTool 
{
    public static GameObject FindChild(Transform trans, string goName)
    {
        Transform child = trans.FindChild(goName);
        if (child != null)
            return child.gameObject;

        GameObject go;
        for (int i = 0; i < trans.childCount; i++)
        {
            child = trans.GetChild(i);
            go = FindChild(child, goName);
            if (go != null)
                return go;
        }
            return null;
    }
}
