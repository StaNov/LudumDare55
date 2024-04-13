using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFlower : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        var ducklingFlow = other.GetComponent<DucklingFlow>();

        if (ducklingFlow == null)
            return;

        ducklingFlow.OnDucklingFlow();
    }
}
