using TMPro;
using UnityEngine;

public class EquipmentUi : Ui {
    [SerializeField] private TMP_Text hatLabel;
    [SerializeField] private TMP_Text skinLabel;
    [SerializeField] private TMP_Text petLabel;

    public void UpdateEquipment(Player player) {
        hatLabel.text = player.hat?.name ?? "none";
        skinLabel.text = player.skin?.name ?? "none";
        petLabel.text = player.pet?.name ?? "none";
    }
}
