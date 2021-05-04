using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ESTE SCRIPT VA EN EL PLAYER1. ADEMAS SE LE AGREGA EL COMPONENTE Character Controller Y SE PASA COMO PARAMETRO A LA VARIABLE controller

public class Movement : MonoBehaviour
{
    public CharacterController controller; //Variable para referenciar el componente Character Controller del Player1
    public float speed = 30f;
    
    void Update()
    {
        float x = Input.GetAxis("Horizontal"); //Detcta el movimiento en el eje horizontal sin imporar si se usa teclado o gamepad
        float z = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z; //Variable del movimiento del personaje. transform.right es el eje rojo(X), y transform.forward el eje azul(Z). Por ley de signos las multiplicaciones van primero

        controller.Move(movement * speed * Time.deltaTime); //Hace posible el movimiento del Player1 al detectarlo
    }
}