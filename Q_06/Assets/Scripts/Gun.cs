using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using static UnityEngine.UI.Image;

public class Gun : MonoBehaviour
{
    [SerializeField] private float _range;
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] PlayerController _playerController;

    private void Update()
    {
        //Debug.DrawRay(_playerController._muzzlePoint.position, _playerController._muzzlePoint.forward, Color.red);
    }

    public void Fire(Transform origin)
    {
        RaycastHit hit;

        if (Physics.Raycast(_playerController._muzzlePoint.position, _playerController._muzzlePoint.forward, out hit, _range, _targetLayer))
        {
            Debug.Log($"{hit.transform.name} Hit!!");
        }
    }
    
}
