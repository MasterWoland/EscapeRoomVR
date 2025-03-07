﻿using UnityEngine;

namespace DLNK
{
    public class FreeCamera : MonoBehaviour
    {
#if UNITY_EDITOR
        static Texture2D ms_invisibleCursor;
#endif

        public bool enableInputCapture = true;
        public bool holdRightMouseCapture = false;

        public float lookSpeed = 5f;
        public float moveSpeed = 5f;
        public float sprintSpeed = 50f;

        bool m_inputCaptured;
        float m_yaw;
        float m_pitch;

        void Awake()
        {
#if UNITY_EDITOR
            if (!ms_invisibleCursor)
            {
                ms_invisibleCursor = new Texture2D(0, 0);
                //		ms_invisibleCursor.SetPixel(0, 0, new Color32(0, 0, 0, 0));
            }
#endif

            enabled = enableInputCapture;
        }

        void OnValidate()
        {
            if (Application.isPlaying)
                enabled = enableInputCapture;
        }

        void CaptureInput()
        {
            Cursor.lockState = CursorLockMode.Locked;

//#if UNITY_EDITOR
            //	Cursor.SetCursor(ms_invisibleCursor, Vector2.zero, CursorMode.ForceSoftware);
//#else
            Cursor.visible = false;
//#endif
            m_inputCaptured = true;

            m_yaw = transform.eulerAngles.y;
            m_pitch = transform.eulerAngles.x;
        }

        void ReleaseInput()
        {
            Cursor.lockState = CursorLockMode.None;
#if UNITY_EDITOR
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
#else
		Cursor.visible = true;
#endif
            m_inputCaptured = false;
        }

        void OnApplicationFocus(bool focus)
        {
            if (m_inputCaptured && !focus)
                ReleaseInput();
        }

        void Update()
        {
            if (!m_inputCaptured)
            {
                if (!holdRightMouseCapture && Input.GetMouseButtonDown(0))
                    CaptureInput();
                else if (holdRightMouseCapture && Input.GetMouseButtonDown(1))
                    CaptureInput();
            }

            if (!m_inputCaptured)
                return;

            if (m_inputCaptured)
            {
                if (!holdRightMouseCapture && Input.GetKeyDown(KeyCode.Escape))
                    ReleaseInput();
                else if (holdRightMouseCapture && Input.GetMouseButtonUp(1))
                    ReleaseInput();
            }

            var rotStrafe = Input.GetAxis("Mouse X");
            var rotFwd = Input.GetAxis("Mouse Y");

            m_yaw = (m_yaw + lookSpeed * rotStrafe) % 360f;
            m_pitch = (m_pitch - lookSpeed * rotFwd) % 360f;
            transform.rotation = Quaternion.AngleAxis(m_yaw, Vector3.up) * Quaternion.AngleAxis(m_pitch, Vector3.right);

            var speed = Time.deltaTime * (Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : moveSpeed);
            var forward = speed * Input.GetAxis("Vertical");
            var right = speed * Input.GetAxis("Horizontal");
            var up = speed * ((Input.GetKey(KeyCode.E) ? 1f : 0f) - (Input.GetKey(KeyCode.Q) ? 1f : 0f));
            transform.position += transform.forward * forward + transform.right * right + Vector3.up * up;
        }
    }
}