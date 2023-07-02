using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendul : MonoBehaviour

{
    // Start is called before the first frame update
    private Vector3 hitDir;
    [SerializeField] float force = 100f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
{
    //для каждого соприкосновения
    foreach (ContactPoint contact in collision.contacts)
    {
        //Если соприкоснулись с объектом с тэгом Player
        if (collision.gameObject.tag == "Player")
        {
            //задаем направление, в котором оттолкнем объект
            hitDir = contact.normal;
            //добавляем импульс объекту в сторону противоположную стороне соприкосновения
            collision.gameObject.GetComponent<Rigidbody>().AddForce(-hitDir * force, ForceMode.Impulse);
            return;
        }
    }
}
}
