using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Click : MonoBehaviour {

   // private Image image;
    public Button btn;
    public new string name;

    private void Start()
    {
        btn = GetComponent<Button>();
    }


    public void Clicked()  //点击事件
    {
        int index = int.Parse(tag); //获取index
        name = GameManager.instance.poker[index].GetComponent<Image>().sprite.name;    //获取贴图名称
        GameManager.instance.Name.Add(name);        //加到List中

        GetComponent<Button>().enabled = false;  //按钮消失
        GetComponent<Image>().enabled = false;  //图片隐藏

        GameManager.instance.BTN.Add(btn);

        GameManager.instance.showingcard++;
    }




}
