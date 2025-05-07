using UnityEngine;

public class MainCharacterController : BaseController
{
    protected override void HandleAction()
    {
        // 키보드 이동
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")).normalized;

        // 마우스 바라보기
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction3D = mouseWorldPosition - transform.position;
        direction3D.z = 0f;
        Vector2 direction = new Vector2(direction3D.x, direction3D.y);

        if (direction != Vector2.zero)
            lookDirection = direction.normalized;
    }

}
