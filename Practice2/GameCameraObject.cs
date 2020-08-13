using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UItransform : MonoBehaviour
{
    [SerializeField] Transform _transform;
    [SerializeField] Transform aTransform;
    [SerializeField] Transform bTransform;
    [SerializeField] Transform cTransform;
    [SerializeField] Transform dTransform;

    public void AButton()
    {
        _transform.position = aTransform.position;
    }

    public void BButton()
    {
        _transform.position = bTransform.position;
    }

    public void CButton()
    {
        _transform.position = cTransform.position;
    }

    public void DButton()
    {
        _transform.position = dTransform.position;
    }
}