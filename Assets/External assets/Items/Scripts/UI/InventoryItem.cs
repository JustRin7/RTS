using System;
using UnityEngine;

[CreateAssetMenu]
public class InventoryItem : ScriptableObject
{
    public enum ItemUse
    {
        BlueCane = 0,
        GreenPotion = 1
    }


    private readonly Action[] ItemUses =
    {
        () => // ItemUse.BlueCane
        {
            Debug.Log("U are frezed");
        },

        () => // ItemUse.GreenPotion
        {
            Debug.Log("U are healed");
        }
    };


    [SerializeField] private string m_name = "UnnamedItem";
    public string Name => m_name;


    [SerializeField] private string m_description = "Nondescript";
    public string Description => m_description;


    [SerializeField] private ItemUse m_UseType = ItemUse.BlueCane;


    [SerializeField] private int m_UsedCharges = 0;    


    public int Use()
    {
        ItemUses[(int)m_UseType]();
        return m_UsedCharges;
    }



    [SerializeField] private Sprite m_itemSprite;
    public Sprite ItemSprite { get => m_itemSprite; }
}
