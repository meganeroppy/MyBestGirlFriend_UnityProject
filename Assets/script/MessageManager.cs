using UnityEngine;
using System.Collections;

public class MessageManager : MonoBehaviour {

	public TextAsset scenario1_proto;
	public TextAsset scenario2_proto;
	public TextAsset end1_proto;
	public TextAsset setup;
	private static string[] textLines;
	private static string curLineMsg;
	private static int curLine;
	// Use this for initialization
	void Start () {
		switch(GameManager.cur_scene){
		case GameManager.SCENE.SETUP:
			textLines = setup.text.Split('\n');
			break;
		case GameManager.SCENE.MAIN:
			switch(GameManager.cur_scenario){
			case GameManager.SCENARIO.SCENARIO1:
				textLines = scenario1_proto.text.Split('\n');
				break;
			case GameManager.SCENARIO.SCENARIO2:
				textLines = scenario2_proto.text.Split('\n');
				break;
			case GameManager.SCENARIO.END1:
				textLines = end1_proto.text.Split('\n');
				break;
			default:
				break;
			}	//end of switch "SCENARIO"
			break;
		default:
			break;
		}	//end of switch "SCENE"
		curLine = 0;
		curLineMsg = textLines[curLine];
	}

//	void Start(string next){
//		if(next == "")
//	}
	
	// Update is called once per frame
	void Update () {
	}

	public static string AnalyzeLine(){
		curLineMsg = textLines[curLine++];
		if( curLineMsg.Contains("<PLAYER>") ){		//replace playerName
			Debug.Log ("replacePName");
			curLineMsg = curLineMsg.Replace("<PLAYER>", GameManager.GetPlayerName());
		}

		if(curLineMsg.EndsWith("]")){			//facial change
			string[] tmpLine = curLineMsg.Split('[');
			int startPos = 0;
			int endPos = tmpLine[1].IndexOf("]");
			string optionCmd = tmpLine[1].Substring(startPos, endPos - startPos);
			GameObject.Find("ImageManager").SendMessage("switchImg", optionCmd, SendMessageOptions.RequireReceiver);
			return tmpLine[0];
		}else if(curLineMsg.EndsWith("}")){		//event flag
			int startPos = curLineMsg.IndexOf("{") + 1;
			int endPos = curLineMsg.IndexOf("}");
			curLineMsg = curLineMsg.Substring(startPos, endPos - startPos);
			switch(curLineMsg){
				case "BG":
					GameObject.Find("ImageManager").SendMessage("switchImg", "NONE", SendMessageOptions.RequireReceiver);
					return " ";
				case "CHOICE":
					curLineMsg = textLines[curLine];		//get line containing choices, points, and reactions
					string[] questionArray = curLineMsg.Split(',');
					GameObject.Find("GUIManager").SendMessage("MakeChoices", questionArray, SendMessageOptions.RequireReceiver);
					curLine++;
					return "CHOICE";
				case "JUNCTION":
					curLineMsg = textLines[curLine];		//get line containing 2 results
					string[] resultArray = curLineMsg.Split(',');
					GameObject.Find("GUIManager").SendMessage("DispResult", resultArray, SendMessageOptions.RequireReceiver);
					curLine++;
					return " ";
				case "INPUTNAME":
					return "INPUTNAME";
				case "ENDSETUP":
					curLine = 0;
				return "ENDSETUP";
			default:
				print ("curLineMsg = ".ToString() + curLineMsg);
					break;
			}
		}
		return curLineMsg;
	}

	public static string AnalyzeLine(string text){
		if(text.EndsWith("]")){		//facial change
			string[] tmpLine = text.Split('[');
			int startPos = 0;
			int endPos = tmpLine[1].IndexOf("]");
			string optionCmd = tmpLine[1].Substring(startPos, endPos - startPos);
			GameObject.Find("ImageManager").SendMessage("switchImg", optionCmd, SendMessageOptions.RequireReceiver);
			return tmpLine[0];

		}
		return text;
	}

}
