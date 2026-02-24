using RpgInventory.Items;

namespace RpgInventory.Patterns;

public interface IItemFactory
{
    Weapon CreateWeapon(string name, int damage);
    Armor CreateArmor(string name, int defense);
    Potion CreatePotion(string name, int healAmount);
    QuestItem CreateQuestItem(string name);
}

public sealed class BasicItemFactory : IItemFactory
{
    public Weapon CreateWeapon(string name, int damage) => new(name, damage);
    public Armor CreateArmor(string name, int defense) => new(name, defense);
    public Potion CreatePotion(string name, int healAmount) => new(name, healAmount);
    public QuestItem CreateQuestItem(string name) => new(name);
}