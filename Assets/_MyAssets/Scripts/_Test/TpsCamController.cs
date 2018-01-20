using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpsCamController : MonoBehaviour {

	// --------
	#region インスペクタ設定用フィールド
	[SerializeField]
	private Transform targetTransform = null;
	/// <summary>
	/// The duration.
	/// </summary>
	[SerializeField]
	private float duration = 3.0f;
	#endregion

	// --------
	#region メンバフィールド
	/// <summary> 
	/// 
	/// </summary>
	private Vector3 offset = Vector3.zero;
	#endregion

	// --------
	#region MonoBehaviourメソッド
	/// <summary> 
	/// 初期化処理
	/// </summary>
	void Awake() {
		offset = transform.position - targetTransform.transform.position;
	}
	/// <summary> 
	/// 更新処理
	/// </summary>
	void LateUpdate(){
		Vector3 newPosition = transform.position;
		newPosition.x = targetTransform.transform.position.x + offset.x;
		newPosition.y = targetTransform.transform.position.y + offset.y;
		newPosition.z = targetTransform.transform.position.z + offset.z;
		transform.position = Vector3.Lerp(transform.position, newPosition, duration * Time.deltaTime);

//		transform.RotateAround(targetTransform.position, Vector3.up, 200f * duration * Time.deltaTime);
	}
	#endregion

	// --------
	#region メンバメソッド
	#endregion

}
