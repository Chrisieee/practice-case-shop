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
    [NonSerialized] public Dictionary<Item, Button> itemToButton = new Dictionary<Item, Button>();

    void Start()
    {
        HideError();
    }

    public void FillShopUi()
    {
        foreach (var item in shopManager.catalog.shopItems)
        {
            GameObject buttonObject = Instantiate(buttonPrefab, shopContainer);

            Button button = buttonObject.GetComponentInChildren<Button>();

            itemToButton.Add(item, button);

            item.strategy = new NormalPurchase(item);
            ChangeButtonText("available", item);

            if (item.id == 3 || item.id == 7)
            {
                item.strategy = new SalePurchase(20, item);
                ChangeButtonText("sale", item);
            }

            if (item.id == 9)
            {
                item.strategy = new FreePurchase();
                ChangeButtonText("free", item);
            }

            button.onClick.AddListener(() => item.Buy(shopManager));
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

    public void ChangeButtonText(string state, Item item)
    {
        Button button = itemToButton[item];

        switch (state)
        {
            case "available":
                button.GetComponentInChildren<TMP_Text>().text = $"{item.name} - {item.price} gems";
                break;
            case "soldout":
                button.GetComponentInChildren<TMP_Text>().text = $"{item.name} - not available";
                break;
            case "owned":
                button.GetComponentInChildren<TMP_Text>().text = $"{item.name} - owned";
                break;
            case "normal":
                button.GetComponentInChildren<TMP_Text>().text = $"{item.name} - {item.price} gems";
                break;
            case "sale":
                button.GetComponentInChildren<TMP_Text>().text = $"{item.name} - from {item.price} to {item.strategy.GetPrice()} gems";
                break;
            case "free":
                button.GetComponentInChildren<TMP_Text>().text = $"{item.name} - from {item.price} to free";
                break;
        }
    }
}
