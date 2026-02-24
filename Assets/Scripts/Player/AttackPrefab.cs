using System.Collections;
using UnityEngine;

public class AttackPrefab : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(countDown());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Hit an enemy");
        }
    }

    public IEnumerator countDown()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

}
