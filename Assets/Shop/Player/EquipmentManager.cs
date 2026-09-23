using UnityEngine;
using System.Collections.Generic;
using Zenject;

public class EquipmentManager : MonoBehaviour {

    [SerializeField] private EquipmentUi ui;
    private Player player;

    private Dictionary<Cosmetic, stateEnum> cosmeticState = new();
    public enum stateEnum { normal, equiped }

    [Inject]
    public void Construct(Player player) {
        this.player = player;
    }

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
    }
}