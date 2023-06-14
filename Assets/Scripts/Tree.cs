using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public Fruit fruit;

    public void getFruit()
    {
        if (fruit != null)
        {
            fruit.fall();
        }
    }
}
