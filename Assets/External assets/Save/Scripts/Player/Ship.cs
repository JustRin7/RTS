using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : Entity, ISerializable
{

    public float speed;
    public float health;


    private class SerializeState
    {
        public float speed;
        public float health;
        public Vector3 position;
    }







    public long InstanceId
    {
        get
        {
            return EntityId;
        }
    }

    public void Deserialize(string state)
    {
        SerializeState serializeState = JsonUtility.FromJson<SerializeState>(state);

        speed = serializeState.speed;
        health = serializeState.health;
        transform.position = serializeState.position;
    }


    public string Serialize()
    {
        SerializeState serializeState = new SerializeState();

        serializeState.speed = speed;
        serializeState.health = health;
        serializeState.position = transform.position;

        return JsonUtility.ToJson(serializeState);
    }
}
