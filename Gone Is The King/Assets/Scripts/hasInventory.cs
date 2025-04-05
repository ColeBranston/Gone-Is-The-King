using System;
using System.Collections.Generic;
using UnityEngine;

public class hasInventory : MonoBehaviour
{
    // Inventory dictionary: key = item's name, value = tuple (IItem, amount)
    private Dictionary<string, (IItem item, int amount)> inventory = new Dictionary<string, (IItem, int)>();

    public static hasInventory Instance;

    // Event to notify when the inventory changes (item added or removed)
    public event Action OnInventoryChanged;
    
    void Start()
    {
        // Optionally, initialize your inventory here.
    }

    void Update()
    {
        // Inventory updates can be handled here if needed.
    }

    void Awake()
	{
		Instance = this;
	}

    /// <summary>
    /// Adds the specified amount of the item to the inventory.
    /// Items are stacked based on the item's Name.
    /// </summary>
    public void AddItem(IItem item, int amount = 1)
    {
        if (item == null)
        {
            Debug.LogWarning("Cannot add a null item to the inventory.");
            return;
        }

        if (inventory.ContainsKey(item.Name))
        {
            // Stack the item by increasing the quantity
            var entry = inventory[item.Name];
            entry.amount += amount;
            inventory[item.Name] = entry;
        }
        else
        {
            // Create a new entry for the item
            inventory[item.Name] = (item, amount);
        }

        Debug.Log($"Added {amount} of {item.Name} to inventory. Total now: {inventory[item.Name].amount}.");
        OnInventoryChanged?.Invoke();
    }

    /// <summary>
    /// Removes the specified amount of the item from the inventory.
    /// </summary>
    public bool RemoveItem(IItem item, int amount = 1)
    {
        if (item == null)
        {
            Debug.LogWarning("Cannot remove a null item from the inventory.");
            return false;
        }

        if (inventory.ContainsKey(item.Name))
        {
            var entry = inventory[item.Name];
            entry.amount -= amount;
            if (entry.amount <= 0)
            {
                inventory.Remove(item.Name);
                Debug.Log($"{item.Name} completely removed from inventory.");
            }
            else
            {
                inventory[item.Name] = entry;
                Debug.Log($"Removed {amount} of {item.Name}. Remaining: {entry.amount}.");
            }

            OnInventoryChanged?.Invoke();
            return true;
        }
        else
        {
            Debug.LogWarning($"{item.Name} not found in inventory.");
            return false;
        }
    }

    /// <summary>
    /// Returns the current count of the specified item in the inventory.
    /// </summary>
    public int GetItemCount(IItem item)
    {
        if (item == null)
            return 0;
        
        return inventory.TryGetValue(item.Name, out var entry) ? entry.amount : 0;
    }

    /// <summary>
    /// Returns a copy of the inventory dictionary.
    /// </summary>
    public Dictionary<string, (IItem, int)> GetAllItems()
    {
        return new Dictionary<string, (IItem, int)>(inventory);
    }


    /// <summary>
    /// When the player collides with an object, check if it has an IItem component.
    /// If it does, add it to the inventory and remove it from the scene.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided With Item");

        // Attempt to get a component that implements IItem from the colliding object.
        IItem item = other.GetComponent<IItem>();
        if (item != null)
        {
            // Add the item to the inventory
            AddItem(item, 1);
            
            foreach (var entry in inventory)
            {
                Debug.Log($"Item: {entry.Key}, Quantity: {entry.Value.amount}");
            }

            // Optionally remove the item from the scene (simulate "picking it up")
            Destroy(other.gameObject);
        }
    }
}
