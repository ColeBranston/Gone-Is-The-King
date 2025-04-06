using UnityEngine;

public class Healable : Consumable
{

    public float healAmount;

     // Implementation of the Use method from the IItem interface
    public override void Use()
    {
        hasInventory.Instance.RemoveItem(this);
        //HealthSystem.Instance.TakeDamage(50); for testing
        HealthSystem.Instance.HealDamage(this.healAmount);

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
