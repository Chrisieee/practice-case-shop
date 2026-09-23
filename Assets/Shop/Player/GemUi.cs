using UnityEngine;
using TMPro;

public class GemUi : MonoBehaviour {
    private Player player;
    [SerializeField] private TMP_Text label;

    public void Initialize(Player player) {
        this.player = player;
    }

    void Start() {
        UpdateLabel(player.GemBalance);

        player.OnBalanceChanged.AddListener(UpdateLabel);
    }

    private void UpdateLabel(int gems) {
        label.text = gems + " gems";
    }
}