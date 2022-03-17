using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSetter : MonoBehaviour
{
    [SerializeField] private int _layer;

    private void Start()
    {
        gameObject.layer = _layer;
    }
}
