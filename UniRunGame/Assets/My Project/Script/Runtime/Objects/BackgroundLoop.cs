using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : GComponent
{
    private float width = default;
    public override void Awake()
    {
        base.Awake();
        width = gameObject.GetRectSizeDelta().x;
    }
    

    // Update is called once per frame
    public override void Update()
    {
        //현재 위치가 원점에서 왼쪽으로 whidth이상 이동했을때 위치를 재배치
        if(transform.localPosition.x <= -width)
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        Vector3 offSet = new Vector3(width * 2f, 0f, 0f);
        transform.localPosition = transform.localPosition + offSet;
    }
}
