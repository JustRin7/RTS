using System;
using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{

    [Serializable]
    public class Item
    {
        public InventoryItem item;
        public int count;
        public void Use()
        {
            count -= item.Use();
        }
    }


    [SerializeField] private List<Item> Items;
    public Item[] GetItems() => Items.ToArray();


    private void Awake()
    {
        ItemGUI.OnItemSelected += (InventoryItem item) =>
        {
            for(int i = 0; i < Items.Count; i++)
            {
                if(Items[i].item == item)
                {
                    m_activeItem = i;
                    break;
                }
            }
        };
    }


    public void Add(InventoryItem item)
    {
        bool contains = false;

        foreach (var i in Items)
        {
            if(i.item == item)
            {
                i.count += 1;
                contains = true;
                break;
            }            
        }

        if (!contains)
        {
            Items.Add(new Item { item = item, count = 1 });
        }

    }


    private void Start()
    {
        if(m_activeItem < 0 || m_activeItem >= Items.Count)
        {
            m_activeItem = 0;
        }
    }


    // Инвентарь игрока
    [SerializeField] private int m_activeItem;
    public int GetActiveItemID => m_activeItem;


    public InventoryItem GetActiveItem() => Items[m_activeItem].item;


}
