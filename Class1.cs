//using System;
//using System.Runtime.CompilerServices;
//using System.Runtime.InteropServices;
//using UnityEngine.Bindings;
//using UnityEngine.Scripting;

//namespace UnityEngine
//{
//	// Token: 0x0200002B RID: 43
//	[RequiredByNativeCode]
//	[NativeHeader("Modules/IMGUI/GUIStyle.bindings.h")]
//	[NativeHeader("IMGUIScriptingClasses.h")]
//	[Serializable]
//	[StructLayout(LayoutKind.Sequential)]
//	public sealed class GUIStyle
//	{
//		// Token: 0x17000062 RID: 98
//		// (get) Token: 0x060002D3 RID: 723
//		// (set) Token: 0x060002D4 RID: 724
//		[NativeProperty("Name", false, TargetType.Function)]
//		internal extern string rawName { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

//		// Token: 0x17000063 RID: 99
//		// (get) Token: 0x060002D5 RID: 725
//		// (set) Token: 0x060002D6 RID: 726
//		[NativeProperty("Font", false, TargetType.Function)]
//		public extern Font font { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

//		// Token: 0x17000064 RID: 100
//		// (get) Token: 0x060002D7 RID: 727
//		// (set) Token: 0x060002D8 RID: 728
//		[NativeProperty("m_ImagePosition", false, TargetType.Field)]
//		public extern ImagePosition imagePosition { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

//		// Token: 0x17000065 RID: 101
//		// (get) Token: 0x060002D9 RID: 729
//		// (set) Token: 0x060002DA RID: 730
//		[NativeProperty("m_Alignment", false, TargetType.Field)]
//		public extern TextAnchor alignment { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

//		// Token: 0x17000066 RID: 102
//		// (get) Token: 0x060002DB RID: 731
//		// (set) Token: 0x060002DC RID: 732
//		[NativeProperty("m_WordWrap", false, TargetType.Field)]
//		public extern bool wordWrap { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

//		// Token: 0x17000067 RID: 103
//		// (get) Token: 0x060002DD RID: 733
//		// (set) Token: 0x060002DE RID: 734
//		[NativeProperty("m_Clipping", false, TargetType.Field)]
//		public extern TextClipping clipping { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

//		// Token: 0x17000068 RID: 104
//		// (get) Token: 0x060002DF RID: 735 RVA: 0x0000B128 File Offset: 0x00009328
//		// (set) Token: 0x060002E0 RID: 736 RVA: 0x0000B13E File Offset: 0x0000933E
//		[NativeProperty("m_ContentOffset", false, TargetType.Field)]
//		public Vector2 contentOffset
//		{
//			get
//			{
//				Vector2 result;
//				this.get_contentOffset_Injected(out result);
//				return result;
//			}
//			set
//			{
//				this.set_contentOffset_Injected(ref value);
//			}
//		}

//		// Token: 0x17000069 RID: 105
//		// (get) Token: 0x060002E1 RID: 737
//		// (set) Token: 0x060002E2 RID: 738
//		[NativeProperty("m_FixedWidth", false, TargetType.Field)]
//		public extern float fixedWidth { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

//		// Token: 0x1700006A RID: 106
//		// (get) Token: 0x060002E3 RID: 739
//		// (set) Token: 0x060002E4 RID: 740
//		[NativeProperty("m_FixedHeight", false, TargetType.Field)]
//		public extern float fixedHeight { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

//		// Token: 0x1700006B RID: 107
//		// (get) Token: 0x060002E5 RID: 741
//		// (set) Token: 0x060002E6 RID: 742
//		[NativeProperty("m_StretchWidth", false, TargetType.Field)]
//		public extern bool stretchWidth { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

//		// Token: 0x1700006C RID: 108
//		// (get) Token: 0x060002E7 RID: 743
//		// (set) Token: 0x060002E8 RID: 744
//		[NativeProperty("m_StretchHeight", false, TargetType.Field)]
//		public extern bool stretchHeight { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

//		// Token: 0x1700006D RID: 109
//		// (get) Token: 0x060002E9 RID: 745
//		// (set) Token: 0x060002EA RID: 746
//		[NativeProperty("m_FontSize", false, TargetType.Field)]
//		public extern int fontSize { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

//		// Token: 0x1700006E RID: 110
//		// (get) Token: 0x060002EB RID: 747
//		// (set) Token: 0x060002EC RID: 748
//		[NativeProperty("m_FontStyle", false, TargetType.Field)]
//		public extern FontStyle fontStyle { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

//		// Token: 0x1700006F RID: 111
//		// (get) Token: 0x060002ED RID: 749
//		// (set) Token: 0x060002EE RID: 750
//		[NativeProperty("m_RichText", false, TargetType.Field)]
//		public extern bool richText { [MethodImpl(MethodImplOptions.InternalCall)] get; [MethodImpl(MethodImplOptions.InternalCall)] set; }

//		// Token: 0x17000070 RID: 112
//		// (get) Token: 0x060002EF RID: 751 RVA: 0x0000B148 File Offset: 0x00009348
//		// (set) Token: 0x060002F0 RID: 752 RVA: 0x0000B15E File Offset: 0x0000935E
//		[NativeProperty("m_ClipOffset", false, TargetType.Field)]
//		[Obsolete("Don't use clipOffset - put things inside BeginGroup instead. This functionality will be removed in a later version.", false)]
//		public Vector2 clipOffset
//		{
//			get
//			{
//				Vector2 result;
//				this.get_clipOffset_Injected(out result);
//				return result;
//			}
//			set
//			{
//				this.set_clipOffset_Injected(ref value);
//			}
//		}

//		// Token: 0x17000071 RID: 113
//		// (get) Token: 0x060002F1 RID: 753 RVA: 0x0000B168 File Offset: 0x00009368
//		// (set) Token: 0x060002F2 RID: 754 RVA: 0x0000B17E File Offset: 0x0000937E
//		[NativeProperty("m_ClipOffset", false, TargetType.Field)]
//		internal Vector2 Internal_clipOffset
//		{
//			get
//			{
//				Vector2 result;
//				this.get_Internal_clipOffset_Injected(out result);
//				return result;
//			}
//			set
//			{
//				this.set_Internal_clipOffset_Injected(ref value);
//			}
//		}

//		// Token: 0x060002F3 RID: 755
//		[FreeFunction(Name = "GUIStyle_Bindings::Internal_Create", IsThreadSafe = true)]
//		[MethodImpl(MethodImplOptions.InternalCall)]
//		private static extern IntPtr Internal_Create(GUIStyle self);

//		// Token: 0x060002F4 RID: 756
//		[FreeFunction(Name = "GUIStyle_Bindings::Internal_Copy", IsThreadSafe = true)]
//		[MethodImpl(MethodImplOptions.InternalCall)]
//		private static extern IntPtr Internal_Copy(GUIStyle self, GUIStyle other);

//		// Token: 0x060002F5 RID: 757
//		[FreeFunction(Name = "GUIStyle_Bindings::Internal_Destroy", IsThreadSafe = true)]
//		[MethodImpl(MethodImplOptions.InternalCall)]
//		private static extern void Internal_Destroy(IntPtr self);

//		// Token: 0x060002F6 RID: 758
//		[FreeFunction(Name = "GUIStyle_Bindings::GetStyleStatePtr", IsThreadSafe = true, HasExplicitThis = true)]
//		[MethodImpl(MethodImplOptions.InternalCall)]
//		private extern IntPtr GetStyleStatePtr(int idx);

//		// Token: 0x060002F7 RID: 759
//		[FreeFunction(Name = "GUIStyle_Bindings::AssignStyleState", HasExplicitThis = true)]
//		[MethodImpl(MethodImplOptions.InternalCall)]
//		private extern void AssignStyleState(int idx, IntPtr srcStyleState);

//		// Token: 0x060002F8 RID: 760
//		[FreeFunction(Name = "GUIStyle_Bindings::GetRectOffsetPtr", HasExplicitThis = true)]
//		[MethodImpl(MethodImplOptions.InternalCall)]
//		private extern IntPtr GetRectOffsetPtr(int idx);

//		// Token: 0x060002F9 RID: 761
//		[FreeFunction(Name = "GUIStyle_Bindings::AssignRectOffset", HasExplicitThis = true)]
//		[MethodImpl(MethodImplOptions.InternalCall)]
//		private extern void AssignRectOffset(int idx, IntPtr srcRectOffset);

//		// Token: 0x060002FA RID: 762
//		[FreeFunction(Name = "GUIStyle_Bindings::Internal_GetLineHeight")]
//		[MethodImpl(MethodImplOptions.InternalCall)]
//		private static extern float Internal_GetLineHeight(IntPtr target);

//		// Token: 0x060002FB RID: 763 RVA: 0x0000B188 File Offset: 0x00009388
//		[FreeFunction(Name = "GUIStyle_Bindings::Internal_Draw", HasExplicitThis = true)]
//		private void Internal_Draw(Rect screenRect, GUIContent content, bool isHover, bool isActive, bool on, bool hasKeyboardFocus)
//		{
//			this.Internal_Draw_Injected(ref screenRect, content, isHover, isActive, on, hasKeyboardFocus);
//		}

//		// Token: 0x060002FC RID: 764 RVA: 0x0000B19A File Offset: 0x0000939A
//		[FreeFunction(Name = "GUIStyle_Bindings::Internal_Draw2", HasExplicitThis = true)]
//		private void Internal_Draw2(Rect position, GUIContent content, int controlID, bool on)
//		{
//			this.Internal_Draw2_Injected(ref position, content, controlID, on);
//		}

//		// Token: 0x060002FD RID: 765 RVA: 0x0000B1A8 File Offset: 0x000093A8
//		[FreeFunction(Name = "GUIStyle_Bindings::Internal_DrawCursor", HasExplicitThis = true)]
//		private void Internal_DrawCursor(Rect position, GUIContent content, int pos, Color cursorColor)
//		{
//			this.Internal_DrawCursor_Injected(ref position, content, pos, ref cursorColor);
//		}

//		// Token: 0x060002FE RID: 766 RVA: 0x0000B1B8 File Offset: 0x000093B8
//		[FreeFunction(Name = "GUIStyle_Bindings::Internal_DrawWithTextSelection", HasExplicitThis = true)]
//		private void Internal_DrawWithTextSelection(Rect screenRect, GUIContent content, bool isHover, bool isActive, bool on, bool hasKeyboardFocus, bool drawSelectionAsComposition, int cursorFirst, int cursorLast, Color cursorColor, Color selectionColor)
//		{
//			this.Internal_DrawWithTextSelection_Injected(ref screenRect, content, isHover, isActive, on, hasKeyboardFocus, drawSelectionAsComposition, cursorFirst, cursorLast, ref cursorColor, ref selectionColor);
//		}

//		// Token: 0x060002FF RID: 767 RVA: 0x0000B1E0 File Offset: 0x000093E0
//		[FreeFunction(Name = "GUIStyle_Bindings::Internal_GetCursorPixelPosition", HasExplicitThis = true)]
//		internal Vector2 Internal_GetCursorPixelPosition(Rect position, GUIContent content, int cursorStringIndex)
//		{
//			Vector2 result;
//			this.Internal_GetCursorPixelPosition_Injected(ref position, content, cursorStringIndex, out result);
//			return result;
//		}

//		// Token: 0x06000300 RID: 768 RVA: 0x0000B1FA File Offset: 0x000093FA
//		[FreeFunction(Name = "GUIStyle_Bindings::Internal_GetCursorStringIndex", HasExplicitThis = true)]
//		internal int Internal_GetCursorStringIndex(Rect position, GUIContent content, Vector2 cursorPixelPosition)
//		{
//			return this.Internal_GetCursorStringIndex_Injected(ref position, content, ref cursorPixelPosition);
//		}

//		// Token: 0x06000301 RID: 769 RVA: 0x0000B207 File Offset: 0x00009407
//		[FreeFunction(Name = "GUIStyle_Bindings::Internal_GetSelectedRenderedText", HasExplicitThis = true)]
//		internal string Internal_GetSelectedRenderedText(Rect localPosition, GUIContent mContent, int selectIndex, int cursorIndex)
//		{
//			return this.Internal_GetSelectedRenderedText_Injected(ref localPosition, mContent, selectIndex, cursorIndex);
//		}

//		// Token: 0x06000302 RID: 770 RVA: 0x0000B215 File Offset: 0x00009415
//		[FreeFunction(Name = "GUIStyle_Bindings::Internal_GetHyperlinksRect", HasExplicitThis = true)]
//		internal Rect[] Internal_GetHyperlinksRect(Rect localPosition, GUIContent mContent)
//		{
//			return this.Internal_GetHyperlinksRect_Injected(ref localPosition, mContent);
//		}

//		// Token: 0x06000303 RID: 771
//		[FreeFunction(Name = "GUIStyle_Bindings::Internal_GetNumCharactersThatFitWithinWidth", HasExplicitThis = true)]
//		[MethodImpl(MethodImplOptions.InternalCall)]
//		internal extern int Internal_GetNumCharactersThatFitWithinWidth(string text, float width);

//		// Token: 0x06000304 RID: 772 RVA: 0x0000B220 File Offset: 0x00009420
//		[FreeFunction(Name = "GUIStyle_Bindings::Internal_CalcSize", HasExplicitThis = true)]
//		internal Vector2 Internal_CalcSize(GUIContent content)
//		{
//			Vector2 result;
//			this.Internal_CalcSize_Injected(content, out result);
//			return result;
//		}

//		// Token: 0x06000305 RID: 773 RVA: 0x0000B238 File Offset: 0x00009438
//		[FreeFunction(Name = "GUIStyle_Bindings::Internal_CalcSizeWithConstraints", HasExplicitThis = true)]
//		internal Vector2 Internal_CalcSizeWithConstraints(GUIContent content, Vector2 maxSize)
//		{
//			Vector2 result;
//			this.Internal_CalcSizeWithConstraints_Injected(content, ref maxSize, out result);
//			return result;
//		}

//		// Token: 0x06000306 RID: 774
//		[FreeFunction(Name = "GUIStyle_Bindings::Internal_CalcHeight", HasExplicitThis = true)]
//		[MethodImpl(MethodImplOptions.InternalCall)]
//		private extern float Internal_CalcHeight(GUIContent content, float width);

//		// Token: 0x06000307 RID: 775 RVA: 0x0000B254 File Offset: 0x00009454
//		[FreeFunction(Name = "GUIStyle_Bindings::Internal_CalcMinMaxWidth", HasExplicitThis = true)]
//		private Vector2 Internal_CalcMinMaxWidth(GUIContent content)
//		{
//			Vector2 result;
//			this.Internal_CalcMinMaxWidth_Injected(content, out result);
//			return result;
//		}

//		// Token: 0x06000308 RID: 776 RVA: 0x0000B26B File Offset: 0x0000946B
//		[FreeFunction(Name = "GUIStyle_Bindings::SetMouseTooltip")]
//		internal static void SetMouseTooltip(string tooltip, Rect screenRect)
//		{
//			GUIStyle.SetMouseTooltip_Injected(tooltip, ref screenRect);
//		}

//		// Token: 0x06000309 RID: 777
//		[FreeFunction(Name = "GUIStyle_Bindings::Internal_GetCursorFlashOffset")]
//		[MethodImpl(MethodImplOptions.InternalCall)]
//		private static extern float Internal_GetCursorFlashOffset();

//		// Token: 0x0600030A RID: 778
//		[FreeFunction(Name = "GUIStyle::SetDefaultFont")]
//		[MethodImpl(MethodImplOptions.InternalCall)]
//		internal static extern void SetDefaultFont(Font font);

//		// Token: 0x0600030B RID: 779 RVA: 0x0000B275 File Offset: 0x00009475
//		public GUIStyle()
//		{
//			this.m_Ptr = GUIStyle.Internal_Create(this);
//		}

//		// Token: 0x0600030C RID: 780 RVA: 0x0000B28C File Offset: 0x0000948C
//		public GUIStyle(GUIStyle other)
//		{
//			bool flag = other == null;
//			if (flag)
//			{
//				Debug.LogError("Copied style is null. Using StyleNotFound instead.");
//				other = GUISkin.error;
//			}
//			this.m_Ptr = GUIStyle.Internal_Copy(this, other);
//		}

//		// Token: 0x0600030D RID: 781 RVA: 0x0000B2CC File Offset: 0x000094CC
//		protected override void Finalize()
//		{
//			try
//			{
//				bool flag = this.m_Ptr != IntPtr.Zero;
//				if (flag)
//				{
//					GUIStyle.Internal_Destroy(this.m_Ptr);
//					this.m_Ptr = IntPtr.Zero;
//				}
//			}
//			finally
//			{
//				base.Finalize();
//			}
//		}

//		// Token: 0x0600030E RID: 782 RVA: 0x0000B324 File Offset: 0x00009524
//		internal static void CleanupRoots()
//		{
//			GUIStyle.s_None = null;
//		}

//		// Token: 0x0600030F RID: 783 RVA: 0x0000B330 File Offset: 0x00009530
//		internal void InternalOnAfterDeserialize()
//		{
//			this.m_Normal = GUIStyleState.ProduceGUIStyleStateFromDeserialization(this, this.GetStyleStatePtr(0));
//			this.m_Hover = GUIStyleState.ProduceGUIStyleStateFromDeserialization(this, this.GetStyleStatePtr(1));
//			this.m_Active = GUIStyleState.ProduceGUIStyleStateFromDeserialization(this, this.GetStyleStatePtr(2));
//			this.m_Focused = GUIStyleState.ProduceGUIStyleStateFromDeserialization(this, this.GetStyleStatePtr(3));
//			this.m_OnNormal = GUIStyleState.ProduceGUIStyleStateFromDeserialization(this, this.GetStyleStatePtr(4));
//			this.m_OnHover = GUIStyleState.ProduceGUIStyleStateFromDeserialization(this, this.GetStyleStatePtr(5));
//			this.m_OnActive = GUIStyleState.ProduceGUIStyleStateFromDeserialization(this, this.GetStyleStatePtr(6));
//			this.m_OnFocused = GUIStyleState.ProduceGUIStyleStateFromDeserialization(this, this.GetStyleStatePtr(7));
//		}

//		// Token: 0x17000072 RID: 114
//		// (get) Token: 0x06000310 RID: 784 RVA: 0x0000B3D8 File Offset: 0x000095D8
//		// (set) Token: 0x06000311 RID: 785 RVA: 0x0000B403 File Offset: 0x00009603
//		public string name
//		{
//			get
//			{
//				string result;
//				if ((result = this.m_Name) == null)
//				{
//					result = (this.m_Name = this.rawName);
//				}
//				return result;
//			}
//			set
//			{
//				this.m_Name = value;
//				this.rawName = value;
//			}
//		}

//		// Token: 0x17000073 RID: 115
//		// (get) Token: 0x06000312 RID: 786 RVA: 0x0000B418 File Offset: 0x00009618
//		// (set) Token: 0x06000313 RID: 787 RVA: 0x0000B44A File Offset: 0x0000964A
//		public GUIStyleState normal
//		{
//			get
//			{
//				GUIStyleState result;
//				if ((result = this.m_Normal) == null)
//				{
//					result = (this.m_Normal = GUIStyleState.GetGUIStyleState(this, this.GetStyleStatePtr(0)));
//				}
//				return result;
//			}
//			set
//			{
//				this.AssignStyleState(0, value.m_Ptr);
//			}
//		}

//		// Token: 0x17000074 RID: 116
//		// (get) Token: 0x06000314 RID: 788 RVA: 0x0000B45C File Offset: 0x0000965C
//		// (set) Token: 0x06000315 RID: 789 RVA: 0x0000B48E File Offset: 0x0000968E
//		public GUIStyleState hover
//		{
//			get
//			{
//				GUIStyleState result;
//				if ((result = this.m_Hover) == null)
//				{
//					result = (this.m_Hover = GUIStyleState.GetGUIStyleState(this, this.GetStyleStatePtr(1)));
//				}
//				return result;
//			}
//			set
//			{
//				this.AssignStyleState(1, value.m_Ptr);
//			}
//		}

//		// Token: 0x17000075 RID: 117
//		// (get) Token: 0x06000316 RID: 790 RVA: 0x0000B4A0 File Offset: 0x000096A0
//		// (set) Token: 0x06000317 RID: 791 RVA: 0x0000B4D2 File Offset: 0x000096D2
//		public GUIStyleState active
//		{
//			get
//			{
//				GUIStyleState result;
//				if ((result = this.m_Active) == null)
//				{
//					result = (this.m_Active = GUIStyleState.GetGUIStyleState(this, this.GetStyleStatePtr(2)));
//				}
//				return result;
//			}
//			set
//			{
//				this.AssignStyleState(2, value.m_Ptr);
//			}
//		}

//		// Token: 0x17000076 RID: 118
//		// (get) Token: 0x06000318 RID: 792 RVA: 0x0000B4E4 File Offset: 0x000096E4
//		// (set) Token: 0x06000319 RID: 793 RVA: 0x0000B516 File Offset: 0x00009716
//		public GUIStyleState onNormal
//		{
//			get
//			{
//				GUIStyleState result;
//				if ((result = this.m_OnNormal) == null)
//				{
//					result = (this.m_OnNormal = GUIStyleState.GetGUIStyleState(this, this.GetStyleStatePtr(4)));
//				}
//				return result;
//			}
//			set
//			{
//				this.AssignStyleState(4, value.m_Ptr);
//			}
//		}

//		// Token: 0x17000077 RID: 119
//		// (get) Token: 0x0600031A RID: 794 RVA: 0x0000B528 File Offset: 0x00009728
//		// (set) Token: 0x0600031B RID: 795 RVA: 0x0000B55A File Offset: 0x0000975A
//		public GUIStyleState onHover
//		{
//			get
//			{
//				GUIStyleState result;
//				if ((result = this.m_OnHover) == null)
//				{
//					result = (this.m_OnHover = GUIStyleState.GetGUIStyleState(this, this.GetStyleStatePtr(5)));
//				}
//				return result;
//			}
//			set
//			{
//				this.AssignStyleState(5, value.m_Ptr);
//			}
//		}

//		// Token: 0x17000078 RID: 120
//		// (get) Token: 0x0600031C RID: 796 RVA: 0x0000B56C File Offset: 0x0000976C
//		// (set) Token: 0x0600031D RID: 797 RVA: 0x0000B59E File Offset: 0x0000979E
//		public GUIStyleState onActive
//		{
//			get
//			{
//				GUIStyleState result;
//				if ((result = this.m_OnActive) == null)
//				{
//					result = (this.m_OnActive = GUIStyleState.GetGUIStyleState(this, this.GetStyleStatePtr(6)));
//				}
//				return result;
//			}
//			set
//			{
//				this.AssignStyleState(6, value.m_Ptr);
//			}
//		}

//		// Token: 0x17000079 RID: 121
//		// (get) Token: 0x0600031E RID: 798 RVA: 0x0000B5B0 File Offset: 0x000097B0
//		// (set) Token: 0x0600031F RID: 799 RVA: 0x0000B5E2 File Offset: 0x000097E2
//		public GUIStyleState focused
//		{
//			get
//			{
//				GUIStyleState result;
//				if ((result = this.m_Focused) == null)
//				{
//					result = (this.m_Focused = GUIStyleState.GetGUIStyleState(this, this.GetStyleStatePtr(3)));
//				}
//				return result;
//			}
//			set
//			{
//				this.AssignStyleState(3, value.m_Ptr);
//			}
//		}

//		// Token: 0x1700007A RID: 122
//		// (get) Token: 0x06000320 RID: 800 RVA: 0x0000B5F4 File Offset: 0x000097F4
//		// (set) Token: 0x06000321 RID: 801 RVA: 0x0000B626 File Offset: 0x00009826
//		public GUIStyleState onFocused
//		{
//			get
//			{
//				GUIStyleState result;
//				if ((result = this.m_OnFocused) == null)
//				{
//					result = (this.m_OnFocused = GUIStyleState.GetGUIStyleState(this, this.GetStyleStatePtr(7)));
//				}
//				return result;
//			}
//			set
//			{
//				this.AssignStyleState(7, value.m_Ptr);
//			}
//		}

//		// Token: 0x1700007B RID: 123
//		// (get) Token: 0x06000322 RID: 802 RVA: 0x0000B638 File Offset: 0x00009838
//		// (set) Token: 0x06000323 RID: 803 RVA: 0x0000B66A File Offset: 0x0000986A
//		public RectOffset border
//		{
//			get
//			{
//				RectOffset result;
//				if ((result = this.m_Border) == null)
//				{
//					result = (this.m_Border = new RectOffset(this, this.GetRectOffsetPtr(0)));
//				}
//				return result;
//			}
//			set
//			{
//				this.AssignRectOffset(0, value.m_Ptr);
//			}
//		}

//		// Token: 0x1700007C RID: 124
//		// (get) Token: 0x06000324 RID: 804 RVA: 0x0000B67C File Offset: 0x0000987C
//		// (set) Token: 0x06000325 RID: 805 RVA: 0x0000B6AE File Offset: 0x000098AE
//		public RectOffset margin
//		{
//			get
//			{
//				RectOffset result;
//				if ((result = this.m_Margin) == null)
//				{
//					result = (this.m_Margin = new RectOffset(this, this.GetRectOffsetPtr(1)));
//				}
//				return result;
//			}
//			set
//			{
//				this.AssignRectOffset(1, value.m_Ptr);
//			}
//		}

//		// Token: 0x1700007D RID: 125
//		// (get) Token: 0x06000326 RID: 806 RVA: 0x0000B6C0 File Offset: 0x000098C0
//		// (set) Token: 0x06000327 RID: 807 RVA: 0x0000B6F2 File Offset: 0x000098F2
//		public RectOffset padding
//		{
//			get
//			{
//				RectOffset result;
//				if ((result = this.m_Padding) == null)
//				{
//					result = (this.m_Padding = new RectOffset(this, this.GetRectOffsetPtr(2)));
//				}
//				return result;
//			}
//			set
//			{
//				this.AssignRectOffset(2, value.m_Ptr);
//			}
//		}

//		// Token: 0x1700007E RID: 126
//		// (get) Token: 0x06000328 RID: 808 RVA: 0x0000B704 File Offset: 0x00009904
//		// (set) Token: 0x06000329 RID: 809 RVA: 0x0000B736 File Offset: 0x00009936
//		public RectOffset overflow
//		{
//			get
//			{
//				RectOffset result;
//				if ((result = this.m_Overflow) == null)
//				{
//					result = (this.m_Overflow = new RectOffset(this, this.GetRectOffsetPtr(3)));
//				}
//				return result;
//			}
//			set
//			{
//				this.AssignRectOffset(3, value.m_Ptr);
//			}
//		}

//		// Token: 0x1700007F RID: 127
//		// (get) Token: 0x0600032A RID: 810 RVA: 0x0000B747 File Offset: 0x00009947
//		public float lineHeight
//		{
//			get
//			{
//				return Mathf.Round(GUIStyle.Internal_GetLineHeight(this.m_Ptr));
//			}
//		}

//		// Token: 0x0600032B RID: 811 RVA: 0x0000B759 File Offset: 0x00009959
//		public void Draw(Rect position, bool isHover, bool isActive, bool on, bool hasKeyboardFocus)
//		{
//			this.Draw(position, GUIContent.none, -1, isHover, isActive, on, hasKeyboardFocus);
//		}

//		// Token: 0x0600032C RID: 812 RVA: 0x0000B770 File Offset: 0x00009970
//		public void Draw(Rect position, string text, bool isHover, bool isActive, bool on, bool hasKeyboardFocus)
//		{
//			this.Draw(position, GUIContent.Temp(text), -1, isHover, isActive, on, hasKeyboardFocus);
//		}

//		// Token: 0x0600032D RID: 813 RVA: 0x0000B789 File Offset: 0x00009989
//		public void Draw(Rect position, Texture image, bool isHover, bool isActive, bool on, bool hasKeyboardFocus)
//		{
//			this.Draw(position, GUIContent.Temp(image), -1, isHover, isActive, on, hasKeyboardFocus);
//		}

//		// Token: 0x0600032E RID: 814 RVA: 0x0000B7A2 File Offset: 0x000099A2
//		public void Draw(Rect position, GUIContent content, bool isHover, bool isActive, bool on, bool hasKeyboardFocus)
//		{
//			this.Draw(position, content, -1, isHover, isActive, on, hasKeyboardFocus);
//		}

//		// Token: 0x0600032F RID: 815 RVA: 0x0000B7B6 File Offset: 0x000099B6
//		public void Draw(Rect position, GUIContent content, int controlID)
//		{
//			this.Draw(position, content, controlID, false, false, false, false);
//		}

//		// Token: 0x06000330 RID: 816 RVA: 0x0000B7C7 File Offset: 0x000099C7
//		public void Draw(Rect position, GUIContent content, int controlID, bool on)
//		{
//			this.Draw(position, content, controlID, false, false, on, false);
//		}

//		// Token: 0x06000331 RID: 817 RVA: 0x0000B7D9 File Offset: 0x000099D9
//		public void Draw(Rect position, GUIContent content, int controlID, bool on, bool hover)
//		{
//			this.Draw(position, content, controlID, hover, GUIUtility.hotControl == controlID, on, GUIUtility.HasKeyFocus(controlID));
//		}

//		// Token: 0x06000332 RID: 818 RVA: 0x0000B7F8 File Offset: 0x000099F8
//		private void Draw(Rect position, GUIContent content, int controlId, bool isHover, bool isActive, bool on, bool hasKeyboardFocus)
//		{
//			bool flag = controlId == -1;
//			if (flag)
//			{
//				this.Internal_Draw(position, content, isHover, isActive, on, hasKeyboardFocus);
//			}
//			else
//			{
//				this.Internal_Draw2(position, content, controlId, on);
//			}
//		}

//		// Token: 0x06000333 RID: 819 RVA: 0x0000B830 File Offset: 0x00009A30
//		public void DrawCursor(Rect position, GUIContent content, int controlID, int character)
//		{
//			Event current = Event.current;
//			bool flag = current.type == EventType.Repaint;
//			if (flag)
//			{
//				Color cursorColor = new Color(0f, 0f, 0f, 0f);
//				float cursorFlashSpeed = GUI.skin.settings.cursorFlashSpeed;
//				float num = (Time.realtimeSinceStartup - GUIStyle.Internal_GetCursorFlashOffset()) % cursorFlashSpeed / cursorFlashSpeed;
//				bool flag2 = cursorFlashSpeed == 0f || num < 0.5f;
//				if (flag2)
//				{
//					cursorColor = GUI.skin.settings.cursorColor;
//				}
//				this.Internal_DrawCursor(position, content, character, cursorColor);
//			}
//		}

//		// Token: 0x06000334 RID: 820 RVA: 0x0000B8C8 File Offset: 0x00009AC8
//		internal void DrawWithTextSelection(Rect position, GUIContent content, bool isActive, bool hasKeyboardFocus, int firstSelectedCharacter, int lastSelectedCharacter, bool drawSelectionAsComposition, Color selectionColor)
//		{
//			Color cursorColor = new Color(0f, 0f, 0f, 0f);
//			float cursorFlashSpeed = GUI.skin.settings.cursorFlashSpeed;
//			float num = (Time.realtimeSinceStartup - GUIStyle.Internal_GetCursorFlashOffset()) % cursorFlashSpeed / cursorFlashSpeed;
//			bool flag = cursorFlashSpeed == 0f || num < 0.5f;
//			if (flag)
//			{
//				cursorColor = GUI.skin.settings.cursorColor;
//			}
//			bool isHover = position.Contains(Event.current.mousePosition);
//			this.Internal_DrawWithTextSelection(position, content, isHover, isActive, false, hasKeyboardFocus, drawSelectionAsComposition, firstSelectedCharacter, lastSelectedCharacter, cursorColor, selectionColor);
//		}

//		// Token: 0x06000335 RID: 821 RVA: 0x0000B968 File Offset: 0x00009B68
//		internal void DrawWithTextSelection(Rect position, GUIContent content, int controlID, int firstSelectedCharacter, int lastSelectedCharacter, bool drawSelectionAsComposition)
//		{
//			this.DrawWithTextSelection(position, content, controlID == GUIUtility.hotControl, controlID == GUIUtility.keyboardControl && GUIStyle.showKeyboardFocus, firstSelectedCharacter, lastSelectedCharacter, drawSelectionAsComposition, GUI.skin.settings.selectionColor);
//		}

//		// Token: 0x06000336 RID: 822 RVA: 0x0000B9AC File Offset: 0x00009BAC
//		public void DrawWithTextSelection(Rect position, GUIContent content, int controlID, int firstSelectedCharacter, int lastSelectedCharacter)
//		{
//			this.DrawWithTextSelection(position, content, controlID, firstSelectedCharacter, lastSelectedCharacter, false);
//		}

//		// Token: 0x06000337 RID: 823 RVA: 0x0000B9C0 File Offset: 0x00009BC0
//		public static implicit operator GUIStyle(string str)
//		{
//			bool flag = GUISkin.current == null;
//			GUIStyle result;
//			if (flag)
//			{
//				Debug.LogError("Unable to use a named GUIStyle without a current skin. Most likely you need to move your GUIStyle initialization code to OnGUI");
//				result = GUISkin.error;
//			}
//			else
//			{
//				result = GUISkin.current.GetStyle(str);
//			}
//			return result;
//		}

//		// Token: 0x17000080 RID: 128
//		// (get) Token: 0x06000338 RID: 824 RVA: 0x0000BA00 File Offset: 0x00009C00
//		public static GUIStyle none
//		{
//			get
//			{
//				GUIStyle result;
//				if ((result = GUIStyle.s_None) == null)
//				{
//					result = (GUIStyle.s_None = new GUIStyle());
//				}
//				return result;
//			}
//		}

//		// Token: 0x06000339 RID: 825 RVA: 0x0000BA18 File Offset: 0x00009C18
//		public Vector2 GetCursorPixelPosition(Rect position, GUIContent content, int cursorStringIndex)
//		{
//			return this.Internal_GetCursorPixelPosition(position, content, cursorStringIndex);
//		}

//		// Token: 0x0600033A RID: 826 RVA: 0x0000BA34 File Offset: 0x00009C34
//		public int GetCursorStringIndex(Rect position, GUIContent content, Vector2 cursorPixelPosition)
//		{
//			return this.Internal_GetCursorStringIndex(position, content, cursorPixelPosition);
//		}

//		// Token: 0x0600033B RID: 827 RVA: 0x0000BA50 File Offset: 0x00009C50
//		internal int GetNumCharactersThatFitWithinWidth(string text, float width)
//		{
//			return this.Internal_GetNumCharactersThatFitWithinWidth(text, width);
//		}

//		// Token: 0x0600033C RID: 828 RVA: 0x0000BA6C File Offset: 0x00009C6C
//		public Vector2 CalcSize(GUIContent content)
//		{
//			return this.Internal_CalcSize(content);
//		}

//		// Token: 0x0600033D RID: 829 RVA: 0x0000BA88 File Offset: 0x00009C88
//		internal Vector2 CalcSizeWithConstraints(GUIContent content, Vector2 constraints)
//		{
//			return this.Internal_CalcSizeWithConstraints(content, constraints);
//		}

//		// Token: 0x0600033E RID: 830 RVA: 0x0000BAA4 File Offset: 0x00009CA4
//		public Vector2 CalcScreenSize(Vector2 contentSize)
//		{
//			return new Vector2((this.fixedWidth != 0f) ? this.fixedWidth : Mathf.Ceil(contentSize.x + (float)this.padding.left + (float)this.padding.right), (this.fixedHeight != 0f) ? this.fixedHeight : Mathf.Ceil(contentSize.y + (float)this.padding.top + (float)this.padding.bottom));
//		}

//		// Token: 0x0600033F RID: 831 RVA: 0x0000BB30 File Offset: 0x00009D30
//		public float CalcHeight(GUIContent content, float width)
//		{
//			return this.Internal_CalcHeight(content, width);
//		}

//		// Token: 0x17000081 RID: 129
//		// (get) Token: 0x06000340 RID: 832 RVA: 0x0000BB4A File Offset: 0x00009D4A
//		public bool isHeightDependantOnWidth
//		{
//			get
//			{
//				return this.fixedHeight == 0f && this.wordWrap && this.imagePosition != ImagePosition.ImageOnly;
//			}
//		}

//		// Token: 0x06000341 RID: 833 RVA: 0x0000BB74 File Offset: 0x00009D74
//		public void CalcMinMaxWidth(GUIContent content, out float minWidth, out float maxWidth)
//		{
//			Vector2 vector = this.Internal_CalcMinMaxWidth(content);
//			minWidth = vector.x;
//			maxWidth = vector.y;
//		}

//		// Token: 0x06000342 RID: 834 RVA: 0x0000BB9C File Offset: 0x00009D9C
//		public override string ToString()
//		{
//			return UnityString.Format("GUIStyle '{0}'", new object[]
//			{
//				this.name
//			});
//		}

//		// Token: 0x06000344 RID: 836
//		[MethodImpl(MethodImplOptions.InternalCall)]
//		private extern void get_contentOffset_Injected(out Vector2 ret);

//		// Token: 0x06000345 RID: 837
//		[MethodImpl(MethodImplOptions.InternalCall)]
//		private extern void set_contentOffset_Injected(ref Vector2 value);

//		// Token: 0x06000346 RID: 838
//		[MethodImpl(MethodImplOptions.InternalCall)]
//		private extern void get_clipOffset_Injected(out Vector2 ret);

//		// Token: 0x06000347 RID: 839
//		[MethodImpl(MethodImplOptions.InternalCall)]
//		private extern void set_clipOffset_Injected(ref Vector2 value);

//		// Token: 0x06000348 RID: 840
//		[MethodImpl(MethodImplOptions.InternalCall)]
//		private extern void get_Internal_clipOffset_Injected(out Vector2 ret);

//		// Token: 0x06000349 RID: 841
//		[MethodImpl(MethodImplOptions.InternalCall)]
//		private extern void set_Internal_clipOffset_Injected(ref Vector2 value);

//		// Token: 0x0600034A RID: 842
//		[MethodImpl(MethodImplOptions.InternalCall)]
//		private extern void Internal_Draw_Injected(ref Rect screenRect, GUIContent content, bool isHover, bool isActive, bool on, bool hasKeyboardFocus);

//		// Token: 0x0600034B RID: 843
//		[MethodImpl(MethodImplOptions.InternalCall)]
//		private extern void Internal_Draw2_Injected(ref Rect position, GUIContent content, int controlID, bool on);

//		// Token: 0x0600034C RID: 844
//		[MethodImpl(MethodImplOptions.InternalCall)]
//		private extern void Internal_DrawCursor_Injected(ref Rect position, GUIContent content, int pos, ref Color cursorColor);

//		// Token: 0x0600034D RID: 845
//		[MethodImpl(MethodImplOptions.InternalCall)]
//		private extern void Internal_DrawWithTextSelection_Injected(ref Rect screenRect, GUIContent content, bool isHover, bool isActive, bool on, bool hasKeyboardFocus, bool drawSelectionAsComposition, int cursorFirst, int cursorLast, ref Color cursorColor, ref Color selectionColor);

//		// Token: 0x0600034E RID: 846
//		[MethodImpl(MethodImplOptions.InternalCall)]
//		private extern void Internal_GetCursorPixelPosition_Injected(ref Rect position, GUIContent content, int cursorStringIndex, out Vector2 ret);

//		// Token: 0x0600034F RID: 847
//		[MethodImpl(MethodImplOptions.InternalCall)]
//		private extern int Internal_GetCursorStringIndex_Injected(ref Rect position, GUIContent content, ref Vector2 cursorPixelPosition);

//		// Token: 0x06000350 RID: 848
//		[MethodImpl(MethodImplOptions.InternalCall)]
//		private extern string Internal_GetSelectedRenderedText_Injected(ref Rect localPosition, GUIContent mContent, int selectIndex, int cursorIndex);

//		// Token: 0x06000351 RID: 849
//		[MethodImpl(MethodImplOptions.InternalCall)]
//		private extern Rect[] Internal_GetHyperlinksRect_Injected(ref Rect localPosition, GUIContent mContent);

//		// Token: 0x06000352 RID: 850
//		[MethodImpl(MethodImplOptions.InternalCall)]
//		private extern void Internal_CalcSize_Injected(GUIContent content, out Vector2 ret);

//		// Token: 0x06000353 RID: 851
//		[MethodImpl(MethodImplOptions.InternalCall)]
//		private extern void Internal_CalcSizeWithConstraints_Injected(GUIContent content, ref Vector2 maxSize, out Vector2 ret);

//		// Token: 0x06000354 RID: 852
//		[MethodImpl(MethodImplOptions.InternalCall)]
//		private extern void Internal_CalcMinMaxWidth_Injected(GUIContent content, out Vector2 ret);

//		// Token: 0x06000355 RID: 853
//		[MethodImpl(MethodImplOptions.InternalCall)]
//		private static extern void SetMouseTooltip_Injected(string tooltip, ref Rect screenRect);

//		// Token: 0x040000C6 RID: 198
//		[NonSerialized]
//		internal IntPtr m_Ptr;

//		// Token: 0x040000C7 RID: 199
//		[NonSerialized]
//		private GUIStyleState m_Normal;

//		// Token: 0x040000C8 RID: 200
//		[NonSerialized]
//		private GUIStyleState m_Hover;

//		// Token: 0x040000C9 RID: 201
//		[NonSerialized]
//		private GUIStyleState m_Active;

//		// Token: 0x040000CA RID: 202
//		[NonSerialized]
//		private GUIStyleState m_Focused;

//		// Token: 0x040000CB RID: 203
//		[NonSerialized]
//		private GUIStyleState m_OnNormal;

//		// Token: 0x040000CC RID: 204
//		[NonSerialized]
//		private GUIStyleState m_OnHover;

//		// Token: 0x040000CD RID: 205
//		[NonSerialized]
//		private GUIStyleState m_OnActive;

//		// Token: 0x040000CE RID: 206
//		[NonSerialized]
//		private GUIStyleState m_OnFocused;

//		// Token: 0x040000CF RID: 207
//		[NonSerialized]
//		private RectOffset m_Border;

//		// Token: 0x040000D0 RID: 208
//		[NonSerialized]
//		private RectOffset m_Padding;

//		// Token: 0x040000D1 RID: 209
//		[NonSerialized]
//		private RectOffset m_Margin;

//		// Token: 0x040000D2 RID: 210
//		[NonSerialized]
//		private RectOffset m_Overflow;

//		// Token: 0x040000D3 RID: 211
//		[NonSerialized]
//		private string m_Name;

//		// Token: 0x040000D4 RID: 212
//		internal static bool showKeyboardFocus = true;

//		// Token: 0x040000D5 RID: 213
//		private static GUIStyle s_None;
//	}
//}
