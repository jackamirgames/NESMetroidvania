using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //Other player scripts
    private PlayerStates _playerStates;
    private PlayerUpgrades _playerUpgrades;

    [SerializeField] private float attackCooldown;
    private float tempAttackCooldown;

    [SerializeField] private GameObject attackPrefab;
    [SerializeField] private Transform attackTransform;

    private void Awake()
    {
        _playerStates = GetComponent<PlayerStates>();
        _playerUpgrades = GetComponent<PlayerUpgrades>();
    }

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
        if (!CanPlayerAttack()) return;

        SetAttackPosition();

        newAttackPrefab = Instantiate(attackPrefab, attackTransform.position, Quaternion.identity);

        //Check which side the attack prefab is on
        if (attackTransform.localPosition.x < 0)
        {
            newAttackPrefab.transform.localScale = new Vector3(-1f, 1, 1);
        }

        tempAttackCooldown = attackCooldown;
    }

    public void SetAttackPosition()
    {
        if (_playerStates.currentPlayerState == PlayerMovementStates.Ducking)
        {
            attackTransform.localPosition = new Vector3(attackTransform.localPosition.x, 0.5f, attackTransform.localPosition.z);
        }
        else
        {
            attackTransform.localPosition = new Vector3(attackTransform.localPosition.x, 1.5f, attackTransform.localPosition.z);
        }
        
        if (_playerStates.IsFacingRight)
        {
            attackTransform.localPosition = new Vector3(1f, attackTransform.localPosition.y, attackTransform.localPosition.z);
        }
        else
        {
            attackTransform.localPosition = new Vector3(-1f, attackTransform.localPosition.y, attackTransform.localPosition.z);
        }
    }

    private bool CanPlayerAttack()
    {
        if (!_playerUpgrades.AttackUnlocked) return false;
        if (!_playerStates.CanControl) return false;
        if (tempAttackCooldown > 0) return false;

        return true;
    }
}
