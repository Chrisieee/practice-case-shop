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

            button.GetComponentInChildren<TMP_Text>().text = item.name + " - " + item.price + " gems";

            button.onClick.AddListener(() => item.Buy());
        }
    }

    public void ShowError()
    {
        error.alpha = 1;
    }
}
