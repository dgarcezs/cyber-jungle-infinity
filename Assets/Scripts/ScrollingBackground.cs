using UnityEngine;
using UnityEngine.UIElements;

public class ScrollingBackground : MonoBehaviour
{

    [SerializeField]    
    private float speed = 0.5f;

    [SerializeField]
    private SpriteRenderer backgroundSprite;

    private float startPositionY;
    private float endPositionY;

    private void OnValidate()
    {
        if (backgroundSprite == null)
        {
            backgroundSprite = GetComponentInChildren<SpriteRenderer>();
        }
    }

    private void Start()
    {
        startPositionY = backgroundSprite.transform.localPosition.y;
        endPositionY = startPositionY - backgroundSprite.bounds.extents.y;
    }

    private void Update()
    {
        backgroundSprite.transform.Translate(Vector2.down * speed * Time.deltaTime, Space.World);
        LoopBackground();
    }

    private void LoopBackground()
    {
        Vector3 backgroudPosition = backgroundSprite.transform.localPosition;
        if (backgroudPosition.y < endPositionY)
        {
            float deltaPosition = backgroundSprite.transform.localPosition.y - endPositionY;
            backgroudPosition.y = startPositionY - deltaPosition;
            backgroundSprite.transform.localPosition = backgroudPosition;
        }
    }

}
