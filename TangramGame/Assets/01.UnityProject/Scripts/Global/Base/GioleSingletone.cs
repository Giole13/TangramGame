using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GioleSingletone<T> : GioleComponent where T : GioleSingletone<T>
{
    private static T _instance = default;

    public static T Instance
    {
        get
        {
            if (GioleSingletone<T>._instance == default || _instance == default)
            {
                GioleSingletone<T>._instance = 
                    GioleFunc.CreateObj<T>(typeof(T).ToString());
                DontDestroyOnLoad(_instance.gameObject);
            }       // if: �ν��Ͻ��� ��� ���� �� ���� �ν��Ͻ�ȭ �Ѵ�.

            // ���⼭ ���ʹ� �ν��Ͻ��� ���� ������� ������?
            return _instance;
        }
    }

    public override void Awake()
    {
        base.Awake();

    }       // Awake()

    public void Create()
    {
        this.Init();
    }
    protected virtual void Init()
    {
        /* Do Something */
    }
}
