using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class InventoryUi : Ui {
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private Transform inventoryContainer;
    [SerializeField] private Player player;

    [SerializeField] private EquipmentManager equipmentManager;
    private Dictionary<Cosmetic, Button> itemToButton = new();

    protected override void Start() {
        base.Start();

        player.OnCosmeticChanged.AddListener(OnCosmeticChange);
    }

    public void FillInventoryUi(List<Cosmetic> inventoryItems) {
        foreach (Transform child in inventoryContainer) { Destroy(child.gameObject); }
        itemToButton = new Dictionary<Cosmetic, Button>();

        foreach (var cosmetic in inventoryItems) {
            var itemObject = Instantiate(itemPrefab, inventoryContainer);
            var button = itemObject.GetComponentInChildren<Button>();

            itemToButton.Add(cosmetic, button);
            equipmentManager.ChangeState(EquipmentManager.stateEnum.normal, cosmetic);

            ChangeButtonText(EquipmentManager.stateEnum.normal, cosmetic);
            button.onClick.AddListener(() => equipmentManager.EquipCosmetic(cosmetic));
        }
    }

    public void OnCosmeticChange(Cosmetic oldCosmetic, Cosmetic newCosmetic) {
        if (oldCosmetic != null) {
            ChangeButtonText(EquipmentManager.stateEnum.normal, oldCosmetic);
            equipmentManager.ChangeState(EquipmentManager.stateEnum.normal, oldCosmetic);
        }

        if (newCosmetic != null) {
            ChangeButtonText(EquipmentManager.stateEnum.equiped, newCosmetic);
            equipmentManager.ChangeState(EquipmentManager.stateEnum.equiped, newCosmetic);
        }
    }

    public void ChangeButtonText(EquipmentManager.stateEnum state, Cosmetic cosmetic) {
        var button = itemToButton[cosmetic];

        switch (state) {
            case EquipmentManager.stateEnum.normal:
                button.GetComponentInChildren<TMP_Text>().text = $"{cosmetic.name} - {cosmetic.cosmeticType}";
                break;
            case EquipmentManager.stateEnum.equiped:
                button.GetComponentInChildren<TMP_Text>().text = $"{cosmetic.name} - equiped";
                break;
        }
    }
}