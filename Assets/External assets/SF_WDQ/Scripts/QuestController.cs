using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class QuestController : MonoBehaviour
{
    [SerializeField] private List<Quest> activeQuests;
    [SerializeField] private Text questDisplay;
    [SerializeField] private GameObject questPanel;


    private void Update()
    {
        if(activeQuests.Count > 0)
        {
            questPanel.SetActive(true);
        }
        else
        {
            questPanel.SetActive(false);
        }
    }


    public void Activate(Quest quest)
    {
        if(!activeQuests.Contains(quest))
        {
            activeQuests.Add(quest);
            questDisplay.text = "";

            foreach (var aq in activeQuests)
            {
                questDisplay.text += $"{aq.name}\n";
            }
        }
    }


    public void Dectivate(Quest quest)
    {
        
        if (activeQuests.Contains(quest))
        {
            activeQuests.Remove(quest);
            questDisplay.text = "";

            foreach (var aq in activeQuests)
            {
                questDisplay.text += $"{aq.name}\n";
            }
        }
    }

    
}
