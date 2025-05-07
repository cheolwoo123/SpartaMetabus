using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;
    public Tilemap map; 
    private Vector3 offset;
    private Vector2 minBounds;
    private Vector2 maxBounds;
    private float halfHeight;
    private float halfWidth;

    void Start()
    {
        offset = new Vector3(0, 0, -10f);

        // ī�޶� ũ�� ���
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;

        // Ÿ�ϸ� ���� ���
        if (map != null)
        {
            map.CompressBounds();
            Bounds bounds = map.localBounds;
            minBounds = bounds.min;
            maxBounds = bounds.max;

        }
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        float Padding = 0.8f; 
        // ī�޶� ���� ũ�� ����ؼ� Clamp
        float clampedX = Mathf.Clamp(desiredPosition.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
        float clampedY = Mathf.Clamp(desiredPosition.y, minBounds.y + halfHeight, maxBounds.y - halfHeight - Padding);

        Vector3 clampedPosition = new Vector3(clampedX, clampedY, desiredPosition.z);

        transform.position = Vector3.Lerp(transform.position, clampedPosition, Time.deltaTime * smoothSpeed);
    }
}
