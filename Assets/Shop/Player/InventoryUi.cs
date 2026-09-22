using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class InventoryUi : Ui {
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private Transform inventoryContainer;

    [SerializeField] private EquipmentManager equipmentManager;
    private Dictionary<Cosmetic, Button> itemToButton = new Dictionary<Cosmetic, Button>();

    public void FillInventoryUi(List<Cosmetic> inventoryItems) {
        foreach (Transform child in inventoryContainer) { Destroy(child.gameObject); }
        itemToButton = new Dictionary<Cosmetic, Button>();

        foreach (var cosmetic in inventoryItems) {
            var itemObject = Instantiate(itemPrefab, inventoryContainer);
            var button = itemObject.GetComponentInChildren<Button>();

            itemToButton.Add(cosmetic, button);
            equipmentManager.ChangeState("normal", cosmetic);

            ChangeButtonText("normal", cosmetic);
            button.onClick.AddListener(() => equipmentManager.EquipCosmetic(cosmetic));
        }
    }

    public void ChangeButtonText(string state, Cosmetic cosmetic) {
        var button = itemToButton[cosmetic];

        switch (state) {
            case "normal":
                button.GetComponentInChildren<TMP_Text>().text = $"{cosmetic.name} - {cosmetic.cosmeticType}";
                break;
            case "equiped":
                button.GetComponentInChildren<TMP_Text>().text = $"{cosmetic.name} - equiped";
                break;
        }
    }
}