using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour 
{

    public float TiempoDeVida = 2;
    [SerializeField] private float Radio;
    [SerializeField] private float fuerzaExplosion;
    [SerializeField] private GameObject efectoExplosion;
    
   
    public void Explosion()
    {
        
            Instantiate(efectoExplosion, transform.position, Quaternion.identity);


            Collider2D[] objetos = Physics2D.OverlapCircleAll(transform.position, Radio);

            foreach (Collider2D colisionador in objetos)
            {
                Rigidbody2D rb2D = colisionador.GetComponent<Rigidbody2D>();
                if (rb2D != null)
                {
                    Vector2 direccion = colisionador.transform.position - transform.position;
                    float distancia = 1 + direccion.magnitude;
                    float fuerzaFinal = fuerzaExplosion / distancia;
                    rb2D.AddForce(direccion * fuerzaFinal);

                }
            }
            Destroy(gameObject); 
    }
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        TiempoDeVida -= Time.deltaTime;
        if (TiempoDeVida <= 0)
        {
            Destroy(this.gameObject);
        }

    }
  
}
