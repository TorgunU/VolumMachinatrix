using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyRotation : MonoBehaviour
{
    [SerializeField] private float _rotationChangeInterval;

    private PlayerLook _playerLook;
    private Coroutine _rotateCoroutine;

    private void Awake()
    {
        _playerLook = GetComponent<PlayerLook>();

        _rotationChangeInterval = 0.5f;
    }

    private void FixedUpdate()
    {
        FaceOnMousePointer();
    }

    private void FaceOnMousePointer()
    {
        float angle = CalculateAngle();

        if (_rotateCoroutine != null)
        {
            StopCoroutine(_rotateCoroutine);
        }

        _rotateCoroutine = StartCoroutine(RotateSmoothly(angle));
    }

    private float CalculateAngle()
    {
        Vector2 tranformPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 facindDirection = _playerLook.MousePosition - tranformPosition;

        float angle = Mathf.Atan2(-facindDirection.x, facindDirection.y) * Mathf.Rad2Deg;

        Debug.Log(angle);

        return angle;
    }

    private IEnumerator RotateSmoothly(float targetAngle)
    {
        float elapsedTime = 0f;
        float startAngle = transform.eulerAngles.z;

        while (elapsedTime < _rotationChangeInterval)
        {
            float angle = Mathf.LerpAngle(startAngle, targetAngle, elapsedTime / _rotationChangeInterval);
            transform.rotation = Quaternion.Euler(0f, 0f, angle);

            

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _rotateCoroutine = null;
    }
}