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
        Debug.Log(collision.gameObject.name);

        if (collision.CompareTag("Enemy") || collision.CompareTag("Interactable"))
        {
            //Call the damage function on the interface
            collision.gameObject.GetComponent<IDamageable>().TakeDamage(2);
        }
    }

    public IEnumerator countDown()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }

}
