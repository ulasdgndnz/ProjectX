using UnityEngine;

public class InteractableCube : MonoBehaviour, IInteractable
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnInteract()
    {
        _animator.enabled = !_animator.enabled;
    }
}
