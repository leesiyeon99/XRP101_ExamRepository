using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float moveSpeed;
    public float MoveSpeed
    {
        get => moveSpeed;
        private set => moveSpeed = value;
    }

    // public float _moveSpeed { get; private set; } �̷��� ����ϰų� ���� ���� ������ �ϳ� ����� �׺����� �̿��Ͽ� ���� ���������

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        moveSpeed = 5f;
    }
}
