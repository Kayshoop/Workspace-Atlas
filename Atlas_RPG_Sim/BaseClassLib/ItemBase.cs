using System; // includes System namespace which holds fundamental clases and baseclasses for C#
using System.Collections.Generic; // includes the namespace associated with interfaces and classes that define generic collections like list and dictionary.

namespace BaseClassLib
{
    public abstract class ItemBase // abstract keyword indicates that the class cannot be instantiated directly, it is only meant to a base class
    {
        public int ID { get; set; } // type of item Armor, Potion, Weapon
        public string Name { get; set; } // Name of item, Leathers, Health, Silver_Sword
        public float Weight { get; set; } // how much the item weighs for storage.

        public ItemBase(int id, string name, float weight) // Constructor for ItemBase
        {
            ID = id;
            Name = name;
            Weight = weight;
        }
        // abstract methods - any derived classes must implement these methods. 
        public abstract string GetInfo(); // all items must provide information of item.
        public abstract void Use(); // all items need a way to be used.
    }

    //derived classes
    public class Weapon : ItemBase // building base for all weapons.
    {
        public int Damage { get; set; } // will return a damage to deduct from in derived classes later

        public Weapon(int id, string name, float weight, int damage) : base(id, name, weight)
        {
            Damage = damage;
        }
        public override string GetInfo()
        {
            return $"{Name} (Weapon Type: {ID}, Weight: {Weight}, Damage: {Damage})";
        }
        public override void Use()
        {
            Console.WriteLine($"Hit! {Damage} damage dealt.");
        }
    }
    public class Potion : ItemBase // building base class for all potions.
    {
        public string Effect { get; set; } // will return some type of effect.

        public Potion(int id, string name, float weight, string effect) : base(id, name, weight)
        {
            Effect = effect;
        }

        public override string GetInfo()
        {
            return $"{Name} (Potion Type: {ID}, Weight: {Weight}, Effect: {Effect})";
        }

        public override void Use()
        {
            if (Effect == "Damage")
            { // Deduct points from HP in potions classes.
                Console.WriteLine($"{Name} causes damage. HP is reduced.");
            }
            else if (Effect == "Health")
            { // Add points to HP later..
                Console.WriteLine($"{Name} restores health. HP is increased.");
            }
        }
    }

    public class Armor : ItemBase
    {
        public int Protection { get; set; } // sets each armor obj to a specified protection stat.

        // base class for all armor dictating their protection stats.
        public Armor(int id, string name, float weight, int protection) : base(id, name, weight)
        {
            Protection = protection;
        }
        public int Defend(int attackPoints)
        {
            return attackPoints - Protection;
        }
        public override string GetInfo()
        {
            return $"{Name} (Armor Type: {ID} Weight: {Weight}, Protection: {Protection})";
        }
        public override void Use()
        {
            Console.WriteLine($"{Name} equipped. View stats? (y/n): ");
            var key = Console.ReadKey().KeyChar; // holding key as a variable using var then assigning it a char value.
            Console.WriteLine();

                if (char.ToLower(key) == 'y')
                {
                    Console.WriteLine(GetInfo());
                }
                else if (char.ToLower(key) == 'n')
                {
                    Console.WriteLine("Successfully equipped.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please press 'y' or 'n'.");
                }
        }
    }
    // new base class for inventory that will connect to the items
    public abstract class InventoryBase
    {  
        protected int Capacity { get; set; }
        protected List<ItemBase> Contents { get; set; }

        public InventoryBase(int capacity)
        {
            Capacity = capacity;
            Contents = new List<ItemBase>(capacity);
        }
        public virtual void AddItem(ItemBase item)
        {
            if (Contents.Count < Capacity)
            {
                Contents.Add(item);
                Console.WriteLine($"{item.Name} add to inventory.");
            }
            else 
            {
                Console.WriteLine("Inventory is full. Would you like to make room?\n(y/n): ");
                var key = Console.ReadKey().KeyChar;

                    if (char.ToLower(key) == 'y')
                    {
                       _ // list inventory 
                        // allow user to remove item by tying in item name.
                    }
                    else if (char.ToLower(key) == 'n')
                    {
                        Console.WriteLine($"Dropping {item.Name}");
                    }
                    else 
                    {
                        Console.WriteLine("Invalid input. Please press 'y' or 'n'.");
                    }

            }
        }
        public virtual void RemoveItem(ItemBase item)
        {
            if (Contents.Remove(item))
            {
                Console.WriteLine($"{item.Name} removed from inventory.");
            }
            else 
            {
                Console.WriteLine($"{item.Name} not found in inventory.");
            }
        }
    }
}
