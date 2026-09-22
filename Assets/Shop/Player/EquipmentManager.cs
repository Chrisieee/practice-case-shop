using UnityEngine;
using System.Collections.Generic;

public class EquipmentManager : MonoBehaviour {
    [SerializeField] private Player player;
    [SerializeField] private EquipmentUi ui;

    private Dictionary<Cosmetic, string> cosmeticState = new Dictionary<Cosmetic, string>();

    public void EquipCosmetic(Cosmetic cosmetic) {
        if (CheckState(cosmetic) == "equiped") {
            cosmetic.UnEquip(player, this);
            ui.UpdateEquipment(player);
            return;
        }

        cosmetic.Equip(cosmetic, player, this);
        ChangeState("equiped", cosmetic);

        ui.UpdateEquipment(player);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            ui.Open();
        }
    }

    public string CheckState(Cosmetic item) {
        return cosmeticState[item] ?? null;
    }

    public void ChangeState(string state, Cosmetic item) {
        cosmeticState[item] = state;
        player.inventory.ui.ChangeButtonText(state, item);
    }
}