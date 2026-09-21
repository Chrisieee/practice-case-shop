public class Pet : Cosmetic {
    public Pet() {
        cosmeticType = CosmeticType.pet;
    }

    public override void Equip(Cosmetic cosmetic, Player player) {
        player.pet = null;
        player.pet = (Pet)cosmetic;
    }
}