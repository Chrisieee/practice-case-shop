using TMPro;
using UnityEngine;

public class EquipmentUi : Ui {
    [SerializeField] private TMP_Text hatLabel;
    [SerializeField] private TMP_Text skinLabel;
    [SerializeField] private TMP_Text petLabel;

    public void UpdateEquipment(Player player) {
        hatLabel.text = player.Hat?.name ?? "none";
        skinLabel.text = player.Skin?.name ?? "none";
        petLabel.text = player.Pet?.name ?? "none";
    }
}
