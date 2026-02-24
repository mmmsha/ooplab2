using RpgInventory.Patterns;

namespace RpgInventory.Tests;

public class FactoryAndBuilderTests
{
    [Fact]
    public void Factory_ShouldCreateWeapon()
    {
        var factory = new BasicItemFactory();
        var w = factory.CreateWeapon("Sword", 12);

        Assert.Equal(12, w.Damage);
    }

    [Fact]
    public void Builder_ShouldBuildArmor()
    {
        var armor = new ArmorBuilder()
            .WithName("Plate")
            .WithDefense(20)
            .Build();

        Assert.Equal("Plate", armor.Name);
        Assert.Equal(20, armor.Defense);
    }
}