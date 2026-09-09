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

            item.Initialize(shopManager, button);

            if (item.id == 3)
            {
                item.ChangeState(new SaleState(item, shopManager, 20, button));
            }

            button.onClick.AddListener(() => item.Buy());
        }
    }

    public void ShowError()
    {
        error.alpha = 1;
    }
}
