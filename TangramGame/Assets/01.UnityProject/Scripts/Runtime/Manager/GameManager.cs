using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : GioleSingletone<GameManager>
{
    public Dictionary<string, GameObject> gameObjs = default;

    public override void Awake()
    {
        base.Awake();
    }

    protected override void Init()
    {
        base.Init();
        // ���⼭ ���� �Ŵ����� �ʱ�ȭ �ȴ�.
        gameObjs = new Dictionary<string, GameObject>();
    }


}
