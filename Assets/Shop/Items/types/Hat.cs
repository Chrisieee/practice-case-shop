public class Hat : Cosmetic {
    public Hat() {
        cosmeticType = CosmeticType.hat;
    }

    public override void Equip(Cosmetic cosmetic, Player player, EquipmentManager manager) {
        if (player.hat != null) {
            UnEquip(player, manager);
        }

        player.hat = (Hat)cosmetic;
    }

    public override void UnEquip(Player player, EquipmentManager manager) {
        manager.ChangeState("normal", player.hat);
        player.hat = null;
    }
}