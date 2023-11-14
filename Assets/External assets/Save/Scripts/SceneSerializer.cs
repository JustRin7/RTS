using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSerializer
{
    [System.Serializable]
    public  class SceneObjectState
    {
        public long InstanceId;
        public string State;

        public static SceneObjectState GetEmptyObject()
        {
            return new SceneObjectState() { InstanceId = long.MaxValue, State = "" };
        }
    }


    
    public List<SceneObjectState> Serialize()
    {
        List<SceneObjectState> serializeObgects = new List<SceneObjectState>();

        MonoBehaviour[] monoBehaviours = GameObject.FindObjectsOfType<MonoBehaviour>();

        for (int i = 0; i < monoBehaviours.Length; i++)
        {
            if (monoBehaviours[i] is ISerializable == false) continue;

            ISerializable serializableEntity = monoBehaviours[i] as ISerializable;
            SceneObjectState objectState = new SceneObjectState();

            //DTO data trust object
            objectState.InstanceId = serializableEntity.InstanceId;
            objectState.State = serializableEntity.Serialize();

            //Debug.Log((monoBehaviours[i] as ISerializable).InstanceId + " " + (monoBehaviours[i] as ISerializable).Serialize());

            serializeObgects.Add(objectState);
        }

        return serializeObgects;
    }


    [ContextMenu("Deserialize")]
    public void Deserialize(List<SceneObjectState> sceneObjectStates)
    {
        MonoBehaviour[] monoBehaviours = GameObject.FindObjectsOfType<MonoBehaviour>();

        for (int i = 0; i < monoBehaviours.Length; i++)
        {
            if (monoBehaviours[i] is ISerializable == false) continue;

            ISerializable serializableEntity = monoBehaviours[i] as ISerializable;

            SceneObjectState sceneObjectState = FindObjectState(sceneObjectStates, serializableEntity.InstanceId);

            if(sceneObjectState == null)
            {
                Debug.LogWarning("sceneObjectState is null");
                continue;
            }

            serializableEntity.Deserialize(sceneObjectState.State);
        }
    }


    private SceneObjectState FindObjectState(List<SceneObjectState> sceneObjectStates, long id)
    {
        for (int i = 0; i < sceneObjectStates.Count; i++)
        {
            if (id == sceneObjectStates[i].InstanceId)
                return sceneObjectStates[i];
        }
        return SceneObjectState.GetEmptyObject();
    }


}
