using UnityEngine;

public class MoveController : MonoBehaviour
{
    public CharacterController CharacterController;
    public float Speed = 5F;

    private void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        var forward = new Vector3(x, 0, z);
        CharacterController.Move(forward * (Time.deltaTime * Speed));
        transform.forward = Vector3.Slerp(transform.forward, forward, 0.1F);
    }
}