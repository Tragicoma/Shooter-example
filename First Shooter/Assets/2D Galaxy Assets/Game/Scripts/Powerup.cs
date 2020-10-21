using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private int PowerupID; 
    // 3x =  0, speedboost = 1, shield = 2
    [SerializeField]
    private float _speed;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    
    }

    private void OnTriggerEnter2D ( Collider2D other)

    {
        Debug.Log("Collided with" + other.name);
        
        //checks if it is player (using tags!)
        if (other.tag == "Player")
    {
        // access to player script
        Player ship = other.GetComponent<Player>();

            //checking if the script  was called before trying to access the tripleshot
            // aactivating power up
            if (ship != null)
            {
                if (PowerupID == 0)
                {
                    ship.TriplepewActivate();
                }

            else if (PowerupID == 1)
                {
                    ship.SpeedboostActivate();
                }
            else if (PowerupID == 2)
                {
                    ship.ShieldActivate();
                }
                
            }
        
        // selfdestruct
        Destroy(this.gameObject);
    }



    }
}
