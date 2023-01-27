using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float PLAYER_STEP_ON_Y_ANGLE_MIN = 0.7f; //45도 각도임
    public AudioClip deathSound = default;
    public float jumpForce = default;
    private int jumpCount = default;
    private bool isGrounded = false;
    private bool isDead = false;

    #region playerComponent
    private Rigidbody2D playerRigid = default;
    private Animator playerAni = default;
    private AudioSource playerAudio = default;

    #endregion //playerComponent
    
    // Start is called before the first frame update
    void Start()
    {
        //set player components 여기선 예외처리 디버깅을위해 새로만든 함수사용함
        playerRigid = gameObject.GetComponentMust<Rigidbody2D>();
        playerAni = gameObject.GetComponentMust<Animator>();
        playerAudio = gameObject.GetComponentMust<AudioSource>();

        //Asert 강제로 에러내는거 여기선 조건 : 둘중에 하나라도 비어있는값일때 에러내겠다는거임
        //남발하면안되고 필수요건에서 비어있는값이 아니어야될때 디버깅용도임
        // GFunc.Assert(playerRigid != null || playerRigid != default);
        // GFunc.Assert(playerAni != null || playerAni != default);
        // GFunc.Assert(playerAudio != null || playerAudio != default);
    }

    // Update is called once per frame
    void Update()
    {
        //Update문 최상단에 탈출조건을 먼저 써놓는게 좋음
        //return if : 플레이어 죽었을 때
        if(isDead == true) {return;}

        //{플레이어 점프 로직
        if(Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            jumpCount++;
            //점프키 누르는 순간 움직임을 완전히 멈춤
            playerRigid.velocity = Vector2.zero;
            playerRigid.AddForce(new Vector2(0, jumpForce));
            playerAudio.Play();
        } // if : 플레이어가 점프할 때
        else if(Input.GetMouseButtonDown(0) && 0 < playerRigid.velocity.y)
        {
            //프로그래밍에서 나눗셈은 언제나 곱셈보다 느리기 때문에 곱셈사용
            playerRigid.velocity = playerRigid.velocity * 0.5f;
        } // else if : 플레이어가 공중에 떠 있을 때
        //}플레이어 점프 로직

        //{점프 중이 아닐 때 그라운드에서 사용하는 로직
        //Animator의 Grounded 파라미터를 isGrounded 값으로 갱신
        playerAni.SetBool("Grounded", isGrounded);
        //}점프 중이 아닐 때 그라운드에서 사용하는 로직

        
    } //Update

    //Player Die
    private void Die()
    {
        playerAni.SetTrigger("Die");
        //사망처리보다 사운드를 먼저 세팅하는 이유는 프로그래밍 속도보다 사운드가 느리게 출력되기 때문임
        playerAudio.clip = deathSound;
        playerAudio.Play();

        playerRigid.velocity = Vector2.zero;
        isDead = true;
        //플레이어 사망 시 UI 처리
        GameManager.instance.OnPlayerDead();
    } //Die

    //트리거 충돌 감지 처리를 위한 함수
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("DeadZone") && isDead == false)
        {
            Die();
        }
    } //OnTriggerEnter2D

    //바닥에 닿았는지 체크하는 함수
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //어떤 콜라이더와 닿았으며, 충돌 표면이 위쪽을 보고 있을 때
        //if : 45도 보다 완만한 땅을 밟은 경우
        if(collision.contacts[0].normal.y > PLAYER_STEP_ON_Y_ANGLE_MIN)
        {
            isGrounded = true;
            jumpCount = 0;
        }
    } //OnCollisionEnter2D

    //바닥에서 벗어났는지 체크하는 함수
    private void OnCollisionExit2D(Collision2D collision)
    {
        //어떤 콜라이더에서 떨어진 경우
        isGrounded = false;
    } //OnCollisionExit2D
}
