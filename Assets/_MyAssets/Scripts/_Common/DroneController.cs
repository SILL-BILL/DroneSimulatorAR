using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Rigidbody))]
public class DroneController : MonoBehaviour {

	// --------
	#region インスペクタ設定用フィールド
	/// <summary> 
	/// 
	/// </summary>
	#endregion

	// --------
	#region メンバフィールド
	/// <summary> 
	/// 
	/// </summary>
	private Rigidbody rigidbody;
	private float upSpeed = 12.0f;
	private float upSpeedPower;
	private float maxSpeedPower = 563.0f;
	private float minSpeedPower = 0.0f;
	private float rotateX;
	private float rotateY;
	private Quaternion newRotation;
	#endregion

	// --------
	#region MonoBehaviourメソッド
	/// <summary> 
	/// 初期化処理
	/// </summary>
	void Awake() {
		//rigidbodyを取得
		rigidbody = GetComponent<Rigidbody> ();
	}
	/// <summary> 
	/// 開始処理
	/// </summary>
	void Start () {
		//rigidbodyをドローン用に設定
		rigidbody.drag = 0.8f;
	}
	/// <summary> 
	/// 更新処理
	/// </summary>
	void Update () {

		#if UNITY_EDITOR

		if(Input.GetKey("w")){ //前進
			rotateX = 20.0f;
		}else if(Input.GetKey("s")){ //後退
			rotateX = -20.0f;
		}else{
			rotateX = 0;
		}

		if(Input.GetKey("a")){ //左旋回
			rotateY -=1.0f;
		}else if(Input.GetKey("d")){ //右旋回
			rotateY +=1.0f;
		}

		#else

		float v = CrossPlatformInputManager.GetAxisRaw("Vertical");
		if(v > 0.1f){
		rotateX = 20.0f;
		}else if(v < -0.1f){
		rotateX = -20.0f;
		}else{
		rotateX = 0;
		}

		float h = CrossPlatformInputManager.GetAxisRaw ("Horizontal");
		if (h > 0.1f) {
		rotateY += 1;
		} else if (h < -0.1f) {
		rotateY -= 1;
		}

		#endif

		Quaternion newRortation;
		newRortation = Quaternion.Euler (
			rotateX,
			rotateY,
			0
		);

		//TODO
		transform.rotation = Quaternion.Slerp(transform.rotation, newRortation, Time.deltaTime * 0.5f);
//		transform.rotation = Quaternion.Euler(new Vector3(rotateX,rotateY,0));


	}

	/// <summary>
	/// Fixeds the update.
	/// </summary>
	void FixedUpdate(){

		#if UNITY_EDITOR
		if(Input.GetKey("up")){ //上昇
			upSpeedPower += upSpeed;
			//rigidbody.AddForce(transform.up * upSpeed * Time.deltaTime);
		}else if(Input.GetKey("down")){ //下降
			//rigidbody.AddForce(transform.up * -upSpeed * Time.deltaTime);
			upSpeedPower -= upSpeed / 2.0f;
		}else{
			upSpeedPower -= upSpeed / 7.0f;
		}
		#else

		if(CrossPlatformInputManager.GetButton("up")){ //上昇
		upSpeedPower += upSpeed;
		//rigidbody.AddForce(transform.up * upSpeed * Time.deltaTime);
		}else if(CrossPlatformInputManager.GetButton("down")){ //下降
		//rigidbody.AddForce(transform.up * -upSpeed * Time.deltaTime);
		upSpeedPower -= upSpeed / 2.0f;
		}else{
		upSpeedPower -= upSpeed / 7.0f;
		}

		#endif


		//速度補正
		if(upSpeedPower > maxSpeedPower){
			upSpeedPower = maxSpeedPower;
		}else if(upSpeedPower < minSpeedPower){
			upSpeedPower = minSpeedPower;
		}

		rigidbody.AddForce(transform.up * upSpeedPower * Time.deltaTime);

	}

	/// <summary> 
	/// 更新処理
	/// </summary>
	void LateUpdate(){

	}
	#endregion

	// --------
	#region メンバメソッド
	#endregion

}
