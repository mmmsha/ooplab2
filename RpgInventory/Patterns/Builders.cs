using RpgInventory.Items;

namespace RpgInventory.Patterns;

public sealed class WeaponBuilder
{
    private string _name = "Weapon";
    private int _damage = 1;

    public WeaponBuilder WithName(string name) { _name = name; return this; }
    public WeaponBuilder WithDamage(int damage) { _damage = damage; return this; }

    public Weapon Build() => new(_name, _damage);
}

public sealed class ArmorBuilder
{
    private string _name = "Armor";
    private int _defense = 1;

    public ArmorBuilder WithName(string name) { _name = name; return this; }
    public ArmorBuilder WithDefense(int defense) { _defense = defense; return this; }

    public Armor Build() => new(_name, _defense);
}

public sealed class PotionBuilder
{
    private string _name = "Potion";
    private int _heal = 1;

    public PotionBuilder WithName(string name) { _name = name; return this; }
    public PotionBuilder WithHeal(int heal) { _heal = heal; return this; }

    public Potion Build() => new(_name, _heal);
}