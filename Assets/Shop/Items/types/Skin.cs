public class Skin : Cosmetic {
    public Skin() {
        cosmeticType = CosmeticType.skin;
    }

    public override void Equip(Cosmetic cosmetic, Player player) {
        player.skin = null;
        player.skin = (Skin)cosmetic;
    }
}