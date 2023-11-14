using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(ShowPlayerItems))]
public class ShopItemUse : MonoBehaviour
{
    private void OnEnable()
    {
        GameObject.FindWithTag("MainCamera").GetComponent<ItemUse>().enabled = false;
    }


    private void OnDisable()
    {
        GameObject.FindWithTag("MainCamera").GetComponent<ItemUse>().enabled = true;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            var item = GetComponent<ShowPlayerItems>().GetInventory().GetActiveItem();
            GameObject.FindWithTag("MainCamera").GetComponent<Inventory>().Add(item);
        }
    }


}
