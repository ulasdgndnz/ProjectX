using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool canInteract;
    
    private Animator _animator;
    public IInteractable currentInteract;
    private WaitForEndOfFrame _waitEof;
    private float _speed;
    
    private void Start()
    {
        _waitEof = new WaitForEndOfFrame();
        _animator = GetComponent<Animator>();
        _speed = 5f + Time.deltaTime;
    }

    public void MoveToPos(Vector3 pos)
    {
        StopAllCoroutines();
        StartCoroutine(Move(pos));
    }
    private IEnumerator Move(Vector3 targetPosition)
    {
        _animator.SetBool("isRunning", true);
        while (Vector3.Distance(transform.position, targetPosition) > 0f)
        {
            var position = transform.position;
            transform.forward = Vector3.Lerp(transform.forward,-(position - targetPosition), 2f * Time.deltaTime);
            position = Vector3.MoveTowards(position, targetPosition, 5 * Time.deltaTime);
            transform.position = position;
            yield return _waitEof;
        }
        _animator.SetBool("isRunning", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.layer);
        print(LayerMask.NameToLayer("Interactable"));
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            StopAllCoroutines();
            _animator.SetBool("isRunning", false);
            print(currentInteract);
        }
        
    }
}
