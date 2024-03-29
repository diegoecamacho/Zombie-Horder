﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SpawnVolume : MonoBehaviour
{
    private BoxCollider boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    public Vector3 GetPositionInBounds()
    {
        Bounds boxBounds = boxCollider.bounds;

        return new Vector3(
            Random.Range(boxBounds.min.x, boxBounds.max.x),
            transform.position.y,
            Random.Range(boxBounds.min.z, boxBounds.max.z));
    }
}
