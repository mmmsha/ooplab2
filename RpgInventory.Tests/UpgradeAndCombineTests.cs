using RpgInventory.Inventory;
using RpgInventory.Items;
using RpgInventory.Patterns;

namespace RpgInventory.Tests;

public class UpgradeAndCombineTests
{
    [Fact]
    public void Upgrade_Weapon_ShouldIncreaseDamage()
    {
        var inv = new Inventory.Inventory();
        var factory = new BasicItemFactory();
        var w = factory.CreateWeapon("Axe", 10);
        inv.Add(w);

        var ok = inv.Upgrade(w.Id, new WeaponUpgradeStrategy(5));

        Assert.True(ok);
        Assert.Equal(15, w.Damage);
    }

    [Fact]
    public void Upgrade_Armor_ShouldIncreaseDefense()
    {
        var inv = new Inventory.Inventory();
        var factory = new BasicItemFactory();
        var a = factory.CreateArmor("Chainmail", 7);
        inv.Add(a);

        var ok = inv.Upgrade(a.Id, new ArmorUpgradeStrategy(3));

        Assert.True(ok);
        Assert.Equal(10, a.Defense);
    }

    [Fact]
    public void Combine_TwoPotions_ShouldReplaceWithNewPotion()
    {
        var inv = new Inventory.Inventory();
        var factory = new BasicItemFactory();

        var p1 = factory.CreatePotion("H1", 10);
        var p2 = factory.CreatePotion("H2", 20);

        inv.Add(p1);
        inv.Add(p2);

        var newId = inv.Combine(p1.Id, p2.Id, new PotionCombineStrategy());

        Assert.NotNull(newId);
        Assert.Single(inv.Items);

        var result = Assert.IsType<Potion>(inv.Items[0]);
        Assert.Equal(30, result.HealAmount);
    }
}