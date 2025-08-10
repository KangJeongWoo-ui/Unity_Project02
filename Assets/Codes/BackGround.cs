using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float speed = 2f;
    public Transform[] sprites;

    private float viewHeight;

    void Start()
    {
        viewHeight = Camera.main.orthographicSize * 2;

        // 초기 위치 자동 설정 (위에서 아래로)
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].localPosition = Vector3.up * viewHeight * (sprites.Length - 1 - i);
        }
    }

    void Update()
    {
        // 배경 전체를 아래로 이동
        transform.position += Vector3.down * speed * Time.deltaTime;

        // 각 스프라이트를 확인해서 화면 아래로 완전히 나갔는지 체크
        foreach (Transform sprite in sprites)
        {
            if (sprite.position.y < -viewHeight)
            {
                // 가장 위에 있는 스프라이트를 찾음
                Transform topSprite = GetHighestSprite();

                // 그 위로 이동시킴
                sprite.localPosition = topSprite.localPosition + Vector3.up * viewHeight;
            }
        }
    }

    // 가장 위에 있는 스프라이트를 반환
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
