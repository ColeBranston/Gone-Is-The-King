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

    void Start()
    {
        // Optionally initialize here
    }

    void Update()
    {
        // Optional per-frame updates
    }
}
