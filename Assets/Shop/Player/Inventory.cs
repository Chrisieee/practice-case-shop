using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
    private List<Cosmetic> inventoryCosmetics = new List<Cosmetic>();
    [SerializeField] private InventoryUi ui;

    public void AddItem(Cosmetic cosmetic) {
        inventoryCosmetics.Add(cosmetic);
        print("item added");
        ui.FillInventoryUi(inventoryCosmetics);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.I)) {
            ui.Open();
        }
    }
}
