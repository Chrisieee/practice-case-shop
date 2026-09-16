using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System;

public class EquipmentUi : MonoBehaviour
{
    public TMP_Text hatLabel;
    public TMP_Text skinLabel;
    public TMP_Text petLabel;

    private CanvasGroup canvas;
    private bool isOpened = true;

    void Start()
    {
        canvas = GetComponent<CanvasGroup>();
        Open();
    }

    public void UpdateEquipment(Cosmetic cosmetic)
    {
        switch (cosmetic.cosmeticType)
        {
            case Cosmetic.CosmeticType.hat:
                hatLabel.text = cosmetic.name;
                break;
            case Cosmetic.CosmeticType.pet:
                petLabel.text = cosmetic.name;
                break;
            case Cosmetic.CosmeticType.skin:
                skinLabel.text = cosmetic.name;
                break;
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
