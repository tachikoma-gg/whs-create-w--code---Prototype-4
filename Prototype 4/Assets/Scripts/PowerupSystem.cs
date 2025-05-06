using System.Collections;
using UnityEngine;

public class PowerupSystem : MonoBehaviour
{
    private bool hasPowerup;

    [SerializeField] private float powerupStrength;
    [SerializeField] private float powerupTimeSeconds;

    [SerializeField] private GameObject powerupIndicator;

    void Start()
    {
        powerupIndicator.SetActive(false);
    }

    void Update()
    {
        powerupIndicator.transform.position = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Powerup"))
            return;
        
        StartCoroutine(PowerupCountdown());
        Destroy(other.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(!hasPowerup || !collision.gameObject.CompareTag("Enemy"))
            return;

        GameObject enemy = collision.gameObject;

        Rigidbody enemyRb = enemy.GetComponent<Rigidbody>();
        Vector3 pushDirection = (enemy.transform.position - transform.position).normalized;

        enemyRb.AddForce(pushDirection * powerupStrength, ForceMode.Impulse);
    }

    IEnumerator PowerupCountdown()
    {
        hasPowerup = true;
        powerupIndicator.SetActive(true);

        yield return new WaitForSeconds(powerupTimeSeconds);

        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }
}
