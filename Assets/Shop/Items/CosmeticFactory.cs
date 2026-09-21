using System;

public class CosmeticFactory {
    public Cosmetic CreateCosmetic(CosmeticData item) {
        Cosmetic cosmetic;

        switch (item.type) {
            case "hat":
                cosmetic = new Hat();
                break;
            case "pet":
                cosmetic = new Pet();
                break;
            case "skin":
                cosmetic = new Skin();
                break;
            default:
                throw new ArgumentException(
                    $"Unknown cosmetic type: {item.type}"
                );
        }

        cosmetic.id = item.id;
        cosmetic.name = item.name;
        cosmetic.price = item.price;

        return cosmetic;
    }
}