using UnityEngine;

public class Weapon : MonoBehaviour, IItem
{
    // Serialized backing fields for Inspector editing
    [SerializeField] private string itemName;
    [SerializeField] private string itemDescription;
    [SerializeField] private int itemPrice;
    [SerializeField] private Sprite itemDesign;
    
    // Additional property specific to Weapon
    public double Damage;

    // IItem interface implementation
    public string Name
    {
        get { return itemName; }
        set { itemName = value; }
    }

    public string Description
    {
        get { return itemDescription; }
        set { itemDescription = value; }
    }

    public int Price
    {
        get { return itemPrice; }
        set { itemPrice = value; }
    }

    public Sprite Design
    {
        get { return itemDesign; }
        set { itemDesign = value; }
    }

    // Implementation of the Use method from the IItem interface
    public void Use()
    {
        // Define what happens when the weapon is used.
        // For example, you might display a message, trigger an animation, or apply damage.
        Debug.Log($"Weapon {Name} used! It deals {Damage} damage.");
    }

    void Start()
    {
        // Optionally initialize here
    }

    void Update()
    {
        // Optional per-frame updates
    }
}
