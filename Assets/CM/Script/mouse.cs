using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour
{
    public GameObject player;
    public float m_Speed = 0.05f;
    public float m_HighSpeed = 0.25f;
    const float s_VerticalSpeedBias = 0.5f;

    public float m_ScrollSpeed = 1.25f;

    void Update()
    {
        RelativeMovement(GetMouseLook(), GetDeltaMovement(GetSpeed()));

        if (Input.GetKey(KeyCode.R))
        {
            //Debug.Log("想做相機位置重置但沒做出來");
            this.transform.position = player.transform.position + new Vector3(0.0f, 40.0f, -10.0f);
          
        }
    }

    private void RelativeMovement(Vector3 mouseLook, Vector3 deltaMovement)
    {
        transform.Translate(deltaMovement, Space.World);
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            transform.Rotate(Vector3.right, mouseLook.x, Space.Self);
            transform.Rotate(Vector3.up, mouseLook.y, Space.World);
        }
    }

    Vector3 m_LastMousePos = Vector3.zero;
    private Vector3 GetDeltaMovement(float speed)
    {
        Vector3 delta = default;

        if (Input.GetMouseButton(2))
        {
            if (Input.GetMouseButtonDown(2))
            {
                m_LastMousePos = Input.mousePosition;
            }
            Vector3 diff = m_LastMousePos - Input.mousePosition;
            delta += transform.TransformVector(diff) * speed;
            m_LastMousePos = Input.mousePosition;
        }
        if (Input.mouseScrollDelta.y != 0f)
            delta += transform.forward * Input.mouseScrollDelta.y * m_ScrollSpeed;
        if (Input.mouseScrollDelta.x != 0f)
            delta += transform.right * Input.mouseScrollDelta.x * m_ScrollSpeed;

        return delta;
    }

    private float GetSpeed()
    {
        return Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ?
            m_HighSpeed :
            m_Speed;
    }

    private Vector2 GetMouseLook()
    {
        bool mouse1 = Input.GetMouseButton(1);
        if (mouse1 && Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (!mouse1 && Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            return new Vector2(
                -Input.GetAxis("Mouse Y"), 
                Input.GetAxis("Mouse X"));
        }
        return Vector2.zero;
    }

    
}
