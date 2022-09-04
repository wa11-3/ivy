using UnityEngine;

public class Environment : MonoBehaviour
{
    public SpriteRenderer foreItem;
    public SpriteRenderer middleItem;
    public SpriteRenderer backItem;

    public float enviVelocity;
    public float middleFactor;
    public float backFactor;

    private GameObject player;

    private void Update()
    {
        ManageGround();
        IncreaseVelocity();
    }

    void ManageGround()
    {
        foreItem.size = new Vector2(foreItem.size.x + enviVelocity, foreItem.size.y);
        middleItem.size = new Vector2(middleItem.size.x + (enviVelocity * middleFactor), middleItem.size.y);
        backItem.size = new Vector2(backItem.size.x + (enviVelocity * middleFactor), backItem.size.y);
    }

    void IncreaseVelocity()
    {
        enviVelocity += (Time.deltaTime * 0.0001f);
    }
}
