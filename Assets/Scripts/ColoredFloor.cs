using System.Collections;
using UnityEngine;

public class ColoredFloor : MonoBehaviour
{
    public Material defaultMat;
    public Material nextMat;
    private bool _inside;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print(this);
            _inside = true;
            StartCoroutine(ColorSwitch());
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            _inside = false;
    }

    private IEnumerator ColorSwitch()
    {
        GetComponent<MeshRenderer>().material = nextMat;
        yield return new WaitUntil(() => !_inside);
        yield return new WaitForSeconds(2f);
        GetComponent<MeshRenderer>().material = defaultMat;
    } 
}
