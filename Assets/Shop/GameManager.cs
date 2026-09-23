using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] private InventoryUi inventoryUi;
    [SerializeField] private GemUi gemUi;
    [SerializeField] private ShopUi shopUi;
    [SerializeField] private ShopManager shopManager;
    [SerializeField] private EquipmentManager equipmentManager;

    private Player player;
    private Inventory inventory;

    void Awake() {
        player = new Player();
        inventory = new Inventory();

        player.Initialize(inventory);
        inventoryUi.Initialize(player, inventory);
        gemUi.Initialize(player);
        shopManager.Initialize(player);
        equipmentManager.Initialize(player);
    }
}