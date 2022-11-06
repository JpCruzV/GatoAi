using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodo : MonoBehaviour {


    public Tablero tablero;
    public int puntaje;
    public int altura;
    public List<Nodo> hijos = new List<Nodo>();


    public void agregarHijo() {

    }


    public bool esTerminnal() {

        return true;
    }
}
