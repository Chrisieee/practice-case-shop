using UnityEngine;

public class AmountSale : SalePurchase {
    public AmountSale(int saleAmount, Cosmetic cosmetic) {
        price = cosmetic.price - saleAmount;
    }
}