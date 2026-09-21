public class Hat : Cosmetic {
    public Hat() {
        cosmeticType = CosmeticType.hat;
    }

    public override void Equip(Cosmetic cosmetic, Player player) {
        player.hat = null;
        player.hat = (Hat)cosmetic;
    }
}