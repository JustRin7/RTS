using UnityEngine;
using UnityEngine.UI;

public class UseItem : MonoBehaviour
{
    private InventoryItem m_item;
    public InventoryItem Item => m_item;

    [SerializeField] private Image itemImage;


    public void SetItem(InventoryItem item)
    {
        m_item = item;
        itemImage.sprite = item.ItemSprite;
    }


    private void Awake()
    {
        ItemGUI.OnItemSelected += SetItem;
        SetItem(FindObjectOfType<Inventory>().GetActiveItem());
    }


}
