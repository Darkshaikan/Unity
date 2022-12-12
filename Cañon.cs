using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cañon : MonoBehaviour {
    public GameObject CañonCabeza;
    public Camera CamaraDeJuego;
    public GameObject BalaPreFab;
    public float FuerzaDelDisparo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 PosicionDelMouse = Input.mousePosition;
        Vector3 PosicionGlobal = CamaraDeJuego.ScreenToWorldPoint(new Vector3(
            PosicionDelMouse.x,
            PosicionDelMouse.y,
            transform.position.z - CamaraDeJuego.transform.position.z));

        CañonCabeza.transform.localEulerAngles = new Vector3(
            CañonCabeza.transform.localEulerAngles.x,
            CañonCabeza.transform.localEulerAngles.y,
            Mathf.Atan2((PosicionGlobal.y - CañonCabeza.transform.position.y),
                       (PosicionGlobal.x - CañonCabeza.transform.position.x)) * Mathf.Rad2Deg
        );
        if (Input.GetMouseButtonDown(0))
        {
            GameObject ObjetoBala = Instantiate(BalaPreFab);
            ObjetoBala.transform.position = CañonCabeza.transform.position;
            ObjetoBala.GetComponent<Rigidbody2D>().AddForce(CañonCabeza.transform.right * FuerzaDelDisparo);
            ObjetoBala.transform.SetParent(this.transform);
        }
    }
}
