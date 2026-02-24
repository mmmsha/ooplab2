namespace RpgInventory.Inventory;

public sealed record InventorySnapshot(
    int TotalItems,
    IReadOnlyList<ItemInfo> Items
);