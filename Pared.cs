using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pared : MonoBehaviour
{
    public GameObject explocion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
            Instantiate(explocion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
