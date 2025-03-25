using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IAttackable
{
    double health { get; set; }
    double strength { get; set; }
    Armour armour { get; set; }
}
