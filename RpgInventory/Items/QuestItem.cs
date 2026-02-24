namespace RpgInventory.Items;

public sealed class QuestItem : IItem
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; }
    public string Type => "Quest";

    public QuestItem(string name) => Name = name;

    public ItemInfo GetInfo() =>
        new(Id, Name, Type, new Dictionary<string, string>());
}