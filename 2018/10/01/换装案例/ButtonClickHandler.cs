using UnityEngine;
using System.Collections;

/// <summary>
/// 按钮分配任务
/// </summary>
public class ButtonClickHandler : MonoBehaviour
{
    private SkinController skinController;
    //为所有按钮分配响应方法
    private void Start()
    {
        skinController = FindObjectOfType<SkinController>();
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<UIButton>().onClick.Add
                (new EventDelegate(OnButtonClick));
        }
    }
    private void OnButtonClick()
    {
        //获取到当前点击到的按钮名
        print("当前点击按钮名字 ： " + UIButton.current.name);
        var arr = UIButton.current.name.Split(' ');
        var function = arr[0];//功能描述
        var goName = arr[1];//资源描述
        switch (function)
        {
            case "Weapons":
                skinController.ChangeWeapon(goName);
                break;
            case "Animation":
                skinController.ChangeAnimation(goName);
                break;
            case "Character":
                skinController.ChangeCharacter(goName);
                break;
            case "Clother":
                skinController.ChangeClother(goName);
                break;
        }

    }
 
}
