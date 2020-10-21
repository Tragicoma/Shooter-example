using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private GameObject _boom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player ship = other.GetComponent<Player>();
            if (ship != null)
            {
                ship.Dying();
                Instantiate(_boom, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }

        }

        if (other.tag == "Attack")
        {
            Destroy(other.gameObject);
            Instantiate(_boom, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    private void Movement()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y <= -6.4f)
        {
            float randomX = Random.Range(-5.5f, 5.5f);
            transform.position = new Vector3(randomX,7f,0);
        }
        

    }
}
