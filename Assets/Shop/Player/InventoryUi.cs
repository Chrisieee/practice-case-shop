using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class InventoryUi : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform inventoryContainer;
    private CanvasGroup canvas;
    private bool isOpened = true;

    public EquipmentManager equipmentManager;

    void Start()
    {
        canvas = GetComponent<CanvasGroup>();
        Open();
    }

    public void FillInventoryUi(List<Cosmetic> inventoryItems)
    {
        foreach (Transform child in inventoryContainer) { Destroy(child.gameObject); }

        foreach (var cosmetic in inventoryItems)
        {
            GameObject itemObject = Instantiate(itemPrefab, inventoryContainer);
            Button button = itemObject.GetComponentInChildren<Button>();

            button.GetComponentInChildren<TMP_Text>().text = cosmetic.name + " - " + cosmetic.cosmeticType;
            button.onClick.AddListener(() => equipmentManager.EquipCosmetic(cosmetic));
        }
    }

    public void Open()
    {
        isOpened = !isOpened;

        canvas.alpha = isOpened ? 1 : 0;
        canvas.interactable = isOpened;
        canvas.blocksRaycasts = isOpened;
    }
}
