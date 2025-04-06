// using UnityEngine;

// public class Enemy : MonoBehaviour, IAttackable
// {
//     [SerializeField] private int health;
//     [SerializeField] private int defense;

//     // Properties that expose the private fields
//     public int Health
//     {
//         get { return health; }
//         set { health = value; }
//     }
//     public int Defense
//     {
//         get { return defense; }
//         set { defense = value; }
//     }

//     public void TakeDamage(int dmg)
//     {
//         Debug.Log("Hit!");
//         if (dmg > Defense)
//         {
//             Health = Health - (dmg - Defense);
//         }
//         if (Health <= 0)
//         {
//             Die();
//         }
//     }

//     public void Die()
//     {
//         DropItems();
//         Destroy(gameObject); 
//         Debug.Log("Dead!");
//     }

//     public void DropItems()
//     {
//         // TO DO: Add Logic to drop items on death!!!
//     }
// }
