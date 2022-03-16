using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;
    bool isFocus = false;
    bool hasInteracted = false;
    Transform player;

    public virtual void Interact()
    {
        //this method is meant to be overwriten
        Debug.Log("Interacting with" + transform.name);
    }
    void Update()
    {
        if (isFocus)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if(distance <= radius && !hasInteracted)
            {
                hasInteracted = true;
                Interact();
            }
        }
    }
    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }
    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }
    void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = transform;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
