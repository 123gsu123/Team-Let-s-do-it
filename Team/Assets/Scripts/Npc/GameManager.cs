using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public QuestManager questManager;
    public GameObject panel;
    public GameObject scanObject;
    public GameObject[] Hp;

    public Text text;
    public bool isAction;
    public int talkIndex;
    public int hp;
    public int totalHp;


    void Update()
    {
        Health(hp);
    }

    public void HpOneDown(int hp)
    {
        hp--;     
    }
    public void HpOneUp(int hp)
    {
        hp++;
    }

    public void Health(int hp)
    {
        for (int i = 0; i < hp; i++)
        {      
            Hp[i].SetActive(true);
        }
        
        for (int i =totalHp-1; i >= hp; i--)
        {
            Hp[i].SetActive(false);
        }

    }

    public void Action(GameObject scanObj)
    {      
          isAction = true;
          scanObject = scanObj;
          ObjData objData = scanObject.GetComponent<ObjData>();
          Talk(objData.id, objData.isNpc);
          panel.SetActive(isAction);
    }

    void Talk(int id , bool isNpc)
    {
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);

        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            Debug.Log(questManager.CheckQuest(id));
            return;
        }

        if(isNpc)
        {
            text.text = talkData;
        }
        else
        {
            text.text = talkData;
        }
        isAction = true;
        talkIndex++;
    }  
}
