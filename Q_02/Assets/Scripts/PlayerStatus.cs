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

    // public float _moveSpeed { get; private set; } 이렇게 사용하거나 위와 같이 변수를 하나 만들어 그변수를 이용하여 값을 변경시켜줌

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        moveSpeed = 5f;
    }
}
