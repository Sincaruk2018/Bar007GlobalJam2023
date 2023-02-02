using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum vegType
{
    BLUE,
    RED,
    PURPLE,
    YELLOW,
    ORANGE,
    LIGHTBLUE
};
interface Icollect
{
    vegType WhichVeg();
    void SetTarget(Transform t);
    void DestroyVeg();
    void GrabVeg(Transform parent);
    void Throw(Vector3 dir);
}
