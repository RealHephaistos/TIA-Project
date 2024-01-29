using Lean.Gui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class LeanButtonRelease : LeanButton
{
    public UnityEvent OnRelease { get { if (onRelease == null) onRelease = new UnityEvent(); return onRelease; } }
    [SerializeField] private UnityEvent onRelease;

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);

        if(IsInteractable() == true)
        {
            if (onRelease != null)
            {
                onRelease.Invoke();
            }
        }
    }
}
