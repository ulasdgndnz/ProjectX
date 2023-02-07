using UnityEngine;

public class InteractableDoor : MonoBehaviour, IInteractable
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnInteract()
    {
        _animator.SetBool("isOpen", !_animator.GetBool("isOpen"));
    }
}


