using UnityEngine;
using System;

public class Resource : MonoBehaviour
{
    public event Action<int> OnChangeResource;
    [SerializeField] private int _amount;

    private void Start()
    {
        OnChangeResource(_amount);
    }

    public void Change(int change)
    {
        _amount += change;
        OnChangeResource(_amount);
    }
}
