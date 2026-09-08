using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public List<Item> inventoryItems = new List<Item>();
    public InventoryUi ui;

    public void AddItem(Item item) {
        inventoryItems.Add(item);
        print("item added");
        ui.FillInventoryUi(inventoryItems);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            ui.Open();
        }
    }
}
