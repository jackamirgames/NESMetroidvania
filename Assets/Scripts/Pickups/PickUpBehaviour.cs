using UnityEngine;

public class PickUpBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Test for just the first jump upgrade
            collision.gameObject.GetComponent<PlayerUpgrades>().CurrentJump = PlayerUpgrades.JumpUpgrades.Normal;
        }
    }
}
