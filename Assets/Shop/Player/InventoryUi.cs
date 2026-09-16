using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System;

public class InventoryUi : Ui
{
    public GameObject itemPrefab;
    public Transform inventoryContainer;

    public EquipmentManager equipmentManager;

    [NonSerialized] public Dictionary<Cosmetic, Button> itemToButton = new Dictionary<Cosmetic, Button>();

    public void FillInventoryUi(List<Cosmetic> inventoryItems)
    {
        foreach (Transform child in inventoryContainer) { Destroy(child.gameObject); }
        itemToButton.Clear();

        foreach (var cosmetic in inventoryItems)
        {
            GameObject itemObject = Instantiate(itemPrefab, inventoryContainer);
            Button button = itemObject.GetComponentInChildren<Button>();
            // itemToButton.Add(cosmetic, button);

            button.GetComponentInChildren<TMP_Text>().text = cosmetic.name + " - " + cosmetic.cosmeticType;
            button.onClick.AddListener(() => equipmentManager.EquipCosmetic(cosmetic));
        }
    }

    // public void ChangeButtonText(Cosmetic cosmetic)
    // {
    //     Button button = itemToButton[cosmetic];
    //     button.GetComponentInChildren<TMP_Text>().text = $"{cosmetic.name} - {cosmetic.cosmeticType} - equiped";
    // }
}
