using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _levelGameObject;

    private ILevel _levelController;

    private void Start()
    {
        _levelController = _levelGameObject.GetComponent<ILevel>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _levelController.NextLevel();
        }
    }
}
