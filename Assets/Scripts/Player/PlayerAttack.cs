using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private float tempAttackCooldown;

    [SerializeField] private GameObject attackPrefab;
    [SerializeField] private Transform attackTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tempAttackCooldown = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (tempAttackCooldown >= 0)
        {
            tempAttackCooldown -= Time.fixedDeltaTime;
        }
    }

    GameObject newAttackPrefab;
    public void Attack()
    {
        if (tempAttackCooldown > 0) return;

        newAttackPrefab = Instantiate(attackPrefab, attackTransform.position, Quaternion.identity);

        //Check which side the attack prefab is on
        if (attackTransform.localPosition.x < 0)
        {
            newAttackPrefab.transform.localScale = new Vector3(-1f, 1, 1);
        }

        tempAttackCooldown = attackCooldown;
    }
}
