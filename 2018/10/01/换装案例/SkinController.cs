using UnityEngine;
using System.Collections;

/// <summary>
/// 业务处理类（使用资源）
/// </summary>
public class SkinController : MonoBehaviour
{
    private Factory factory = new Factory();
    private GameObject currentCharacter;
    private GameObject currentWeapon;
    /// <summary>
    /// 更换武器
    /// </summary>
    public void ChangeWeapon(string goName)
    {
      if(currentCharacter!=null)
      {
          //加载武器
          GameObject weapon = factory.LoadWeapon(goName);
          if (currentWeapon != null && currentWeapon.name != weapon.name)
              currentWeapon.SetActive(false);//原来的武器
          //挂载点
          GameObject wpHand = GlobalTool.FindChild(currentCharacter.transform, "wphand");
          //武器显隐、位置、角度
          currentWeapon = weapon;
          currentWeapon.transform.parent = wpHand.transform;
          currentWeapon.transform.localPosition = Vector3.zero;
          currentWeapon.transform.localEulerAngles = new Vector3(0,0,180);
          currentWeapon.SetActive(true);//现在的武器
      }

    }
    /// <summary>
    /// 更换动画
    /// </summary>
    public void ChangeAnimation(string goName)
    {
        if (currentCharacter != null)
            //播放动画
            currentCharacter.GetComponent<Animation>().Play(goName);
    }
    /// <summary>
    /// 更换角色
    /// </summary>
    public void ChangeCharacter(string goName)
    {
        //加载角色
        GameObject character = factory.LoadCharacter(goName);
        if (currentCharacter != null && currentCharacter.name != character.name)
            currentCharacter.SetActive(false);//原来的角色
        //控制角色诞生点，角度,显隐
        character.transform.position = transform.position;
        character.transform.rotation = transform.rotation;
        currentCharacter = character;
        currentCharacter.SetActive(true);//现在的角色
    }
    /// <summary>
    /// 换服装
    /// </summary>
    public void ChangeClother(string goName)
    {
        if(currentCharacter != null)
        {
            //加载服装图片
            Texture cloth = factory.LoadTexture(currentCharacter.name + "_" + goName);
            //换装
            currentCharacter.GetComponentInChildren<SkinnedMeshRenderer>().material.
                mainTexture = cloth;
        }

    }
}
