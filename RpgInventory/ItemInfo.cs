namespace RpgInventory;

public sealed record ItemInfo(
    Guid Id,
    string Name,
    string Type,
    IReadOnlyDictionary<string, string> Properties
);