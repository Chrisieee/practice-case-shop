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

    void Start()
    {
        canvas = GetComponent<CanvasGroup>();
        Open();
    }

    public void FillInventoryUi(List<Cosmetic> inventoryItems)
    {
        foreach (Transform child in inventoryContainer) { Destroy(child.gameObject); }

        foreach (var item in inventoryItems)
        {
            GameObject itemObject = Instantiate(itemPrefab, inventoryContainer);
            itemObject.GetComponentInChildren<TMP_Text>().text = item.name + " - " + item.type;
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
