using UnityEngine;

public interface IAttackable
{
    public double Health {get;set;}
    public double Defense {get;set;}
    public void TakeDamage(double dmg);
}
