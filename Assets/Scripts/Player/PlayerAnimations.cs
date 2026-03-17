using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator _animator;

    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _animator.enabled = true;

        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        _playerMovement.PlayerJumped += UpdateIsGrounded;
        _playerMovement.PlayerStartedMovement += UpdateHorizontalDir;
        _playerMovement.PlayerChangedFacedDirection += UpdateIsFacingRight;
    }

    private void OnDisable()
    {
        _playerMovement.PlayerJumped -= UpdateIsGrounded;
        _playerMovement.PlayerStartedMovement -= UpdateHorizontalDir;
        _playerMovement.PlayerChangedFacedDirection -= UpdateIsFacingRight;
    }

    private void UpdateIsGrounded(bool isGrounded)
    {
        _animator.SetBool("IsGrounded", isGrounded);
    }

    private void UpdateHorizontalDir(float dir)
    {
        _animator.SetFloat("HorizontalDir", dir);
    }

    private void UpdateIsFacingRight(bool isFacingRight)
    {
        if (isFacingRight)
        {
            _animator.SetFloat("IsFacingRight", 1);
        }
        else
        {
            _animator.SetFloat("IsFacingRight", 0);
        }
    }
}
