using UnityEngine.Events;
using Zenject;

public class Player {
    public Inventory inventory;

    public UnityEvent<Cosmetic, Cosmetic> OnCosmeticChanged { get; private set; } = new();
    public UnityEvent<int> OnBalanceChanged { get; private set; } = new();

    private int gemBalance = 200;
    public int GemBalance {
        get => gemBalance;
        set {
            gemBalance = value;
            OnBalanceChanged.Invoke(value);
        }
    }

    private Hat hat;
    public Hat Hat {
        get => hat;
        set {
            Cosmetic oldHat = hat;
            hat = value;
            OnCosmeticChanged.Invoke(oldHat, value);
        }
    }

    private Skin skin;
    public Skin Skin {
        get => skin;
        set {
            Cosmetic oldSkin = skin;
            skin = value;
            OnCosmeticChanged.Invoke(oldSkin, value);
        }
    }

    private Pet pet;
    public Pet Pet {
        get => pet;
        set {
            Cosmetic oldPet = pet;
            pet = value;
            OnCosmeticChanged.Invoke(oldPet, value);
        }
    }

    [Inject]
    public void Construct(Inventory inventory) {
        this.inventory = inventory;
    }

    public bool CheckBalance(int amount) {
        return amount <= GemBalance;
    }

    public void UpdateBalance(int amount) {
        GemBalance += amount;
    }
}
