using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorDeEscena : MonoBehaviour
{
    public int CofresEnPantalla;
    public GameObject[] NivelPreFab;
    private int IndiceDeNiveles;
    private GameObject ObjetoNivel;
    public Text TextoDeJuego;


    // Start is called before the first frame update
    void Start()
    {
        IndiceDeNiveles = 0;
        ObjetoNivel = Instantiate(NivelPreFab[IndiceDeNiveles]);
        ObjetoNivel.transform.SetParent(this.transform);

    }

    // Update is called once per frame
    void Update()
    {
        CofresEnPantalla = this.GetComponentsInChildren<Cofre>().Length;

        TextoDeJuego.text = "Nivel" + (IndiceDeNiveles + 1) +
                            "\nDestruye todos los cofres" +
                            "\nCofres Restantes:" + CofresEnPantalla;
        if(CofresEnPantalla== 0)
        {
            TextoDeJuego.text = "Completaste el nivel! \nPresione R para el siguiente nivel";
            
            if (IndiceDeNiveles == NivelPreFab.Length - 1)
            {
                TextoDeJuego.text = "Completaste el Juego! \nPresiona R para volver a empezar";
                
            }
            if (Input.GetKeyUp("r"))
            {
                if(IndiceDeNiveles== NivelPreFab.Length - 1)
                {
                    Destroy(ObjetoNivel);
                    IndiceDeNiveles = 0;
                    ObjetoNivel = Instantiate(NivelPreFab[0]);
                    ObjetoNivel.transform.SetParent(this.transform);

                }else
                {
                    Destroy(ObjetoNivel);
                    IndiceDeNiveles += 1;
                    ObjetoNivel = Instantiate(NivelPreFab[IndiceDeNiveles]);
                    ObjetoNivel.transform.SetParent(this.transform);
                }
            }
        }
    }
}
