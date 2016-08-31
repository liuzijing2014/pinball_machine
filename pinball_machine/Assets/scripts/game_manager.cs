using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class game_manager : MonoBehaviour {

	public Text score_text;
	public Button restart_button;

	private int score;
	private int life;

	// Use this for initialization
	void Start () {
		score = 0;
		life = 1;
		restart_button.interactable = false;
	}

	public void UpdateScore(){
		score++;
		score_text.text = score.ToString ();
	}

	public void AddMoreLife(int num){
		life += num;
	}

	public void EndGame(){
		life--;
		if (life != 0) {
			return;
		}
		restart_button.interactable = true;
		Time.timeScale = 0;
	}

	public void ResumeGame(){
		Time.timeScale = 1;
		SceneManager.LoadScene ("main");
		restart_button.interactable = false;
	}
}
