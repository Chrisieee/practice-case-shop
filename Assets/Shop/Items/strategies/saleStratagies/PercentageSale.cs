using UnityEngine;

public class PercentageSale : SalePurchase {
    public PercentageSale(int saleAmount, Cosmetic cosmetic) {
        price = Mathf.RoundToInt(cosmetic.price * (100 - saleAmount) / 100);
    }
}