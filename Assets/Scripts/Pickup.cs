using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character c = collision.GetComponent<Character>();
        if (c != null)
        {
            PickUpObject pickUpObject = GetComponent<PickUpObject>();
            if (pickUpObject != null)
            {
                pickUpObject.OnPickUp(c);
            }
            Destroy(gameObject);
        }
    }
}
