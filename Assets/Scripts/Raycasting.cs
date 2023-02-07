using UnityEngine;

public class Raycasting : MonoBehaviour
{
    private Camera cam;
    public PlayerController player;
    public LayerMask ground;

    // Start is called before the first frame update
    void Start() => cam = Camera.main;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (!player.canInteract && Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
                    RayMove(hit);
            else
            {
                Physics.Raycast(ray, out hit);
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    RayMove(hit);
                    return;
                }
                RayInteract(hit);
            }

            //Debug.DrawRay(ray.origin, ray.direction * 200, Color.red);
        }
    }

    private void RayInteract(RaycastHit hit)
    {
        // access the child collider via hit.collider.transform
        if(hit.collider.transform.GetComponent<IInteractable>() == player.currentInteract)
            player.currentInteract.OnInteract();
    }
    private void RayMove(RaycastHit hit) => player.MoveToPos(hit.point);
}