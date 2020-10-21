using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
    

{
    [SerializeField]
    private GameObject _boom;
    public int Lives = 3;
    public bool shieldon = false;
    public bool canTriplepew = false;
    public bool speedboost = false;
    [SerializeField]
    private GameObject _Lazor;
    [SerializeField]
    private GameObject _Triplepew;
    [SerializeField]
    private GameObject _Shield;
    [SerializeField]
    private float _cooldown = 0.25f;
    private float _nextpew = 0.0f;

    [SerializeField]
    private float _speed = 5.0f;


    // Start is called before the first frame update
    private void Start()
    {
        transform.position = new Vector3(0, 0, 0); 
    }

    // Update is called once per frame
    private void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {

            Shoot();
         
        }
    }

     
    public void Shoot()
    {
        if (Time.time > _nextpew)
        {

            if (canTriplepew == true)
            {
                Instantiate(_Lazor, transform.position + new Vector3(0.55f,0.3f,0), Quaternion.identity);
                Instantiate(_Lazor, transform.position + new Vector3(-0.55f, 0.3f, 0), Quaternion.identity);
                Instantiate(_Lazor, transform.position + new Vector3(0, 0.882f, 0), Quaternion.identity);
            }

            else
            {
                Instantiate(_Lazor, transform.position + new Vector3(0, 0.882f, 0), Quaternion.identity);
            }

            _nextpew = Time.time + _cooldown;
        }

        
    }

    public void Movement()
    {

        float HAxis = Input.GetAxis("Horizontal");
        float VAxis = Input.GetAxis("Vertical");

        if (speedboost == true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * _speed *3.5f * HAxis);
            transform.Translate(Vector3.up * Time.deltaTime * _speed *3.5f* VAxis);
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * _speed * HAxis);
            transform.Translate(Vector3.up * Time.deltaTime * _speed * VAxis);
        }


        // If the player position on y is grater or less than the boundries
        //set to the last y position

        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.1f)
        {
            transform.position = new Vector3(transform.position.x, -4.1f, 0);
        }

        //Make the player appear on the opposite side on the x axis

        if (transform.position.x > 7.1f)
        {
            transform.position = new Vector3(-7.1f, transform.position.y, 0);
        }
        else if (transform.position.x < -7.1f)
        {
            transform.position = new Vector3(7.1f, transform.position.y, 0);
        }
        Debug.Log("x pos: " + transform.position.x);
    }

    public void Dying ()
    {
        if(shieldon == true)
        {
            shieldon = false;
            _Shield.SetActive(false);
            return;
        }

        else
        Lives = Lives - 1;

        if(Lives < 1)
        {
            Instantiate(_boom, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }




    //activaton-deactivation of boosts
    public void TriplepewActivate()
    {
        canTriplepew = true;
        StartCoroutine(TriplepewDeactivation());
    }

    public void SpeedboostActivate()
    {
        speedboost = true;
        StartCoroutine(SpeedboostDeactivation());
    }

    public void ShieldActivate()
    {
        shieldon = true;
        _Shield.SetActive(true);
    }

    IEnumerator SpeedboostDeactivation()
    {
        yield return new WaitForSeconds(5);
        speedboost = false;
    }
    IEnumerator TriplepewDeactivation()
    {
        yield return new WaitForSeconds(5.0f);
        canTriplepew = false;
    }
}

