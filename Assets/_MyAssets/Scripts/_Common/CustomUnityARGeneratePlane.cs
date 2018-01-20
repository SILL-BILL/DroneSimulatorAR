using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class CustomUnityARGeneratePlane : UnityARGeneratePlane {

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
	#endregion

	// --------
	#region MonoBehaviourメソッド
	/// <summary> 
	/// 開始処理
	/// </summary>
	protected override void Start () {
		base.Start ();
	}
	/// <summary>
	/// Raises the destroy event.
	/// </summary>
	protected override void OnDestroy(){
		base.OnDestroy ();
	}
	/// <summary>
	/// Raises the GU event.
	/// </summary>
	protected override void OnGUI(){
		base.OnGUI ();
	}
	#endregion

	// --------
	#region メンバメソッド
	/// <summary>
	/// Gets the AR plane count.
	/// </summary>
	/// <returns>The AR plane count.</returns>
	public int getARPlaneCount(){

		int cnt = 0;
		List<ARPlaneAnchorGameObject> arpags = unityARAnchorManager.GetCurrentPlaneAnchors ();

		cnt = arpags.Count;

		Debug.Log ("MOB^平面の数："+cnt);

		return cnt;

	}
	#endregion

}
