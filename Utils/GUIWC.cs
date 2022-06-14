//using System;
//using System.Collections.Generic;
//using Platform;
//using UnityEngine;


//// Token: 0x02000884 RID: 2180
//public class GUIWC : GUIWindow
//{
//	// Token: 0x06005E0E RID: 24078 RVA: 0x00295E20 File Offset: 0x00294020
//	public GUIWC(GameManager _gameManager) : base(GUIWC.ID, new Rect(0f, 100f, (float)Screen.width, (float)(Screen.height / 3)))
//	{
//		//Log.LogCallbacks += this.LogCallback;
//		this.alwaysUsesMouseCursor = true;
//	}

//	// Token: 0x06005E0F RID: 24079 RVA: 0x00295ED5 File Offset: 0x002940D5
//	public void Shutdown()
//	{
//		//Log.LogCallbacks -= this.LogCallback;
//	}

//	// Token: 0x06005E10 RID: 24080 RVA: 0x00295EE8 File Offset: 0x002940E8
//	private void LogCallback(string _msg, string _trace, LogType _type)
//	{
//		switch (_type)
//		{
//			case LogType.Assert:
//				this.openConsole(_msg);
//				break;
//			case LogType.Exception:
//				this.openConsole(_msg);
//				break;
//		}
//		this.internalAddLine(new GUIWC.ConsoleLine(_msg, _trace, _type));
//	}

//	// Token: 0x06005E11 RID: 24081 RVA: 0x00295F24 File Offset: 0x00294124
//	private void openConsole(string _logString)
//	{
//		if (_logString.StartsWith("Can't send RPC"))
//		{
//			return;
//		}
//		if (_logString.StartsWith("You are trying to load data from"))
//		{
//			return;
//		}
//		this.windowManager.OpenIfNotOpen(GUIWC.ID, false, false, true);
//	}

//	// Token: 0x06005E12 RID: 24082 RVA: 0x00295F58 File Offset: 0x00294158
//	public void AddLines(string[] _lines)
//	{
//		for (int i = 0; i < _lines.Length; i++)
//		{
//			this.AddLine(_lines[i]);
//		}
//	}

//	// Token: 0x06005E13 RID: 24083 RVA: 0x00295F7C File Offset: 0x0029417C
//	public void AddLines(List<string> _lines)
//	{
//		for (int i = 0; i < _lines.Count; i++)
//		{
//			this.AddLine(_lines[i]);
//		}
//	}

//	// Token: 0x06005E14 RID: 24084 RVA: 0x00295FA7 File Offset: 0x002941A7
//	public void AddLine(string _line)
//	{
//		this.internalAddLine(new GUIWC.ConsoleLine(_line, string.Empty, LogType.Log));
//	}

//	// Token: 0x06005E15 RID: 24085 RVA: 0x00295FBC File Offset: 0x002941BC
//	private void internalAddLine(GUIWC.ConsoleLine consoleLine)
//	{
//		List<GUIWC.ConsoleLine> obj = this.linesToAdd;
//		lock (obj)
//		{
//			this.linesToAdd.Add(consoleLine);
//		}
//	}

//	// Token: 0x06005E16 RID: 24086 RVA: 0x00296004 File Offset: 0x00294204
//	public override void OnGUI(bool _inputActive)
//	{
//		base.OnGUI(_inputActive);
//		Vector2i vector2i = new Vector2i(Screen.width, Screen.height);
//		if (this.lastResolution != vector2i)
//		{
//			this.lastResolution = vector2i;
//			this.labelStyle = new GUIStyle(GUI.skin.label);
//			this.textfieldStyle = new GUIStyle(GUI.skin.textField);
//			this.buttonStyle = new GUIStyle(GUI.skin.button);
//			if (vector2i.y > 1200)
//			{
//				int num = vector2i.y / 90;
//				this.inputAreaHeight = num + 10;
//				this.labelStyle.fontSize = num;
//				this.textfieldStyle.fontSize = num;
//				this.buttonStyle.fontSize = num;
//			}
//			else
//			{
//				this.inputAreaHeight = 23;
//				this.labelStyle.fontSize = 0;
//				this.textfieldStyle.fontSize = 0;
//				this.buttonStyle.fontSize = 0;
//			}
//		}
//		int num2 = 0;
//		int num3 = 0;
//		int width = Screen.width;
//		int num4 = Screen.height / 3;
//		GUI.Box(new Rect((float)num2, (float)num3, (float)width, (float)num4), "");
//		this.scrollPosition = GUILayout.BeginScrollView(this.scrollPosition, new GUILayoutOption[]
//		{
//			GUILayout.Width((float)width),
//			GUILayout.Height((float)num4)
//		});
//		Rect rect = default(Rect);
//		List<GUIWC.ConsoleLine> sConsoleContent = this.m_sConsoleContent;
//		lock (sConsoleContent)
//		{
//			for (int i = 0; i < this.m_sConsoleContent.Count; i++)
//			{
//				GUIWC.ConsoleLine consoleLine = this.m_sConsoleContent[i];
//				switch (consoleLine.type)
//				{
//					case LogType.Error:
//					case LogType.Assert:
//					case LogType.Exception:
//						GUI.color = Color.red;
//						break;
//					case LogType.Warning:
//						GUI.color = Color.yellow;
//						break;
//					case LogType.Log:
//						GUI.color = Color.white;
//						break;
//				}
//				GUILayout.Label(consoleLine.text, this.labelStyle, Array.Empty<GUILayoutOption>());
//				if (i == this.m_sConsoleContent.Count - 1 && Event.current.type == EventType.Repaint)
//				{
//					rect = GUILayoutUtility.GetLastRect();
//				}
//				GUILayout.Space(-10f);
//			}
//		}
//		GUILayout.Space(10f);
//		GUILayout.EndScrollView();
//		if (Event.current.type == EventType.Repaint)
//		{
//			this.scrolledToBottom = (this.scrollPosition.y > rect.y - (float)num4 + 10f);
//		}
//		GUI.color = Color.white;
//		GUI.SetNextControlName("CommandField");
//		this.curCommand = GUI.TextField(new Rect((float)num2, (float)num4, (float)(width - 50), (float)this.inputAreaHeight), this.curCommand, 300, this.textfieldStyle);
//		if (this.curCommand.Length > 300)
//		{
//			this.curCommand = this.curCommand.Remove(300);
//		}
//		if (this.bFirstTime)
//		{
//			this.bFirstTime = false;
//			GUI.FocusControl("CommandField");
//		}
//		if (this.bUpdateCursor)
//		{
//			this.MoveCursorToEnd();
//			this.bUpdateCursor = false;
//		}
//		if (GUI.Button(new Rect((float)(num2 + width - 50), (float)num4, 50f, (float)this.inputAreaHeight), "Close", this.buttonStyle))
//		{
//			this.CloseConsole();
//			return;
//		}
//		if (Event.current.type == EventType.KeyUp)
//		{
//			if (Event.current.keyCode == KeyCode.Escape || Event.current.keyCode == KeyCode.F1)
//			{
//				this.CloseConsole();
//				return;
//			}
//			if (Event.current.keyCode == KeyCode.Return || Event.current.keyCode == KeyCode.KeypadEnter)
//			{
//				this.EnterCommand();
//				return;
//			}
//			if (Event.current.keyCode == KeyCode.UpArrow)
//			{
//				this.PreviousCommand();
//				return;
//			}
//			if (Event.current.keyCode == KeyCode.DownArrow)
//			{
//				this.NextCommand();
//				return;
//			}
//			if (Event.current.keyCode == KeyCode.PageUp)
//			{
//				this.scrollPosition.y = Math.Max(this.scrollPosition.y - 235f, 0f);
//				return;
//			}
//			if (Event.current.keyCode == KeyCode.PageDown)
//			{
//				this.scrollPosition.y = this.scrollPosition.y + 235f;
//			}
//		}
//	}

//	// Token: 0x06005E17 RID: 24087 RVA: 0x00296448 File Offset: 0x00294648
//	public override void Update()
//	{
//		bool flag = false;
//		List<GUIWC.ConsoleLine> obj = this.linesToAdd;
//		lock (obj)
//		{
//			if (this.linesToAdd.Count > 0)
//			{
//				flag = true;
//				this.m_sConsoleContent.AddRange(this.linesToAdd);
//				this.linesToAdd.Clear();
//			}
//		}
//		if (this.m_sConsoleContent.Count > 300)
//		{
//			this.m_sConsoleContent.RemoveRange(0, this.m_sConsoleContent.Count - 300);
//		}
//		if (flag && this.scrolledToBottom)
//		{
//			this.scrollPosition.y = float.PositiveInfinity;
//		}
//		PlayerActionsLocal playerInput = this.playerUI.playerInput;
//		PlayerActionsGUI playerActionsGUI = (playerInput != null) ? playerInput.GUIActions : null;
//		if (playerActionsGUI == null)
//		{
//			return;
//		}
//		if (this.submitCommand || playerActionsGUI.Submit.WasPressed)
//		{
//			this.submitCommand = false;
//			this.EnterCommand();
//			return;
//		}
//		if (playerActionsGUI.DPad_Up.WasPressed)
//		{
//			this.PreviousCommand();
//			return;
//		}
//		if (playerActionsGUI.DPad_Down.WasPressed)
//		{
//			this.NextCommand();
//			return;
//		}
//		if (!playerActionsGUI.DPad_Left.WasPressed)
//		{
//			if (playerActionsGUI.Cancel.WasPressed || PlayerActionsGlobal.Instance.Console.WasPressed)
//			{
//				this.CloseConsole();
//			}
//			return;
//		}
//		IVirtualKeyboard virtualKeyboard = PlatformManager.NativePlatform.VirtualKeyboard;
//		if (virtualKeyboard == null)
//		{
//			return;
//		}
//		virtualKeyboard.Open("Enter Command", this.curCommand, new Action<bool, string>(this.OnTextReceived), UIInput.InputType.Standard, false);
//	}

//	// Token: 0x06005E18 RID: 24088 RVA: 0x002965C4 File Offset: 0x002947C4
//	private void OnTextReceived(bool _success, string _text)
//	{
//		this.curCommand = _text;
//		if (_success)
//		{
//			this.submitCommand = true;
//		}
//	}

//	// Token: 0x06005E19 RID: 24089 RVA: 0x002965D7 File Offset: 0x002947D7
//	private void CloseConsole()
//	{
//		this.windowManager.Close(this, false);
//		this.curCommand = "";
//	}

//	// Token: 0x06005E1A RID: 24090 RVA: 0x002965F4 File Offset: 0x002947F4
//	private void EnterCommand()
//	{
//		if (this.curCommand.Length > 0)
//		{
//			if (this.curCommand == "clear")
//			{
//				this.Clear();
//			}
//			else
//			{
//				this.scrollPosition.y = float.PositiveInfinity;
//				this.internalAddLine(new GUIWC.ConsoleLine("> " + this.curCommand, string.Empty, LogType.Log));
//				if (!SingletonMonoBehaviour<ConnectionManager>.Instance.IsClient)
//				{
//					this.AddLines(SingletonMonoBehaviour<SdtdConsole>.Instance.ExecuteSync(this.curCommand, null));
//				}
//				else
//				{
//					SingletonMonoBehaviour<ConnectionManager>.Instance.SendToServer(NetPackageManager.GetPackage<NetPackageConsoleCmdServer>().Setup(this.curCommand), false);
//				}
//			}
//			if (this.lastCommands.Count == 0 || !this.lastCommands[this.lastCommands.Count - 1].Equals(this.curCommand))
//			{
//				if (this.lastCommands.Contains(this.curCommand))
//				{
//					this.lastCommands.Remove(this.curCommand);
//				}
//				this.lastCommands.Add(this.curCommand);
//			}
//			this.lastCommandsIdx = this.lastCommands.Count;
//			this.curCommand = "";
//		}
//	}

//	// Token: 0x06005E1B RID: 24091 RVA: 0x00296724 File Offset: 0x00294924
//	private void PreviousCommand()
//	{
//		if (this.lastCommands.Count > 0)
//		{
//			this.lastCommandsIdx = Mathf.Max(0, this.lastCommandsIdx - 1);
//			this.curCommand = this.lastCommands[this.lastCommandsIdx];
//			this.bUpdateCursor = true;
//		}
//	}

//	// Token: 0x06005E1C RID: 24092 RVA: 0x00296774 File Offset: 0x00294974
//	private void NextCommand()
//	{
//		if (this.lastCommands.Count > 0)
//		{
//			this.lastCommandsIdx = Mathf.Min(this.lastCommands.Count, this.lastCommandsIdx + 1);
//			if (this.lastCommandsIdx < this.lastCommands.Count)
//			{
//				this.curCommand = this.lastCommands[this.lastCommandsIdx];
//				this.bUpdateCursor = true;
//				return;
//			}
//			this.curCommand = string.Empty;
//		}
//	}

//	// Token: 0x06005E1D RID: 24093 RVA: 0x002967EC File Offset: 0x002949EC
//	private void MoveCursorToEnd()
//	{
//		TextEditor textEditor = GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl) as TextEditor;
//		if (textEditor != null)
//		{
//			textEditor.selectIndex = this.curCommand.Length + 1;
//			textEditor.cursorIndex = this.curCommand.Length + 1;
//		}
//	}

//	// Token: 0x06005E1E RID: 24094 RVA: 0x0029683C File Offset: 0x00294A3C
//	public void Clear()
//	{
//		this.m_sConsoleContent.Clear();
//	}

//	// Token: 0x06005E1F RID: 24095 RVA: 0x0029684C File Offset: 0x00294A4C
//	public override void OnOpen()
//	{
//		if (GamePrefs.GetBool(EnumGamePrefs.DebugMenuEnabled) && this.windowManager.IsWindowOpen(XUiC_InGameDebugMenu.ID))
//		{
//			this.bShouldReopenGebugMenu = true;
//			this.windowManager.Close(XUiC_InGameDebugMenu.ID);
//		}
//		else
//		{
//			this.bShouldReopenGebugMenu = false;
//		}
//		this.scrollPosition.y = float.PositiveInfinity;
//		this.curCommand = "";
//		this.bFirstTime = true;
//		this.isInputActive = true;
//		if (UIInput.selection != null)
//		{
//			UIInput.selection.isSelected = false;
//		}
//	}

//	// Token: 0x06005E20 RID: 24096 RVA: 0x002968D5 File Offset: 0x00294AD5
//	public override void OnClose()
//	{
//		base.OnClose();
//		if (GamePrefs.GetBool(EnumGamePrefs.DebugMenuEnabled) && this.bShouldReopenGebugMenu)
//		{
//			this.windowManager.Open(XUiC_InGameDebugMenu.ID, false, false, true);
//		}
//		this.bShouldReopenGebugMenu = false;
//		this.isInputActive = false;
//	}

//	// Token: 0x04003F46 RID: 16198
//	public static string ID = typeof(GUIWC).Name;

//	// Token: 0x04003F47 RID: 16199
//	private Vector2 scrollPosition = new Vector2(0f, float.MaxValue);

//	// Token: 0x04003F48 RID: 16200
//	private bool scrolledToBottom = true;

//	// Token: 0x04003F49 RID: 16201
//	private List<GUIWC.ConsoleLine> linesToAdd = new List<GUIWC.ConsoleLine>();

//	// Token: 0x04003F4A RID: 16202
//	private List<GUIWC.ConsoleLine> m_sConsoleContent = new List<GUIWC.ConsoleLine>();

//	// Token: 0x04003F4B RID: 16203
//	private Vector2 helpLabelSize = new Vector2(-1f, 0f);

//	// Token: 0x04003F4C RID: 16204
//	private readonly string helpLabelText = "Use PAGE buttons to scroll";

//	// Token: 0x04003F4D RID: 16205
//	private List<string> lastCommands = new List<string>();

//	// Token: 0x04003F4E RID: 16206
//	private int lastCommandsIdx;

//	// Token: 0x04003F4F RID: 16207
//	public string curCommand = "";

//	// Token: 0x04003F50 RID: 16208
//	private bool bFirstTime;

//	// Token: 0x04003F51 RID: 16209
//	private bool bUpdateCursor;

//	// Token: 0x04003F52 RID: 16210
//	private bool bShouldReopenGebugMenu;

//	// Token: 0x04003F53 RID: 16211
//	private Vector2i lastResolution;

//	// Token: 0x04003F54 RID: 16212
//	private GUIStyle labelStyle;

//	// Token: 0x04003F55 RID: 16213
//	private GUIStyle textfieldStyle;

//	// Token: 0x04003F56 RID: 16214
//	private GUIStyle buttonStyle;

//	// Token: 0x04003F57 RID: 16215
//	private int inputAreaHeight;

//	// Token: 0x04003F58 RID: 16216
//	private bool submitCommand;

//	// Token: 0x020010B9 RID: 4281
//	public struct ConsoleLine
//	{
//		// Token: 0x06008F48 RID: 36680 RVA: 0x003A9057 File Offset: 0x003A7257
//		public ConsoleLine(string _text, string _stackTrace, LogType _type)
//		{
//			this.text = _text;
//			this.stackTrace = _stackTrace;
//			this.type = _type;
//		}

//		// Token: 0x0400713A RID: 28986
//		public string text;

//		// Token: 0x0400713B RID: 28987
//		public LogType type;

//		// Token: 0x0400713C RID: 28988
//		public string stackTrace;
//	}
//}
