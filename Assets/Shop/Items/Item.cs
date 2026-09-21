using System;

public interface IPurchaseStrategy {
    int GetPrice();
}

[Serializable]
public class Cosmetic {
    public int id;
    public string name;
    public int price;

    public IPurchaseStrategy strategy;

    public enum CosmeticType { hat, pet, skin, chest }
    public CosmeticType cosmeticType;

    public void Buy(ShopManager manager) {
        manager.PurchaseItem(this);
    }

    public virtual void Equip(Cosmetic cosmetic, Player player) {

    }
}