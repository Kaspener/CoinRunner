using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MakeJump : MonoBehaviour, IPointerClickHandler
{
    public bool isJumped = false;
    public void OnPointerClick(PointerEventData eventData)
    {
        isJumped = true;
    }
}
