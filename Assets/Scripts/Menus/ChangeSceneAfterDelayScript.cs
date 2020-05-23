using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeSceneAfterDelayScript : MonoBehaviour {
	public CanvasRenderer canvas;
	public string _nextScene = "";
	private float i = 1;
	private float _delay = 1f;

	public IEnumerator Start()
	{
		while(i > 0)
		{
			canvas.SetAlpha(i);
			yield return new WaitForSeconds(0.02f);
			i -= 0.02f;
		}		
		yield return new WaitForSeconds(_delay);
		SceneManager.LoadScene(_nextScene);
	}
}
