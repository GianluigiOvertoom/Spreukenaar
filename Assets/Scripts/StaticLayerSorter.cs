using System;
using UnityEngine;

public class StaticLayerSorter : MonoBehaviour {
    private SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = (int)(transform.position.y * 100);
    }
}