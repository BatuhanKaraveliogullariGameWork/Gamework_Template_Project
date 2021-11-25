using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [Header("Events")]
    [SerializeField] private VoidEvent onPointerDown;
    [SerializeField] private VoidEvent onPointerUp;
    [SerializeField] private Vector2Event onPointerDrag;

    public void OnPointerDown(PointerEventData eventData)
    {
        onPointerDown.Raise();
    }

    public void OnDrag(PointerEventData eventData)
    {
        onPointerDrag.Raise(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        onPointerUp.Raise();
    }
}
