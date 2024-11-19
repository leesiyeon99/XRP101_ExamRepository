using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;

    private CubeController _cubeController;
    private Vector3 _cubeSetPoint;

    private void Awake()
    {

    }

    private void Start()
    {
        CreateCube();
        SetCubePosition(3, 0, 3);
    }

    private void SetCubePosition(float x, float y, float z)
    {
        _cubeSetPoint.x = x;
        _cubeSetPoint.y = y;
        _cubeSetPoint.z = z;
        _cubeController.SetPosition(_cubeSetPoint);
    }

    private void CreateCube()
    {
        GameObject cube = Instantiate(_cubePrefab);
        _cubeController = cube.GetComponent<CubeController>();
        _cubeSetPoint = _cubeController.SetPoint;

        // 바꿀 위치로 _cubeSetPoint를 설정해주고
        //SetCubePosition(3, 0, 3);

        // 그 위치로 큐브컨트롤러의 위치를 바꿔줌
        // _cubeController.SetPoint = _cubeSetPoint;

        // 바뀐 위치를 적용시키기 위해 SetPosition함수 사용
        //_cubeController.SetPosition(_cubeSetPoint);
    }
}
