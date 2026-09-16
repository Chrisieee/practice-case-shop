using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class InventoryUi : Ui
{
    public GameObject itemPrefab;
    public Transform inventoryContainer;

    public EquipmentManager equipmentManager;

    public void FillInventoryUi(List<Cosmetic> inventoryItems)
    {
        foreach (Transform child in inventoryContainer) { Destroy(child.gameObject); }

        foreach (var cosmetic in inventoryItems)
        {
            GameObject itemObject = Instantiate(itemPrefab, inventoryContainer);
            Button button = itemObject.GetComponentInChildren<Button>();

            button.GetComponentInChildren<TMP_Text>().text = cosmetic.name + " - " + cosmetic.cosmeticType;
            button.onClick.AddListener(() => equipmentManager.EquipCosmetic(cosmetic));
        }
    }
}
