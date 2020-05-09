using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }
    void GenerateData()
    {
        talkData.Add(100, new string[] {  });
        talkData.Add(200, new string[] { });
 
        
        talkData.Add(10 + 100, new string[] { "" });
        talkData.Add(11 + 200, new string[] { "" });
    }
    public string GetTalk(int id , int talkIndex)
    {

        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10))
            {
               return GetTalk(id - id % 100, talkIndex);
            }
            else
            {
               return GetTalk(id - id % 100, talkIndex);
            }
        }
        
                            
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
}
