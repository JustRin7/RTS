using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderUnit : MonoBehaviour
{
    public Unit[] units;

    private void Start()
    {
        foreach(var unit in units)
        {
            unit.MoveOrder(transform.position);
        }
        
    }
}
