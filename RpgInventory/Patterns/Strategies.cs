using RpgInventory.Items;

namespace RpgInventory.Patterns;

public interface IUpgradeStrategy
{
    bool CanUpgrade(IItem item);
    void Upgrade(IItem item);
}

public interface ICombineStrategy
{
    bool CanCombine(IItem first, IItem second);
    IItem Combine(IItem first, IItem second);
}

public sealed class WeaponUpgradeStrategy : IUpgradeStrategy
{
    private readonly int _damageBonus;
    public WeaponUpgradeStrategy(int damageBonus) => _damageBonus = damageBonus;

    public bool CanUpgrade(IItem item) => item is IUpgradeable && item.Type == "Weapon";

    public void Upgrade(IItem item)
    {
        if (item is IUpgradeable up)
            up.ApplyUpgrade("Damage", _damageBonus);
    }
}

public sealed class ArmorUpgradeStrategy : IUpgradeStrategy
{
    private readonly int _defenseBonus;
    public ArmorUpgradeStrategy(int defenseBonus) => _defenseBonus = defenseBonus;

    public bool CanUpgrade(IItem item) => item is IUpgradeable && item.Type == "Armor";

    public void Upgrade(IItem item)
    {
        if (item is IUpgradeable up)
            up.ApplyUpgrade("Defense", _defenseBonus);
    }
}

public sealed class PotionCombineStrategy : ICombineStrategy
{
    public bool CanCombine(IItem first, IItem second) =>
        first is Potion && second is Potion;

    public IItem Combine(IItem first, IItem second)
    {
        var p1 = (Potion)first;
        var p2 = (Potion)second;

        return new Potion($"{p1.Name}+{p2.Name}", p1.HealAmount + p2.HealAmount);
    }
}