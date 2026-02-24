using RpgInventory.Items;

namespace RpgInventory.Items;

public interface IItem
{
    Guid Id { get; }
    string Name { get; }
    string Type { get; }
    ItemInfo GetInfo();
}

public interface IUsable
{
    bool CanUse { get; }
    void Use();
}

public interface IEquipable
{
    IEquipState State { get; }
    void Equip();
    void Unequip();
}

public interface IUpgradeable
{
    void ApplyUpgrade(string upgradeName, int value);
}