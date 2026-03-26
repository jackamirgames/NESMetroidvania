using UnityEngine;

public interface IKnockbackable
{
    public void TakeKnockback(float knockbackForce, Vector2 otherObjPos, float knockbackTime);
}
