using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemGUI : MonoBehaviour, ISelectHandler
{
    public static event Action<InventoryItem> OnItemSelected;//статическое событие для всех представителей ItemGUI, <> - ключ, по которому передается доп инфа    


    [SerializeField] private InventoryItem m_item;
    public void SetItem(InventoryItem item) { m_item = item; }
    [SerializeField] private Image m_targetImage;


    public void OnSelect(BaseEventData eventData)
    {
        OnItemSelected.Invoke(m_item);
    }


    private void Start()
    {
        m_targetImage.sprite = m_item.ItemSprite;
    }


}
