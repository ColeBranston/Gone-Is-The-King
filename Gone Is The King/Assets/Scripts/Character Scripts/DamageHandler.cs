using UnityEngine;

public class DamageHandler: IAttackable
{
    public double health;
    public void TakeDamage(double dmg){
        this.health -= dmg;
    }
}