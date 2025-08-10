using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float speed = 2f;
    public Transform[] sprites;

    private float viewHeight;

    void Start()
    {
        viewHeight = Camera.main.orthographicSize * 2;

        // �ʱ� ��ġ �ڵ� ���� (������ �Ʒ���)
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].localPosition = Vector3.up * viewHeight * (sprites.Length - 1 - i);
        }
    }

    void Update()
    {
        // ��� ��ü�� �Ʒ��� �̵�
        transform.position += Vector3.down * speed * Time.deltaTime;

        // �� ��������Ʈ�� Ȯ���ؼ� ȭ�� �Ʒ��� ������ �������� üũ
        foreach (Transform sprite in sprites)
        {
            if (sprite.position.y < -viewHeight)
            {
                // ���� ���� �ִ� ��������Ʈ�� ã��
                Transform topSprite = GetHighestSprite();

                // �� ���� �̵���Ŵ
                sprite.localPosition = topSprite.localPosition + Vector3.up * viewHeight;
            }
        }
    }

    // ���� ���� �ִ� ��������Ʈ�� ��ȯ
    Transform GetHighestSprite()
    {
        Transform highest = sprites[0];
        foreach (Transform sprite in sprites)
        {
            if (sprite.localPosition.y > highest.localPosition.y)
            {
                highest = sprite;
            }
        }
        return highest;
    }
}
