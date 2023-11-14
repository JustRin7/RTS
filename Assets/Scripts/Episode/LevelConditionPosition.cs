using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelConditionPosition : MonoBehaviour, IDependency<LevelController>
{
    private LevelController LevelController;
    public void Construct(LevelController obj) => LevelController = obj;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //LevelController.completePosition = true;
            LevelController.SetTargetPosition();
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //LevelController.completePosition = true;
            LevelController.UnSetTargetPosition();
        }
    }


}
