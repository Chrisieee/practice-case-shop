public class Pet : Cosmetic {
    public Pet() {
        cosmeticType = CosmeticType.pet;
    }

    public override void Equip(Cosmetic cosmetic, Player player, EquipmentManager manager) {
        if (player.pet != null) {
            UnEquip(player, manager);
        }

        player.pet = (Pet)cosmetic;
    }

    public override void UnEquip(Player player, EquipmentManager manager) {
        manager.ChangeState("normal", player.pet);
        player.pet = null;
    }
}