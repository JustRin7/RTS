using UnityEngine;

public class FirstSceneController : MonoBehaviour, IDependency<DialogGetter>
{
    private DialogGetter dialogGetter;
    public void Construct(DialogGetter obj) => dialogGetter = obj;


    [SerializeField] private Resource goldResource;
    [SerializeField] private Resource woodResource;
    [SerializeField] private Resource oilResource;

    private int gold;
    private int wood;
    private int oil;

    [SerializeField] private int setGold;
    [SerializeField] private int setWood;
    [SerializeField] private int setOil;

    [SerializeField] public GameObject finishPosition;
    [SerializeField] private DialogPhrase initialDialog;

    private void Awake()
    {
        finishPosition.SetActive(false);
        goldResource.OnChangeResource += ShowGoldResouce;
        woodResource.OnChangeResource += ShowWoodResouce;
        oilResource.OnChangeResource += ShowOilResouce;
        gameObject.SetActive(false);
    }


    void Update()
    {
        if (gold >= setGold && wood >= setWood && oil >= setOil)
        {
            dialogGetter.GetDialog(initialDialog);
            finishPosition.SetActive(true);
        }
    }


    private void OnDestroy()
    {
        goldResource.OnChangeResource -= ShowGoldResouce;
        woodResource.OnChangeResource -= ShowWoodResouce;
        oilResource.OnChangeResource -= ShowOilResouce;
    }

    private void ShowGoldResouce(int resouceValue)
    {
        gold = resouceValue;
    }


    private void ShowWoodResouce(int resouceValue)
    {
        wood = resouceValue;
    }


    private void ShowOilResouce(int resouceValue)
    {
        oil = resouceValue;
    }


}
