using UnityEngine;
using TMPro;

public class GemUi : MonoBehaviour {
    [SerializeField] Player player;
    [SerializeField] TMP_Text label;

    void Start() {
        ChangeLabel(player.GemBalance);

        player.OnBalanceChanged.AddListener(ChangeLabel);
    }

    private void ChangeLabel(int gems) {
        label.text = gems + " gems";
    }
}