using RpgInventory.Inventory;
using RpgInventory.Patterns;

namespace RpgInventory.Tests;

public class InventoryTests
{
    [Fact]
    public void Add_ShouldIncreaseCount()
    {
        var inv = new Inventory.Inventory();
        var factory = new BasicItemFactory();

        inv.Add(factory.CreateQuestItem("Scroll"));

        Assert.Single(inv.Items);
    }

    [Fact]
    public void Equip_Weapon_ShouldChangeState()
    {
        var inv = new Inventory.Inventory();
        var factory = new BasicItemFactory();
        var w = factory.CreateWeapon("Sword", 10);

        inv.Add(w);

        var ok = inv.Equip(w.Id);

        Assert.True(ok);
        Assert.True(w.State.IsEquipped);
    }

    [Fact]
    public void Use_Potion_ShouldMarkUsed()
    {
        var inv = new Inventory.Inventory();
        var factory = new BasicItemFactory();
        var p = factory.CreatePotion("Heal", 25);

        inv.Add(p);

        var ok = inv.Use(p.Id);

        Assert.True(ok);
        Assert.True(p.IsUsed);
    }

    [Fact]
    public void Use_QuestItem_ShouldFail()
    {
        var inv = new Inventory.Inventory();
        var factory = new BasicItemFactory();
        var q = factory.CreateQuestItem("Key");

        inv.Add(q);

        var ok = inv.Use(q.Id);

        Assert.False(ok);
    }
}