using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObjController : MonoBehaviour
{
    public string prefabName = default;
    public int scrollingObjCount = default;
    public float scrollingSpeed = 100.0f;
    protected GameObject objPrefab = default;
    protected Vector2 objPrefabSize = default;
    protected List<GameObject> scrollingPool = default;
    protected float prefabYPos = default;

    public virtual void Start()
    {
        objPrefab = gameObject.FindChildObj(prefabName);
        scrollingPool = new List<GameObject>();
        GFunc.Assert(objPrefab != null || objPrefab != default);
        objPrefabSize = objPrefab.GetRectSizeDelta();
        prefabYPos = objPrefab.transform.localPosition.y;
        //{스크롤링 풀을 생성해서 주어진 수만큼 초기화
        GameObject tempObj = default;
        if (scrollingPool.Count <= 0)
        {
            for (int i = 0; i < scrollingObjCount; i++)
            {
                tempObj = Instantiate(objPrefab, objPrefab.transform.position,
                objPrefab.transform.rotation, transform);
                scrollingPool.Add(tempObj);
                tempObj = default;
            } //loop : 스크롤링 오브젝트를 주어진 수만큼 초기화 하는 루프
        } //if : scrolling pool을 초기화 함
        objPrefab.SetActive(false);
        //}스크롤링 풀을 생성해서 주어진 수만큼 초기화

        InitObjsPosition();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        //스크롤링할 오브젝트가 존재하지 않는 경우 탈출
        if (scrollingPool == default || scrollingPool.Count <= 0)
        {
            return;
        }

        if (GameManager.instance.isGameOver == false)
        {
            //{배경에 움직임을 주는 로직
            //스크롤링할 오브젝트가 존재하는 경우
            for (int i = 0; i < scrollingObjCount; i++)
            {
                //배경이 왼쪽으로 움직이도록 하는 루프
                scrollingPool[i].AddLocalPos(scrollingSpeed * Time.deltaTime * (-1), 0f, 0f);
            }

            RepositionFirstObj();
            //}배경에 움직임을 주는 로직
        } // 게임이 진행중인경우
    } //Update

    //생성한 오브젝트의 위치를 설정하는 함수
    protected virtual void InitObjsPosition()
    {
        /* Do Something */
        //ScrollingBgController스크립트에 오버라이드했음
    } //InitObjsPosition

    
    protected virtual void RepositionFirstObj()
    {
        /* Do Something */
        //ScrollingBgController스크립트에 오버라이드했음
    } //RepositionFirstObj
}
