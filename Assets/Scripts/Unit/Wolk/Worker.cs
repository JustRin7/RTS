using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Worker : MonoBehaviour
{
    [SerializeField] private AudioClip changeGoldAudioClip;
    [SerializeField] private AudioClip changeOilAudioClip;
    [SerializeField] private AudioClip changeWoodAudioClip;

    public const int CARRY_GOLD = 1;//несет ли работник золото
    public const int CARRY_OIL = 2;
    public const int CARRY_TREE = 3;
    private int _carry = 0;
    public int Carry => _carry;
    private Vector3 returnPosition;

    private AudioSource changeGoldAudioSource;


    private void Start()
    {
        changeGoldAudioSource = GetComponent<AudioSource>();
    }


    public Vector3 FindNearestTownHall()//нахождение ближайшей ратуши
    {
        var townHalls = FindObjectsOfType<TownHall>();

        if (townHalls.Length == 0) return transform.position;//если ратуши не нашлось, то работник никуда не пойдет

        var moweTarget = townHalls[0].transform.position;

        var distance = Vector3.Distance(transform.position, moweTarget);

        for (int i = 1; i < townHalls.Length; i++)
        {
            var newDistance = Vector3.Distance(transform.position, townHalls[i].transform.position);
            if (distance > newDistance)
            {
                moweTarget = townHalls[i].transform.position;
                distance = newDistance;
            }
        }
        return moweTarget;
    }


    public void MineGoldOrder(Vector3 minePosition)
    {
        _carry = CARRY_GOLD;
        returnPosition = minePosition;
        GetComponent<Unit>().MoveOrder(FindNearestTownHall());
    }


    public void MineOilOrder(Vector3 minePosition)
    {
        _carry = CARRY_OIL;
        returnPosition = minePosition;
        GetComponent<Unit>().MoveOrder(FindNearestTownHall());
    }


    public void MineTreeOrder(Vector3 minePosition)
    {
        _carry = CARRY_TREE;
        returnPosition = minePosition;
        GetComponent<Unit>().MoveOrder(FindNearestTownHall());
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<TownHall>(out var _) && Carry == CARRY_GOLD)
        {            
            _carry = 0;
            GetComponent<Unit>().MoveOrder(returnPosition);
            FindObjectOfType<PlayerResources>().gold.Change(10);
            changeGoldAudioSource.PlayOneShot(changeGoldAudioClip);
        }

        if (other.TryGetComponent<TownHall>(out var _) && Carry == CARRY_OIL)
        {
            _carry = 0;
            GetComponent<Unit>().MoveOrder(returnPosition);
            FindObjectOfType<PlayerResources>().oil.Change(10);
            changeGoldAudioSource.PlayOneShot(changeOilAudioClip);
        }

        if (other.TryGetComponent<TownHall>(out var _) && Carry == CARRY_TREE)
        {
            _carry = 0;
            GetComponent<Unit>().MoveOrder(returnPosition);
            FindObjectOfType<PlayerResources>().wood.Change(10);
            changeGoldAudioSource.PlayOneShot(changeWoodAudioClip);
        }
    }


}
