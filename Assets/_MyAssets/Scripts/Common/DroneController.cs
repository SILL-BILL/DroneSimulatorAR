using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	private float upSpeed = 1000.0f;
	private float rotateX;
	private float rotateY;
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
		rigidbody.drag = 1f;
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
		#endif

		transform.rotation = Quaternion.Euler(new Vector3(rotateX,rotateY,0));
	}

	/// <summary>
	/// Fixeds the update.
	/// </summary>
	void FixedUpdate(){

		#if UNITY_EDITOR
		if(Input.GetKey("up")){ //上昇
			rigidbody.AddForce(transform.up * upSpeed * Time.deltaTime);
		}else if(Input.GetKey("down")){ //下降
			rigidbody.AddForce(transform.up * -upSpeed * Time.deltaTime);
		}
		#endif
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
