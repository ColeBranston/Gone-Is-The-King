using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IItem
{
    string Name { get; set; }
    string Description { get; set; }
    int Price { get; set; }
    Sprite Design { get; set; }
}
