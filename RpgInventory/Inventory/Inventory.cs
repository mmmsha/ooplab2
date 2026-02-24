using RpgInventory.Items;
using RpgInventory.Patterns;

namespace RpgInventory.Inventory;

public sealed class Inventory
{
    private readonly List<IItem> _items = new();

    public IReadOnlyList<IItem> Items => _items;

    public void Add(IItem item) => _items.Add(item);

    public bool Remove(Guid itemId)
    {
        var item = _items.FirstOrDefault(x => x.Id == itemId);
        if (item is null) return false;
        _items.Remove(item);
        return true;
    }

    public bool Equip(Guid itemId)
    {
        var item = _items.FirstOrDefault(x => x.Id == itemId);
        if (item is not IEquipable equipable) return false;
        equipable.Equip();
        return true;
    }

    public bool Unequip(Guid itemId)
    {
        var item = _items.FirstOrDefault(x => x.Id == itemId);
        if (item is not IEquipable equipable) return false;
        equipable.Unequip();
        return true;
    }

    public bool Use(Guid itemId)
    {
        var item = _items.FirstOrDefault(x => x.Id == itemId);
        if (item is not IUsable usable) return false;
        if (!usable.CanUse) return false;

        usable.Use();
        return true;
    }

    public bool Upgrade(Guid itemId, IUpgradeStrategy strategy)
    {
        var item = _items.FirstOrDefault(x => x.Id == itemId);
        if (item is null) return false;
        if (!strategy.CanUpgrade(item)) return false;

        strategy.Upgrade(item);
        return true;
    }

    public Guid? Combine(Guid firstId, Guid secondId, ICombineStrategy strategy)
    {
        var first = _items.FirstOrDefault(x => x.Id == firstId);
        var second = _items.FirstOrDefault(x => x.Id == secondId);
        if (first is null || second is null) return null;

        if (!strategy.CanCombine(first, second)) return null;

        var result = strategy.Combine(first, second);

        _items.Remove(first);
        _items.Remove(second);
        _items.Add(result);

        return result.Id;
    }

    public InventorySnapshot GetSnapshot() =>
        new(_items.Count, _items.Select(i => i.GetInfo()).ToList());
}