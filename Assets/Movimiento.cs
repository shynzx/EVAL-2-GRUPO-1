using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movimiento : MonoBehaviour
{
    public float velocidad = 3f;

    private Rigidbody2D rigidbody;

    private Vector2 posicionInicial;
    private Vector2 direccion = Vector2.zero;



    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        posicionInicial = rigidbody.position;
    }

    public void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();


        if (input.x != 0)
        {
            input.y = 0;

        }
            if (input != Vector2.zero)
        {
            direccion = input.normalized;
        }
    }

    void FixedUpdate()
    {
        rigidbody.linearVelocity = direccion * velocidad;
    }

    public void Detener()
    {
        direccion = Vector2.zero;
        rigidbody.linearVelocity = Vector2.zero;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Muro" || collision.gameObject.name == "Muro")
        {
            Detener();
            rigidbody.position = posicionInicial;
            Debug.Log("moriste");
        }


        else if (collision.gameObject.name == "Meta")
        {
            Detener();
            rigidbody.position = posicionInicial;
            Debug.Log("¡Has llegado a la meta!");
        }
    }
}