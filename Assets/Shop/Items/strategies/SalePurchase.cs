using UnityEngine;

public class SalePurchase : IPurchaseStrategy {
    public int price;

    public int GetPrice() {
        return price;
    }
}