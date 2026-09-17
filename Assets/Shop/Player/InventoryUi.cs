using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class InventoryUi : Ui {
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private Transform inventoryContainer;

    [SerializeField] private EquipmentManager equipmentManager;

    public void FillInventoryUi(List<Cosmetic> inventoryItems) {
        foreach (Transform child in inventoryContainer) { Destroy(child.gameObject); }

        foreach (var cosmetic in inventoryItems) {
            var itemObject = Instantiate(itemPrefab, inventoryContainer);
            var button = itemObject.GetComponentInChildren<Button>();

            button.GetComponentInChildren<TMP_Text>().text = cosmetic.name + " - " + cosmetic.cosmeticType;
            button.onClick.AddListener(() => equipmentManager.EquipCosmetic(cosmetic));
        }
    }
}