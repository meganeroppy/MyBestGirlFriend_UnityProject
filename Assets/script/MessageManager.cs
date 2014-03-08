using UnityEngine;
using System.Collections;

public class MessageManager : MonoBehaviour {

	public TextAsset scenario1_proto;
	public TextAsset scenario2_proto;
	public TextAsset end1_proto;
	public TextAsset setup;
	private static string[] textLines;
	private static string curLineMsg;
	//private string curLineMsg;
	private static int curLine;

	//manager
	public GameObject GUITextTest;

	private GameManager gameManager;
	private ImageManager imageManager;
	private GUIManager guiManager;


	void Awake(){
		gameManager = GetComponent<GameManager>();
		imageManager = GetComponent<ImageManager>();
		guiManager = GetComponent<GUIManager>();
	}


	// Use this for initialization
	public void Init () {
		switch(GameManager.cur_scene){
			case GameManager.SCENE.SETUP:
				textLines = setup.text.Split('\n');
				curLine = 0;
				curLineMsg = textLines[curLine];
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
				curLine = 0;
				curLineMsg = textLines[curLine];
				break;
			default:
				break;
		}	//end of switch "SCENE"
	}

	public string AnalyzeLine(){
		curLineMsg = textLines[curLine++];
		if( curLineMsg.Contains("<PLAYER>") ){		//replace playerName

			curLineMsg = curLineMsg.Replace("<PLAYER>", gameManager.GetPlayerName());
		}

		if(curLineMsg.EndsWith("]")){			//facial change
			string[] tmpLine = curLineMsg.Split('[');
			int startPos = 0;
			int endPos = tmpLine[1].IndexOf("]");
			string optionCmd = tmpLine[1].Substring(startPos, endPos - startPos);
			imageManager.switchImg(optionCmd);
			return tmpLine[0];
		}else if(curLineMsg.EndsWith("}")){		//event flag
			int startPos = curLineMsg.IndexOf("{") + 1;
			int endPos = curLineMsg.IndexOf("}");
			curLineMsg = curLineMsg.Substring(startPos, endPos - startPos);
			switch(curLineMsg){
				case "BG":
					imageManager.switchImg("NONE");
					return " ";
				case "CHOICE":
					curLineMsg = textLines[curLine];		//get line containing choices, points, and reactions
					string[] questionArray = curLineMsg.Split(',');
					guiManager.MakeChoices(questionArray);
					curLine++;
					return "CHOICE";
				case "JUNCTION":
					curLineMsg = textLines[curLine];		//get line containing 2 results
					string[] resultArray = curLineMsg.Split(',');
					guiManager.DispResult(resultArray);
					curLine++;
					return " ";
				case "INPUTNAME":
					return "INPUTNAME";
				case "ENDSETUP":
					curLine = 0;
				return "ENDSETUP";
			default:
				break;
			}
		}
		return curLineMsg;
	}

	public string AnalyzeLine(string text){

		if( text.Contains("<PLAYER>") ){		//replace playerName
			
			text = text.Replace("<PLAYER>", gameManager.GetPlayerName());

			//curLineMsg = curLineMsg.Replace("<PLAYER>", gUIManager.GetComponent<GUIManager>().GetText());
		}

		if(text.EndsWith("]")){		//facial change
			string[] tmpLine = text.Split('[');
			int startPos = 0;
			int endPos = tmpLine[1].IndexOf("]");
			string optionCmd = tmpLine[1].Substring(startPos, endPos - startPos);
			imageManager.switchImg(optionCmd);

			return tmpLine[0];

		}
		return text;
	}

}
