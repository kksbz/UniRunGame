using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBgController : ScrollingObjController
{
    public override void Start()
    {
        base.Start();
    } //Start

    public override void Update()
    {
        base.Update();
    } //Update

    protected override void InitObjsPosition()
    {
        base.InitObjsPosition();
        
        //생성한 오브젝트의 위치를 설정한다
        float horizonPos = objPrefabSize.x * (scrollingObjCount - 1) * (-1) * 0.5f;
        for (int i = 0; i < scrollingObjCount; i++)
        {
            scrollingPool[i].SetLocalPos(horizonPos, 0f, 0f);
            // GFunc.Log($"Horizon position : {horizonPos}");
            horizonPos = horizonPos + objPrefabSize.x;
        } // loop: 생성한 오브젝트를 가로로 왼쪽부터 차례대로 정렬하는 루프
    } //InitObjsPosition

    protected override void RepositionFirstObj()
    {
        base.RepositionFirstObj();

        float lastScrObjCurrentXPos = scrollingPool[scrollingObjCount - 1].transform.localPosition.x;
        //스크롤링 오브젝트의 마지막 오브젝트가 화면 상의 절반정도 Draw 되는 때
        if (lastScrObjCurrentXPos <= objPrefabSize.x * 0.5f)
        {
            //첫번째 오브젝트의 localPosition을
            float lastScrObjInitXPos = Mathf.Floor(scrollingObjCount * 0.5f) * objPrefabSize.x + (objPrefabSize.x * 0.5f);
            scrollingPool[0].SetLocalPos(lastScrObjInitXPos, 0f, 0f);
            //첫번째 오브젝트의 위치를 마지막으로 옮김
            scrollingPool.Add(scrollingPool[0]);
            scrollingPool.RemoveAt(0);
        }
    } //RepositionFirstObj
}
