using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ESTE SCRIPT VA EN EL PLAYER1

public class WeaponFire : MonoBehaviour
{
    public float damageAmount = 1f;
    public float firingRange = 150f;
    public Camera playerCam;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit; //Variable del raycast donde se almacenara la informacion de lo que choque con el
        
        //NOTA: Se pueden ejecutar funciones en la condicion de un if
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, firingRange)) //Llama al raycast. Los parametros para usar raycast son: La posicion de la camara, direccion en que saldra el raycast(hacia enfrente por foward), variable en la que se guardara informacion de lo que choque contra el, y su longitud. Si el raycast choca con algo...
        {
            Target target = hit.transform.GetComponent<Target>(); //Recupera el componente Target del game object con el que choco el raycast(por hit)

            if (target != null) //Si Target es diferente de null, o sea, que si tiene datos...
            {
                target.DamageReceived(damageAmount); //... descontara vida del target accediendo a la funcion que lo hace
            }

            //Debug.Log(hit.transform.name); //Imprime en consola el game object contra el que choco
        }
    }
}