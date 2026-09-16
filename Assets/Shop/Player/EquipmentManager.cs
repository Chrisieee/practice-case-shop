using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public Player player;
    public EquipmentUi ui;
    public InventoryUi invUi;

    public void EquipCosmetic(Cosmetic cosmetic)
    {
        switch (cosmetic.cosmeticType)
        {
            case Cosmetic.CosmeticType.hat:
                player.hat = null;
                player.hat = (Hat)cosmetic;
                break;
            case Cosmetic.CosmeticType.pet:
                player.pet = null;
                player.pet = (Pet)cosmetic;
                break;
            case Cosmetic.CosmeticType.skin:
                player.skin = null;
                player.skin = (Skin)cosmetic;
                break;
        }

        ui.UpdateEquipment(player);
        // invUi.ChangeButtonText(cosmetic);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ui.Open();
        }
    }
}