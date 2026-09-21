using UnityEngine;

public class EquipmentManager : MonoBehaviour {
    [SerializeField] private Player player;
    [SerializeField] private EquipmentUi ui;

    public void EquipCosmetic(Cosmetic cosmetic) {
        cosmetic.Equip(cosmetic, player);

        ui.UpdateEquipment(player);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            ui.Open();
        }
    }
}