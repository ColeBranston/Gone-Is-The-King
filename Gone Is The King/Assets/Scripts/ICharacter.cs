using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface ICharacter
{
    int[] position { get; set; }
    int moveSpeed { get; set; }
    Sprite design { get; set; }
}
