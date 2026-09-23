public class Hat : Cosmetic {
    public Hat() {
        cosmeticType = CosmeticType.hat;
    }

    public override void Equip(Player player) {
        player.Hat = this;
    }

    public override void UnEquip(Player player) {
        player.Hat = null;
    }
}