using UnityEngine;
using System.Collections;

public class Destroy_by_boundary : MonoBehaviour 
{
    void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
