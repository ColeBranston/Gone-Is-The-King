using UnityEngine;

public class ArmourScript : MonoBehaviour, IItem
{
    // Public properties for all Armours
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public Sprite Design { get; set; }
    public double Defence { get; set; }
    
     // Implementation of the Use method from the IItem interface
    public void Use()
    {
        // Define what happens when the weapon is used.
        // For example, you might display a message, trigger an animation, or apply damage.
        Debug.Log($"Key {Name} used!.");
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
