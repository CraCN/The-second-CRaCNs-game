using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    [SerializeField] float limit = 90f; 
    [SerializeField] float force = 150f; 
    private Vector3 hitDir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Угол будет изменяться по синусоиде
float angle = limit * Mathf.Sin(Time.time);     
//Изменяем угол нашего маятника   
transform.localRotation = Quaternion.Euler(0, 0, angle);

    }
    void OnCollisionEnter(Collision collision)
{
    //для каждого соприкосновения
    foreach (ContactPoint contact in collision.contacts)
    {
        //Если соприкоснулись с объектом с тэгом Player
       if (collision.gameObject.tag=="Player")
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
