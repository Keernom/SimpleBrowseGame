using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideHandler : MonoBehaviour
{
    [SerializeField] AudioClip _pickupSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            GetComponent<AudioSource>().PlayOneShot(_pickupSound);
            other.gameObject.GetComponent<Pickup>().GetBonus(gameObject);
        }
    }
}
