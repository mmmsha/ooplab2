namespace RpgInventory.Items;

public sealed class Weapon : IItem, IEquipable, IUpgradeable
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; }
    public string Type => "Weapon";

    public int Damage { get; private set; }

    public IEquipState State { get; private set; } = new UnequippedState();

    public Weapon(string name, int damage)
    {
        Name = name;
        Damage = damage;
    }

    public void Equip() => State = new EquippedState();
    public void Unequip() => State = new UnequippedState();

    public void ApplyUpgrade(string upgradeName, int value)
    {
        if (upgradeName == "Damage")
            Damage += value;
    }

    public ItemInfo GetInfo() =>
        new(Id, Name, Type, new Dictionary<string, string>
        {
            ["Damage"] = Damage.ToString(),
            ["State"] = State.Name
        });
}