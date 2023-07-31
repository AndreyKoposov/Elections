using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableImage : MonoBehaviour
{
    private RectTransform m_RectTransform;
    [SerializeField] private Vector3 position;

    private void Awake()
    {
        m_RectTransform = GetComponent<RectTransform>();
    }

    public void ResetImage()
    {
        gameObject.SetActive(false);
        LeanTween.moveLocalX(gameObject, position.x, 0.01f);
        LeanTween.moveLocalY(gameObject, position.y, 0.01f);
    }
}
