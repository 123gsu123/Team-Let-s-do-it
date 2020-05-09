using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int ationQuestId;
    public bool Clear;
    public PlayerMove player;

    Dictionary<int, QuestData> questList;
    void Start()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }
    void GenerateData()
    {
        questList.Add(10, new QuestData("사냥하기", new int[] { 100, 200 }));

        questList.Add(20, new QuestData("잡몹잡기", new int[] { 300, 400 }));
    }


    public int GetQuestTalkIndex(int id)
    {
        return questId + ationQuestId;
    }

    public string CheckQuest(int id)
    {
        if(id == questList[questId].npcId[ationQuestId])
          ationQuestId++;

        QuestAiton();

        if (ationQuestId == questList[questId].npcId.Length)
            NextQuest();

        return questList[questId].questName;
    }
    void NextQuest()
    {
        questId += 10;
        ationQuestId = 0;
    }

    void QuestAiton()
    {
        switch (questId)
        {
            case 10:
                if (ationQuestId == 2)
                {
                    player.Quest = true;
                }
                break;
        }
    }
}
