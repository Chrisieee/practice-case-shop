public class Pet : Cosmetic {
    public Pet() {
        cosmeticType = CosmeticType.pet;
    }

    public override void Equip(Player player) {
        player.Pet = this;
    }

    public override void UnEquip(Player player) {
        player.Pet = null;
    }
}