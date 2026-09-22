public class Skin : Cosmetic {
    public Skin() {
        cosmeticType = CosmeticType.skin;
    }

    public override void Equip(Cosmetic cosmetic, Player player, EquipmentManager manager) {
        if (player.skin != null) {
            UnEquip(player, manager);
        }

        player.skin = (Skin)cosmetic;
    }

    public override void UnEquip(Player player, EquipmentManager manager) {
        manager.ChangeState("normal", player.skin);
        player.skin = null;
    }
}