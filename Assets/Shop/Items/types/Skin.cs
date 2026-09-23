public class Skin : Cosmetic {
    public Skin() {
        cosmeticType = CosmeticType.skin;
    }

    public override void Equip(Player player) {
        player.Skin = this;
    }

    public override void UnEquip(Player player) {
        player.Skin = null;
    }
}