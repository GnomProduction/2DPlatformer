using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OnClickPlayScript : MonoBehaviour {

	public void GoToFirstLevel()
	{
		SceneManager.LoadScene ("Level1Scene");
	}
}
