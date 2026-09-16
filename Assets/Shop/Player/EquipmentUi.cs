using TMPro;

public class EquipmentUi : Ui
{
    public TMP_Text hatLabel;
    public TMP_Text skinLabel;
    public TMP_Text petLabel;

    public void UpdateEquipment(Player player)
    {
        hatLabel.text = player.hat?.name;
        skinLabel.text = player.skin?.name;
        petLabel.text = player.pet?.name;
    }
}
