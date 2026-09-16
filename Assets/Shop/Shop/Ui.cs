using UnityEngine;

public class Ui : MonoBehaviour
{
    private CanvasGroup canvas;
    private bool isOpened = true;

    void Start()
    {
        canvas = GetComponent<CanvasGroup>();
        Open();
    }

    public void Open()
    {
        isOpened = !isOpened;

        canvas.alpha = isOpened ? 1 : 0;
        canvas.interactable = isOpened;
        canvas.blocksRaycasts = isOpened;
    }
}