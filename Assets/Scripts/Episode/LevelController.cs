using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class LevelController : SingletonBase<LevelController>
{

    private bool m_IsLevelComplited;

    [SerializeField] private bool setTargetFinish;

    private bool completePosition = false;


    void Update()
    {
        if (!m_IsLevelComplited)
        {
            CheckLevelConditions();
        }
    }


    /// <summary>
    /// проверка условий прохождения лвл
    /// </summary>
    private void CheckLevelConditions()
    {
        if (setTargetFinish == true)
        {
            if (completePosition == true)
            {
                LevelSequenceController.Instance?.FinishCurrentLevel(true);
            }
        }

    }


    public void SetTargetPosition()
    {
        completePosition = true;
    }


    public void UnSetTargetPosition()
    {
        completePosition = false;
    }


}
