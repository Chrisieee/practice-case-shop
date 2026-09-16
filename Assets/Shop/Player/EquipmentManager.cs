using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public Player player;
    public EquipmentUi ui;

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
                Debug.Log(player.pet);
                break;
            case Cosmetic.CosmeticType.skin:
                player.skin = null;
                player.skin = (Skin)cosmetic;
                Debug.Log(player.skin);
                break;
        }

        ui.UpdateEquipment(cosmetic);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ui.Open();
        }
    }
}