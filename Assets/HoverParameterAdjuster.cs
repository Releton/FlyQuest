using UnityEngine;
using UnityEngine.EventSystems;

public class HoverParameterAdjuster : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Animator animator;
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        animator.SetBool("isHovering", false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetBool("isHovering", true);
    }
}
