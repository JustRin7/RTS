using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour, ISelectable, IDependency<UnitSelector>
{
    private UnitSelector unitSelector;
    public void Construct(UnitSelector obj) => unitSelector = obj;



    private NavMeshAgent _agent;


    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public void MoveOrder(Vector3 targetPosition)
    {
        _agent.SetDestination(targetPosition);
    }


    private void OnDestroy()
    {
        unitSelector.DeSelected();
    }


    // ** //


    private void OnTriggerEnter(Collider other)
    {
        TryInteraction(other);
    }


    private void TryInteraction(Collider other)
    {
        InteractableItemBase item = other.GetComponent<InteractableItemBase>();
        if(item != null)
        {
            if (item.CanInteract(other))
            {
                Debug.Log("Вошли в триггер");
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        InteractableItemBase item = other.GetComponent<InteractableItemBase>();
        if(item != null)
        {
            Debug.Log("Вышли из триггера");
        }
    }


}
