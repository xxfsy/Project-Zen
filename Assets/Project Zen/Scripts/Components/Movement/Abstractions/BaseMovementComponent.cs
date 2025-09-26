using UnityEngine;

public abstract class BaseMovementComponent // в будущем добавить отдельные компоненты отвечающие за прыжок, бег и т.д., чтобы можно было миксовать. Думаю с атакой, супер атакой и т.д. тоже так сделать.
{
    protected float speed;

    protected BaseMovementComponent(float speed)
    {
        this.speed = speed;
    }

    public abstract void Move(Vector2 movementDirection);
}
