using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    private RectTransform rectTransform;
    private Rect safeAreaRect;
    Vector2 minAnchor;
    Vector2 maxAnchor;

    private void Awake()
    {
        FitInSafeArea();
    }
    void OnRectTransformDimensionsChange()
    {
        FitInSafeArea();
    }

    [ContextMenu("FitInSafeArea")]
    private void FitInSafeArea()
    {
        if (Application.isPlaying == false) return;
        rectTransform = GetComponent<RectTransform>();

        safeAreaRect = Screen.safeArea;
        minAnchor = safeAreaRect.position;
        maxAnchor = minAnchor + safeAreaRect.size;

        minAnchor.x /= Screen.width;
        minAnchor.y /= Screen.height;
        maxAnchor.x /= Screen.width;
        maxAnchor.y /= Screen.height;

        rectTransform.anchorMin = minAnchor;
        rectTransform.anchorMax = maxAnchor;
    }

}
