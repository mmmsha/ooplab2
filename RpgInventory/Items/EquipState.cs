namespace RpgInventory.Items;

public interface IEquipState
{
    string Name { get; }
    bool IsEquipped { get; }
}

public sealed class EquippedState : IEquipState
{
    public string Name => "Equipped";
    public bool IsEquipped => true;
}

public sealed class UnequippedState : IEquipState
{
    public string Name => "Unequipped";
    public bool IsEquipped => false;
}