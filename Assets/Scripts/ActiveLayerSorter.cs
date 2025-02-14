using System;
using NUnit.Framework;
using UnityEngine;

public class ActiveLayerSorter : MonoBehaviour {
    private SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void AdjustSortingLayer() {
        spriteRenderer.sortingOrder = -(int)(transform.position.z * 100);
        if(spriteRenderer.sortingOrder < -1400) {
            spriteRenderer.sortingLayerID = default;
        } else {
            spriteRenderer.sortingLayerID = 2048447561;
        }
    }

    private void Update() {
        AdjustSortingLayer();
    }
}
