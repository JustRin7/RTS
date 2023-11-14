using UnityEngine;
using UnityEngine.UI;

public class ShowPlayerItems : MonoBehaviour
{
    [SerializeField] private ItemGUI m_ItemGUIPrefab;
    [SerializeField] private Inventory m_PlayerInventory;
    public Inventory GetInventory() => m_PlayerInventory;


    private void OnEnable()//вызывается каждый раз, когда активируется объект
    {
        if(!m_PlayerInventory)
            m_PlayerInventory = GameObject.FindWithTag("MainCamera").GetComponent<Inventory>();

        Inventory.Item[] items = m_PlayerInventory.GetItems();

        for(int i = 0; i < items.Length; i++)
        {
            var itemGUI = Instantiate(m_ItemGUIPrefab, transform);

            itemGUI.transform.position += Vector3.right * 120 * i;
            itemGUI.SetItem(items[i].item);

            if(i == m_PlayerInventory.GetActiveItemID)
            {
                itemGUI.GetComponent<Selectable>().Select();
            }
        }
    }


    private void OnDisable()
    {
        foreach(var itemGUI in GetComponentsInChildren<ItemGUI>())
        {
            Destroy(itemGUI.gameObject);
        }
    }


}
