using UnityEngine;
using System.Collections.Generic;

public class EquipmentManager : MonoBehaviour {
    [SerializeField] private Player player;
    [SerializeField] private EquipmentUi ui;

    private Dictionary<Cosmetic, stateEnum> cosmeticState = new();
    public enum stateEnum { normal, equiped }

    public void EquipCosmetic(Cosmetic cosmetic) {
        if (CheckState(cosmetic) == stateEnum.equiped) {
            cosmetic.UnEquip(player);
            ui.UpdateEquipment(player);
            return;
        }

        cosmetic.Equip(player);
        ChangeState(stateEnum.equiped, cosmetic);

        ui.UpdateEquipment(player);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            ui.Open();
        }
    }

    public stateEnum CheckState(Cosmetic item) {
        return cosmeticState[item];
    }

    public void ChangeState(stateEnum state, Cosmetic item) {
        cosmeticState[item] = state;
        player.inventory.ui.ChangeButtonText(state, item);
    }
}