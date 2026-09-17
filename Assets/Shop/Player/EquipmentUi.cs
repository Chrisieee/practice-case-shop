using TMPro;

public class EquipmentUi : Ui {
    private TMP_Text hatLabel;
    private TMP_Text skinLabel;
    private TMP_Text petLabel;

    public void UpdateEquipment(Player player) {
        hatLabel.text = player.hat?.name ?? "none";
        skinLabel.text = player.skin?.name ?? "none";
        petLabel.text = player.pet?.name ?? "none";
    }
}
