using UnityEngine;

public class TownHall : MonoBehaviour
{
    [SerializeField] private int _passiveIncome = 1;
    [SerializeField] private float _incomeInterval = 1;
    private Resource _resourceGold;


    private void Awake()
    {
        _resourceGold = FindObjectOfType<PlayerResources>().gold;


    }


    private void Start()
    {
        InvokeRepeating("AwardIncome", _incomeInterval, _incomeInterval);//����� ������� � ��������
        //1 �������� �-��,  2 - ����� ������� ���������, 3 - ������� ��� ���������
    }


    private void AwardIncome()
    {
        _resourceGold.Change(_passiveIncome);

    }


}
