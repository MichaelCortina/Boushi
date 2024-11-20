using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialouge : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        public GameObject dialougePanel;
        public text dialougeText;
        public string[] dialouge;
        private int index;

		public float wordSpeed;
		public bool playerNear;
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.E) && playerIsClose){
			if(dialougebox.activeInHierarchy){
				resetText();
			}
			else{
				dialougebox.SetActive(true);
				StartCoroutine(Typing());
			}
		}
	}

	IEnumerator Typing(){
		foreach(char letter in dialouge[index].ToCharArray()){
			dialougeText.text += letter;
			yield return new WaitForSeconds(wordSpeed);
		}
	}

	public void resetText(){
		dialougeText.text = "";
		index = 0;
		dialougebox.setActive(false);
	}

	public void NextLine(){
		if(index < dialouge.Length -1 ){
			index++;
			dialougeText.text = "";
			StartCoroutine(Typing());
		}
		
	}

	private void OnTriggerEnter2D(Collider2D other){
			if (other.CompareTag("Player")){
				playerNear = true;
			}
		}
	private void OnTriggerExit2D(Collider2D other){
			if (other.CompareTag("Player")){
				playerNear = false;
				resetText();
			}
		}

