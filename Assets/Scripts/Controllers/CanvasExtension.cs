using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CanvasExtension 
{
    public static void IsEnableCanvasGroup(this CanvasGroup canvasGroup, bool isEnabled)
    {
        canvasGroup.alpha = isEnabled ? 1 : 0;
        canvasGroup.blocksRaycasts = isEnabled;
        canvasGroup.interactable = isEnabled;
        canvasGroup.ignoreParentGroups = isEnabled;
    }
}
