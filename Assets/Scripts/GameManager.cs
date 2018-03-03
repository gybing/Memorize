using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager :MonoBehaviour {

    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    private int time;
    public Text remainingtime;
    public int Time
    {
        get
        {
            return time;
        }

        set
        {
            time = value;
            remainingtime.text = "倒计时：" + Time.ToString() + " s";
        }
    }

    public Text score;
    private int scoring ;
    public int Scoring
    {
        get
        {
            return scoring;
        }

        set
        {
            scoring = value;
            score.text = "得分：" + Scoring.ToString();
        }
    }

    public Text finalscore;

    public Button[] cards;    //16张盖
    public Sprite[] pokersprite;   //16张图
    public Image[] poker;     //16张底

    public int showingcard = 0;

    public List<Button> BTN = new List<Button>();   //选择的按钮,
    public List<string> Name = new List<string>();   //选择的图片名,
    private int removedcards =0;   //清除的卡片数


    void Start()
    {
        Time =5;
        InvokeRepeating("TimeChange", 0f, 1f);        //每秒刷新时间
        
        PlacePoker(poker, pokersprite);
    }

    //倒计时
    public GameObject Panel;
    private void TimeChange()
    { 
        if(Time !=0)
       {
            Time--;
        }
        if (Time == 0)
        {
            Panel.SetActive(true);                    //显示结束界面
            finalscore.text = "最终得分：" + Scoring.ToString();
        }
        if (removedcards == 16)
            {
                remainingtime.GetComponent<Text>().enabled = false;
                Panel.SetActive(true);                    //显示结束界面
                finalscore.text = "最终得分：" + Scoring.ToString();
            }
    }

    void Update()
    {
        Match();
    }

    void PlacePoker(Image[] poker, Sprite[] pokersprite)   //给卡片附上图片
    {
        //洗牌
        ArrayList tmp = new ArrayList();
        ArrayList num = new ArrayList();
        for (int i = 0; i < 16; i++)
            num.Add(i);
        for (int i = 16; i > 0; i--)
        {
            int index = Random.Range(0, i);
            tmp.Add(num[index]);
            num.Remove(num[index]);
        }
        //置牌
        for (int i = 0; i < 16; i++)
        {
            int dex = (int)tmp[i];
            poker[i].GetComponent<Image>().sprite = pokersprite[dex];
        }
    }

    private void Match()
    {
       
        if ( showingcard == 3)
        {
            Compare(BTN[0],BTN[1]);
            showingcard = 1;

        }if (removedcards == 14 && showingcard==2)   //最后一次比较
        {
            Compare(BTN[0], BTN[1]);
        }
    }
    private void Compare(Button ck1,Button ck2)
    {
        if (Name[0].Equals(Name[1]))
        {
            Scoring++;  //得分
            removedcards += 2;

            ck1.GetComponent<Button>().enabled = false;       //按钮消失
            ck2.GetComponent<Button>().enabled = false;
            ck1.GetComponent<Image>().enabled = false;  //图片隐藏
            ck2.GetComponent<Image>().enabled = false;  

            int index1 = int.Parse(ck1.tag);
            int index2 = int.Parse(ck2.tag);
            poker[index1].GetComponent<Image>().enabled = false;   //图片消失
            poker[index2].GetComponent<Image>().enabled = false;
            Remove();
        }
        else
        {
            Getback(ck1, ck2);
            Remove();
        }
    }
    private void Remove()
    {
        Name.RemoveAt(0);
        Name.RemoveAt(0);
        BTN.RemoveAt(0);
        BTN.RemoveAt(0);
    }
    private void Getback(Button ck1, Button ck2)
    {
        ck1.GetComponent<Button>().enabled = true;  //按钮恢复
        ck1.GetComponent<Image>().enabled = true;       //图片显示

        ck2.GetComponent<Button>().enabled = true;
        ck2.GetComponent<Image>().enabled = true;  

    }
}
