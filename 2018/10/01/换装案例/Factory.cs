using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 工厂类（加载资源）
/// </summary>
public class Factory
{
    //加载资源
    //负责进场景(诞生)
    private string wpPath = "Weapons/wp_";
    private string characterPath = "Prefabs/mon_";
    private string clothPath = "Clother/";
    private Dictionary<string, Object> dic = new Dictionary<string, Object>();

    //加载武器
    public GameObject LoadWeapon(string goName)
    {
        return LoadObj(wpPath + goName);
    }
    //加载角色
    public GameObject LoadCharacter(string goName)
    {
        return LoadObj(characterPath + goName);
    }
    //加载服装图片
    public Texture LoadTexture(string goName)
    {
        return LoadTextureObj(clothPath + goName);
    }
    private GameObject LoadObj(string resourcesName)
    {
        if(!dic.ContainsKey(resourcesName))
        {
            GameObject obj = (GameObject)Resources.Load(resourcesName);
            obj = GameObject.Instantiate(obj);
            obj.name = obj.name.Replace("(Clone)", "");
            dic.Add(goName, obj);
        }
        return (GameObject)dic[resourcesName];
    }
    private Texture LoadTextureObj(string resourcesName)
    {
        if (!dic.ContainsKey(resourcesName))
        {
            Texture go = (Texture)Resources.Load(resourcesName);
            dic.Add(resourcesName, go);
        }
        return (Texture)dic[resourcesName];
    }
}
