namespace RpgInventory.Items;

public sealed class Armor : IItem, IEquipable, IUpgradeable
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; }
    public string Type => "Armor";

    public int Defense { get; private set; }
    public IEquipState State { get; private set; } = new UnequippedState();

    public Armor(string name, int defense)
    {
        Name = name;
        Defense = defense;
    }

    public void Equip() => State = new EquippedState();
    public void Unequip() => State = new UnequippedState();

    public void ApplyUpgrade(string upgradeName, int value)
    {
        if (upgradeName == "Defense")
            Defense += value;
    }

    public ItemInfo GetInfo() =>
        new(Id, Name, Type, new Dictionary<string, string>
        {
            ["Defense"] = Defense.ToString(),
            ["State"] = State.Name
        });
}