using UnityEngine;

public class InteractableSelf : MonoBehaviour, IInteractable
{
    public void OnInteract()
    {
        print("self interact");
    }
}
