using System;
using UnityEngine;

public class ActiveLayerSorter : MonoBehaviour {
    private SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void AdjustSortingLayer() {
        spriteRenderer.sortingOrder = -(int)(transform.position.z * 100);
    }

    private void Update() {
        AdjustSortingLayer();
    }
}
