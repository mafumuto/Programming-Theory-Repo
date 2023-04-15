using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float speed = 5.0f;
    private GameObject focalPoint;
    public GameObject powerupIndicator;
    public bool hasPowerup;
    public float awayFromStrengh = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");

        playerRB.AddForce(speed * verticalInput * focalPoint.transform.forward );

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountDownRoutine());
            
        }
        
    }
    
    IEnumerator PowerUpCountDownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFrom = collision.gameObject.transform.position - transform.position;
            enemyRigidbody.AddForce(awayFrom * awayFromStrengh, ForceMode.Impulse);
            Debug.Log("Collided with : " + collision.gameObject.name + "with powerup set to" + hasPowerup);
        }
    }
}
