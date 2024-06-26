using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float playerReach = 3f;
    Interactable currentInteractable;

    private void Update()
    {
        CheckInteraction();
        if(Input.GetKeyDown(KeyCode.F) && currentInteractable != null)
        {
            currentInteractable.Interact();
        } 
    }

    void CheckInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        //if colliders are in player reach
        if(Physics.Raycast(ray, out hit, playerReach))
        {
            if(hit.collider.tag == "Interactable") //if looking at a interactable obj
            {
                Interactable newInteractable = hit.collider.GetComponent<Interactable>();

                //if there is a currentInteractable and it is not a newInteractble
                if(currentInteractable && newInteractable != currentInteractable)
                {
                    currentInteractable.DisableOutline();
                }

                if(newInteractable.enabled)
                {
                    SetNewCurrentInteractable(newInteractable);
                }

                else //if new interactable is not enabled
                {
                    DisableCurrentInteractable();
                }
            }

            else //if not a interactable
            {
                DisableCurrentInteractable();
            }
        }

        else//if nothing is in reach
        {
            DisableCurrentInteractable();
        }
    }

    void SetNewCurrentInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
        currentInteractable.EnableOutline();
        HudController.instance.EnableInteractionText(currentInteractable.message);
    }

    void DisableCurrentInteractable()
    {
        HudController.instance.DisableInteractionText();
        if(currentInteractable)
        {
            currentInteractable.DisableOutline();
            currentInteractable = null;
        }
    }
}
