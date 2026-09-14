using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopUi : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform shopContainer;
    public ShopManager shopManager;
    public TMP_Text error;

    void Start()
    {
        error.alpha = 0;
    }

    public void FillShopUi(Item[] shopItems)
    {
        foreach (var item in shopItems)
        {
            GameObject buttonObject = Instantiate(buttonPrefab, shopContainer);

            Button button = buttonObject.GetComponentInChildren<Button>();

            item.strategy = new NormalPurchase(button, item);
            item.ChangeState(new AvailableState(item, button));

            if (item.id == 3)
            {
                item.strategy = new SalePurchase(20, button, item);
            }

            if (item.id == 1)
            {
                item.strategy = new FreePurchase(button, item);
            }

            button.onClick.AddListener(() => item.Buy(shopManager));
        }
    }

    public void ShowError()
    {
        error.alpha = 1;
    }
}
