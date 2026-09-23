using UnityEngine;
using TMPro;
using Zenject;

public class GemUi : MonoBehaviour {
    private Player player;
    [SerializeField] private TMP_Text label;

    [Inject]
    public void Construct(Player player) {
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