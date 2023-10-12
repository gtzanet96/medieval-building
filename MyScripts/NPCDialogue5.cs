using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue5 : MonoBehaviour {

	bool inChat = false; // να ενεργοποιειται/απενεργοποιειται οταν το βρισκομαστε εντος η εκτος του chat window αντιστοιχα
	bool inDialogue1 = true;
	bool inDialogueTopSubTree = false; 
	bool inDialogueBotSubTree = false;
	bool inDialogueBotTopSubTree = false;
	bool inDialogueBotBotSubTree = false;
	bool inDialogueBotBotTopSubTree = false;
	public GameObject goldIcon;
	bool goldReturned = false;

	[Header("Object")]
	public GameObject npcWindow;
	public Text chatText;
	public Text topText;
	public Text botText;
	[Header("All Possible Dialogue Options")]
	public string greeting;
	[Header("Dialogue1")]
	public string top1;
	public string top1Response;
	public string bot1;
	public string bot1Response;
	[Header("Dialogue1 TOP Subtree")]
	public string top2;
	public string bot2;
	public string bot2Response;
	[Header("Dialogue1 BOT SubTree")]
	public string top3;
	public string top3Response;
	public string bot3;
	public string bot3Response;


	[Header("Dialogue1 BOT,TOP SubTree")]
	public string top4;
	public string bot4;
	public string bot4Response;
	[Header("Dialogue1 BOT,BOT SubTree")]
	public string top5;
	public string top5Response;
	public string bot5;
	[Header("Dialogue1 BOT,BOT,TOP Subtree")]
	public string top6;
	public string bot6;


	void Start () {

	}


	void Update () {
		if (NPCDialogue.mission == 4) {
			if (CheckForChat3.entrance3 == true && CheckEvents.lootTaken == true) {
				if (Input.GetKeyDown ("q")) {
					//δουλευει μονο αν εισαι εντος range και το chatWindow δεν ειναι ηδη ανοικτο
					if (!inChat) {
						npcWindow.gameObject.SetActive (true);
						chatText.GetComponent<Text> ().text = greeting;
						loadDialogue1 ();
					}
				}
			} else {
				CloseDialogue ();
			}
		}

	}

	//πρωτη σειρα μηνυματων
	void loadDialogue1(){
		inChat = true;
		inDialogue1 = true;
		inDialogueTopSubTree = false;
		inDialogueBotSubTree = false;
		inDialogueBotTopSubTree = false;
		inDialogueBotBotSubTree = false;
		inDialogueBotBotTopSubTree = false;
		topText.GetComponent<Text> ().text = top1;
		botText.GetComponent<Text> ().text = bot1;
	}

	void loadDialogue1TopSubTree(){
		inChat = true;
		inDialogue1 = false;
		inDialogueTopSubTree = true;
		inDialogueBotSubTree = false;
		inDialogueBotTopSubTree = false;
		inDialogueBotBotSubTree = false;
		inDialogueBotBotTopSubTree = false;
		topText.GetComponent<Text> ().text = top2;
		botText.GetComponent<Text> ().text = bot2;
	}

	void loadDialogue1BotSubTree(){
		inChat = true;
		inDialogue1 = false;
		inDialogueTopSubTree = false;
		inDialogueBotSubTree = true;
		inDialogueBotTopSubTree = false;
		inDialogueBotBotSubTree = false;
		inDialogueBotBotTopSubTree = false;
		topText.GetComponent<Text> ().text = top3;
		botText.GetComponent<Text> ().text = bot3;
	}

	void loadDialogue1BotTopSubTree(){
		inChat = true;
		inDialogue1 = false;
		inDialogueTopSubTree = false;
		inDialogueBotSubTree = false;
		inDialogueBotTopSubTree = true;
		inDialogueBotBotSubTree = false;
		inDialogueBotBotTopSubTree = false;
		topText.GetComponent<Text> ().text = top4;
		botText.GetComponent<Text> ().text = bot4;
	}

	void loadDialogue1BotBotSubTree(){
		inChat = true;
		inDialogue1 = false;
		inDialogueTopSubTree = false;
		inDialogueBotSubTree = false;
		inDialogueBotTopSubTree = false;
		inDialogueBotBotSubTree = true;
		inDialogueBotBotTopSubTree = false;
		topText.GetComponent<Text> ().text = top5;
		botText.GetComponent<Text> ().text = bot5;
	}

	void loadDialogue1BotBotTopSubTree(){
		inChat = true;
		inDialogue1 = false;
		inDialogueTopSubTree = false;
		inDialogueBotSubTree = false;
		inDialogueBotTopSubTree = false;
		inDialogueBotBotSubTree = false;
		inDialogueBotBotTopSubTree = true;
		topText.GetComponent<Text> ().text = top6;
		botText.GetComponent<Text> ().text = "";
	}

	//ΚΟΥΜΠΙΑ
	//Εαν ο παικτης πατησει το ΠΑΝΩ κουμπι οποιαδηποτε στιγμη σε οποιοδηποτε παραθυρο
	public void Top(){
		if (inDialogue1) {
			chatText.GetComponent<Text> ().text = top1Response;
			loadDialogue1TopSubTree ();
		} else if (inDialogueTopSubTree) {
			CloseDialogue ();
		} else if (inDialogueBotSubTree) {
			chatText.GetComponent<Text> ().text = top3Response;
			loadDialogue1BotTopSubTree ();
		} else if (inDialogueBotTopSubTree) {
			CloseDialogue ();
		} else if (inDialogueBotBotSubTree) {
			chatText.GetComponent<Text> ().text = top5Response;
			loadDialogue1BotBotTopSubTree ();
		} else if (inDialogueBotBotTopSubTree) {
			CloseDialogue ();
			NPCDialogue.mission = 5;
		}
	}

	//Εαν ο παικτης πατησει το ΚΑΤΩ κουμπι οποιαδηποτε στιγμη σε οποιοδηποτε παραθυρο
	public void Bot(){
		if (inDialogue1) {
			chatText.GetComponent<Text> ().text = bot1Response;
			loadDialogue1BotSubTree ();
			if (goldReturned == false) {
				goldIcon.SetActive (false);
				goldReturned = true;
			}
		} else if (inDialogueTopSubTree) {
			chatText.GetComponent<Text> ().text = bot1Response; //σωστο ειναι
			loadDialogue1BotSubTree ();
			if (goldReturned == false) {
				goldIcon.SetActive (false);
				goldReturned = true;
			}
		} else if (inDialogueBotSubTree) {
			chatText.GetComponent<Text> ().text = bot3Response;
			loadDialogue1BotBotSubTree ();
		} else if (inDialogueBotBotSubTree) {
			CloseDialogue ();
		} else if (inDialogueBotTopSubTree) {
			chatText.GetComponent<Text> ().text = bot4Response;
			loadDialogue1BotBotSubTree ();
		} 
	}

	void CloseDialogue(){
		npcWindow.gameObject.SetActive (false);
		inChat = false;
	}
}