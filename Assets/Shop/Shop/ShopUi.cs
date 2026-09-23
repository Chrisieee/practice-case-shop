using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class ShopUi : MonoBehaviour {
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Transform shopContainer;
    [SerializeField] private ShopManager shopManager;
    [SerializeField] private TMP_Text error;
    private Dictionary<Cosmetic, Button> itemToButton = new();

    void Start() {
        HideError();
    }

    public void FillShopUi(List<Cosmetic> shopCosmetics) {
        foreach (var cosmetic in shopCosmetics) {
            var buttonObject = Instantiate(buttonPrefab, shopContainer);
            var button = buttonObject.GetComponentInChildren<Button>();

            itemToButton.Add(cosmetic, button);

            cosmetic.strategy = new NormalPurchase(cosmetic);
            ChangeButtonText("available", cosmetic);

            if (cosmetic.id == 3) {
                cosmetic.strategy = new PercentageSale(20, cosmetic);
                ChangeButtonText("sale", cosmetic);
            }

            if (cosmetic.id == 7) {
                cosmetic.strategy = new AmountSale(10, cosmetic);
                ChangeButtonText("sale", cosmetic);
            }

            if (cosmetic.id == 9) {
                cosmetic.strategy = new FreePurchase();
                ChangeButtonText("free", cosmetic);
            }

            button.onClick.AddListener(() => cosmetic.Buy(shopManager));
        }
    }

    public void ShowError(string type) {
        switch (type) {
            case "balance":
                error.text = "You don't have enough gems.";
                error.alpha = 1;
                break;
            case "soldout":
                error.text = "This item is sold out.";
                error.alpha = 1;
                break;
            case "owned":
                error.text = "You already own this item.";
                error.alpha = 1;
                break;
        }
    }

    public void HideError() {
        error.alpha = 0;
    }

    public void ChangeButtonText(string state, Cosmetic cosmetic) {
        var button = itemToButton[cosmetic];

        switch (state) {
            case "available":
                button.GetComponentInChildren<TMP_Text>().text = $"{cosmetic.name} - {cosmetic.price} gems";
                break;
            case "soldout":
                button.GetComponentInChildren<TMP_Text>().text = $"{cosmetic.name} - not available";
                break;
            case "owned":
                button.GetComponentInChildren<TMP_Text>().text = $"{cosmetic.name} - owned";
                break;
            case "normal":
                button.GetComponentInChildren<TMP_Text>().text = $"{cosmetic.name} - {cosmetic.price} gems";
                break;
            case "sale":
                button.GetComponentInChildren<TMP_Text>().text = $"{cosmetic.name} - from {cosmetic.price} to {cosmetic.strategy.GetPrice()} gems";
                break;
            case "free":
                button.GetComponentInChildren<TMP_Text>().text = $"{cosmetic.name} - from {cosmetic.price} to free";
                break;
        }
    }
}
