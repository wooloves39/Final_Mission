﻿using UnityEngine;
using System.Collections;

// 캐릭터를 이동시킨다.
//	캐릭터 이동 알고리즘
//	
// 	업데이트시 호출 됨
//	1. 지면에 닿았는가 ? -> 6번으로
//	2. 목적지를 구한다.  Vector3 destination
//	3. 캐릭터의 도착여부 판정
//	4. 이동속도 벡터 더함(기본 5설정)
//	5. 방향처리
//	6. 중력 가속을 더함
//	7. 이동 -> 다시 1번 반복
//
//
//
public class CharacterMove : MonoBehaviour {
	// 중력값.
	const float GravityPower = 9.8f; 
	//　목적지에 도착했다고 보는 정지 거리.
	const float StoppingDistance = 0.6f;
	
	// 현재 이동 속도.
	Vector3 velocity = Vector3.zero; 
	// 캐릭터 컨트롤러의 캐시.
	CharacterController characterController; 
	// 도착했는가(도착했다 true / 도착하지 않았다 false).
	public bool arrived = false; 
	
	// 방향을 강제로 지시하는가.
	bool forceRotate = false;
	
	// 강제로 향하게 하고 싶은 방향.
	Vector3 forceRotateDirection;
	
	// 목적지.
	public Vector3 destination; 
	
	// 이동 속도.
	public float walkSpeed = 5.0f;
	
	// 회전 속도.
	public float rotationSpeed = 360.0f;
	
	
	
	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController>();
		destination = transform.position;


	}
	
	// Update is called once per frame
	void Update () {
		
		// 이동 속도 velocity를 갱신한다.
		if (characterController.isGrounded) {
			Vector3 destinationXZ = destination;

			// 목적지와 현재 위치 높이를 똑같이 한다.
			destinationXZ.y = transform.position.y;
			

			// 목적지까지 거리와 방향을 구한다.
			Vector3 direction = (destinationXZ - transform.position).normalized;
			float distance = Vector3.Distance(transform.position,destinationXZ);
			
			// 현재 속도를 보관한다.
			Vector3 currentVelocity = velocity;
			
			//　목적지에 가까이 왔으면 도착.
			if (arrived || distance < StoppingDistance)
				arrived = true;
			
			
			// 이동 속도를 구한다.
			if (arrived)
				velocity = Vector3.zero;
			else 
				velocity = direction * walkSpeed;

			{//키보드 입력을 도운다.
				if (Input.GetKey (KeyCode.A)) {
					forceRotateDirection= Object.
				}
				if (Input.GetKey (KeyCode.W))
					transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
				if (Input.GetKey (KeyCode.S))
					transform.rotation = Quaternion.AngleAxis(-180, Vector3.up);
				if (Input.GetKey (KeyCode.D))
					transform.rotation = Quaternion.AngleAxis(90, Vector3.up);

				if (Input.GetKey (KeyCode.W)&&Input.GetKey (KeyCode.A))
					transform.rotation = Quaternion.AngleAxis(-45, Vector3.up);
				if (Input.GetKey (KeyCode.W)&&Input.GetKey (KeyCode.D))
					transform.rotation = Quaternion.AngleAxis(45, Vector3.up);
				if (Input.GetKey (KeyCode.S)&&Input.GetKey (KeyCode.A))
					transform.rotation = Quaternion.AngleAxis(-135, Vector3.up);
				if (Input.GetKey (KeyCode.S)&&Input.GetKey (KeyCode.D))
					transform.rotation = Quaternion.AngleAxis(135, Vector3.up);
			}

			
			// 부드럽게 보간 처리.
			{velocity = Vector3.Lerp(currentVelocity, velocity,Mathf.Min (Time.deltaTime * 5.0f ,1.0f));
			velocity.y = 0;
			}
			
			if (!forceRotate) {
				// 바꾸고 싶은 방향으로 변경한다. 
				if (velocity.magnitude > 0.1f && !arrived) { 
					// 이동하지 않았다면 방향은 변경하지 않는다.
					Quaternion characterTargetRotation = Quaternion.LookRotation(direction);
					transform.rotation = Quaternion.RotateTowards(transform.rotation,characterTargetRotation,rotationSpeed * Time.deltaTime);
				}
			} else {
				// 강제로 방향을 지정한다.
				Quaternion characterTargetRotation = Quaternion.LookRotation(forceRotateDirection);
				transform.rotation = Quaternion.RotateTowards(transform.rotation,characterTargetRotation,rotationSpeed * Time.deltaTime);
			}
			
		}

		//8방향으로 움직임

		
		// 중력.
		velocity += Vector3.down * GravityPower * Time.deltaTime;
		
		// 땅에 닿아 있다면 지면을 꽉 누른다.
		// (유니티의 CharactorController 특성 때문에).
		Vector3 snapGround = Vector3.zero;
		if (characterController.isGrounded)
			snapGround = Vector3.down;
		
		// CharacterController를 사용해서 움직인다.
		characterController.Move(velocity * Time.deltaTime+snapGround);
		
		if (characterController.velocity.magnitude < 0.1f)
			arrived = true;
		
		// 강제로 방향 변경을 해제한다.
		if (forceRotate && Vector3.Dot(transform.forward,forceRotateDirection) > 0.99f)
			forceRotate = false;
		
		
	}
	
	// 목적지를 설정한다. 인수 destination은 목적지.
	public void SetDestination(Vector3 destination)
	{
		arrived = false;
		this.destination = destination;
	}
	
	// 지정한 방향으로 향한다.
	public void SetDirection(Vector3 direction)
	{
		forceRotateDirection = direction;
		forceRotateDirection.y = 0;
		forceRotateDirection.Normalize();
		forceRotate = true;
	}
	
	// 이동을 그만둔다.
	public void StopMove()
	{
		// 현재 지점을 목적지로 한다.
		destination = transform.position; 
	}
	
	// 목적지에 도착했는지 조사한다(도착했다 true / 도착하지 않았다 false).
	public bool Arrived()
	{
		return arrived;
	}
	
	
}
