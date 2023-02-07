using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InteractableObject : MonoBehaviour
{
    private IInteractable _interactable;
    public GameObject targetGameobject;

    private void Start()
    {
        _interactable = targetGameobject.GetComponent<IInteractable>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().canInteract = true;
            other.GetComponent<PlayerController>().currentInteract = _interactable;
            _interactable?.OnInteract();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().canInteract = false;
            other.GetComponent<PlayerController>().currentInteract = null;
        }
    }
}
