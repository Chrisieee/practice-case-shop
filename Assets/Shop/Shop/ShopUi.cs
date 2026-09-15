using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System;

public class ShopUi : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform shopContainer;
    public ShopManager shopManager;
    public TMP_Text error;
    [NonSerialized] public Dictionary<Cosmetic, Button> itemToButton = new Dictionary<Cosmetic, Button>();

    void Start()
    {
        HideError();
    }

    public void FillShopUi()
    {
        foreach (var cosmetic in shopManager.catalog.shopCosmetics)
        {
            GameObject buttonObject = Instantiate(buttonPrefab, shopContainer);

            Button button = buttonObject.GetComponentInChildren<Button>();

            itemToButton.Add(cosmetic, button);

            cosmetic.strategy = new NormalPurchase(cosmetic);
            ChangeButtonText("available", cosmetic);

            if (cosmetic.id == 3 || cosmetic.id == 7)
            {
                cosmetic.strategy = new SalePurchase(20, cosmetic);
                ChangeButtonText("sale", cosmetic);
            }

            if (cosmetic.id == 9)
            {
                cosmetic.strategy = new FreePurchase();
                ChangeButtonText("free", cosmetic);
            }

            button.onClick.AddListener(() => cosmetic.Buy(shopManager));
        }
    }

    public void ShowError(string type)
    {
        switch (type)
        {
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

    public void HideError()
    {
        error.alpha = 0;
    }

    public void ChangeButtonText(string state, Cosmetic cosmetic)
    {
        Button button = itemToButton[cosmetic];

        switch (state)
        {
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
