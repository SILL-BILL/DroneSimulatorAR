using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class CustomUnityARCameraManager : UnityARCameraManager {

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
	/// 更新処理
	/// </summary>
	protected override void Update () {
		base.Update ();
	}
	#endregion

	// --------
	#region メンバメソッド
	/// <summary>
	/// デバックプレーン消す(使用後、再起動するまでデバックプレーンは生成されない)
	/// </summary>
	public void reset(){

		ARKitWorldTrackingSessionConfiguration config = new ARKitWorldTrackingSessionConfiguration();
		config.planeDetection = UnityARPlaneDetection.None;
		config.alignment = startAlignment;
		config.getPointCloudData = getPointCloud;
		config.enableLightEstimation = enableLightEstimation;
		m_session.RunWithConfigAndOptions(config,UnityARSessionRunOption.ARSessionRunOptionRemoveExistingAnchors);

		Debug.Log ("カメラマネージャーをリセット");
	}

	/// <summary>
	/// カメラマネージャーを再起動
	/// </summary>
	public void reboot(){
		StartCoroutine (_reboot());
	}

	IEnumerator _reboot(){

		ARKitWorldTrackingSessionConfiguration config = new ARKitWorldTrackingSessionConfiguration();
		config.planeDetection = UnityARPlaneDetection.None;
		config.alignment = startAlignment;
		config.getPointCloudData = getPointCloud;
		config.enableLightEstimation = enableLightEstimation;
		m_session.RunWithConfigAndOptions(config,UnityARSessionRunOption.ARSessionRunOptionRemoveExistingAnchors);

		yield return new WaitForSeconds (3.5f);

		config.planeDetection = planeDetection;
		config.alignment = startAlignment;
		config.getPointCloudData = getPointCloud;
		config.enableLightEstimation = enableLightEstimation;
		m_session.RunWithConfigAndOptions(config,UnityARSessionRunOption.ARSessionRunOptionRemoveExistingAnchors);

		Debug.Log ("カメラマネージャーを再起動！");
	}

	public override void SetCamera(Camera newCamera){
		base.SetCamera (newCamera);
	}
	protected override void SetupNewCamera(Camera newCamera){
		base.SetupNewCamera (newCamera);
	}


	#endregion

}
