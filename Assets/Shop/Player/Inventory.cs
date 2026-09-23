using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class Inventory {
    private List<Cosmetic> inventoryCosmetics = new();
    public UnityEvent<List<Cosmetic>> OnInventoryChanged { get; private set; } = new();

    public void AddItem(Cosmetic cosmetic) {
        inventoryCosmetics.Add(cosmetic);
        OnInventoryChanged.Invoke(inventoryCosmetics);
    }
}
