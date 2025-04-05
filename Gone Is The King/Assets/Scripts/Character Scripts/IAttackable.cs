using UnityEngine;

public interface IAttackable
{
    public int Health {get;set;}
    public int Defense {get;set;}
    public void TakeDamage(int dmg);
}
