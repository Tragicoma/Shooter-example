using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazor : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // moving de lazorz upwards
        // destroying them when they leave the camera view

        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        

        if (transform.position.y > 5.8f)
        {
            Destroy(this.gameObject);
        }


    }


}
