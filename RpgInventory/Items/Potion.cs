namespace RpgInventory.Items;

public sealed class Potion : IItem, IUsable, IUpgradeable
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; }
    public string Type => "Potion";

    public int HealAmount { get; private set; }

    public bool IsUsed { get; private set; }
    public bool CanUse => !IsUsed;

    public Potion(string name, int healAmount)
    {
        Name = name;
        HealAmount = healAmount;
    }

    public void Use()
    {
        if (IsUsed) return;
        IsUsed = true;
    }

    public void ApplyUpgrade(string upgradeName, int value)
    {
        if (upgradeName == "Heal")
            HealAmount += value;
    }

    public ItemInfo GetInfo() =>
        new(Id, Name, Type, new Dictionary<string, string>
        {
            ["HealAmount"] = HealAmount.ToString(),
            ["IsUsed"] = IsUsed.ToString()
        });
}