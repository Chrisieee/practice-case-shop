public class CosmeticFactory {
    public Cosmetic CreateCosmetic(string type) {
        switch (type) {
            case "hat":
                return new Hat();
            case "pet":
                return new Pet();
            case "skin":
                return new Skin();
            default:
                return null;
        }
    }
}