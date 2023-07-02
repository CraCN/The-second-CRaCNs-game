using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int force; //сила толчка    
private void OnCollisionEnter(Collision collision)
{
    if(collision.collider.CompareTag("Player"))
    {
        //Применяем импульс к персонажу
        collision.collider.GetComponent<Rigidbody>().AddForce(new Vector3(0,force,0), ForceMode.Impulse);
    }
}
}
