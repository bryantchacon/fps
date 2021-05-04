using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ESTE SCRIPT VA EN LA MAIN CAMERA

public class Mira : MonoBehaviour
{
    public float sensitivity = 300f; //Sensibilidad del movimiento de la camara
    public Transform player1; //Variable para referenciar el Player1
    float lookUpAndDown = 0f; //Grados al mirar arriba y abajo, se recomienda que empiece en 0
    
    void Start() //Se llama una sola vez antes del primer frame
    {
        Cursor.lockState = CursorLockMode.Locked; //Bloquea el cursor al centro de la ventana de juego
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime; //Detecta el movimiento del mouse en el eje X y lo asigna a la variable mouseX. sensitivity y Time.deltaTime es para la velocidad a la que se movera la camara
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        lookUpAndDown -= mouseY; //Indica que el valor de lookUpAndDown sera el movimiento del mouse de arriba a abajo
        lookUpAndDown = Mathf.Clamp(lookUpAndDown, -90f, 75f); //Limita el movimiento ariba/abajo entre -90° hacia abajo y 75° hacia arriba

        transform.localRotation = Quaternion.Euler(lookUpAndDown, 0f, 0f); //Hace posible la rotacion arriba/abajo SOLO DE LA CAMARA(por transform.localRotation) cuando la detecta, porque en ella esta este script, en resumen; es la rotacion del objeto(en este caso la main camera) en relacion a su padre(el Player1), o sea, podra rotar la camara arriba/abajo sin rotar al Player1 tambien. Quaternion es una estructura de datos para representar una rotacion
        player1.Rotate(Vector3.up * mouseX); //Hace posible la rotacion izquierda/derecha DEL PLAYER1 cuando la detecta. Vector3.up indica que rotara al Player1 SOBRE el eje Y del mundo del juego y multiplicarlo por mouseX que sera hacia los lados
    }
}