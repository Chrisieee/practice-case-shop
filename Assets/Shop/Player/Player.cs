using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public int gemBalance = 100;
    public Inventory inventory;
    public TMP_Text label;

    public Hat hat { get; set; }
    public Skin skin { get; set; }
    public Pet pet { get; set; }

    void Start()
    {
        label.text = gemBalance + " gems";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            UpdateBalance(50);
        }
    }

    public bool CheckBalance(int amount)
    {
        return amount <= gemBalance;
    }

    public void UpdateBalance(int amount)
    {
        gemBalance += amount;
        label.text = gemBalance + " gems";
    }
}
