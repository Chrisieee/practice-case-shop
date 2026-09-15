using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public List<Cosmetic> inventoryCosmetics = new List<Cosmetic>();
    public InventoryUi ui;

    public void AddItem(Cosmetic cosmetic)
    {
        inventoryCosmetics.Add(cosmetic);
        print("item added");
        ui.FillInventoryUi(inventoryCosmetics);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ui.Open();
        }
    }
}
