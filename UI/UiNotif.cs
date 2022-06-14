using System;
using UnityEngine;

// Token: 0x0200017F RID: 383
public abstract class UiNotif : EntityUINotification
{
	// Token: 0x06001237 RID: 4663 RVA: 0x0007BA54 File Offset: 0x00079C54
	public void Tick(float dt)
	{
		if (this.visible && this.shouldBeVisible == this.visible && this._displayTime > 0f)
		{
			this._displayTime -= dt;
			if (this._displayTime <= 0f)
			{
				this.shouldBeVisible = false;
			}
		}
		this.OnTick(dt, this.firstTick);
		this.firstTick = false;
		if (this.shouldBeVisible != this.visible)
		{
			this.visible = this.shouldBeVisible;
			if (this.shouldBeVisible)
			{
				this.stats.NotificationAdded(this);
			}
		}
	}

	// Token: 0x06001238 RID: 4664 RVA: 0x0007BAE8 File Offset: 0x00079CE8
	public virtual Color GetColor()
	{
		if (this.MinValue != this.MaxValue)
		{
			if (this.CurrentValue <= Mathf.Lerp(this.MinValue, this.MaxValue, 0.25f))
			{
				return this.EmergencyColor;
			}
			if (this.CurrentValue <= Mathf.Lerp(this.MinValue, this.MaxValue, 0.5f))
			{
				return this.AlertColor;
			}
			if (this.CurrentValue <= Mathf.Lerp(this.MinValue, this.MaxValue, 0.75f))
			{
				return this.WarningColor;
			}
		}
		if (this.Buff != null && this.Buff.BuffClass != null)
		{
			return this.Buff.BuffClass.IconColor;
		}
		return Color.white;
	}

	// Token: 0x17000288 RID: 648
	// (get) Token: 0x06001239 RID: 4665 RVA: 0x0007BB9D File Offset: 0x00079D9D
	public virtual Color WarningColor
	{
		get
		{
			return Color.white;
		}
	}

	// Token: 0x17000289 RID: 649
	// (get) Token: 0x0600123A RID: 4666 RVA: 0x0007BBA4 File Offset: 0x00079DA4
	public virtual Color AlertColor
	{
		get
		{
			return Color.yellow + Color.red;
		}
	}

	// Token: 0x1700028A RID: 650
	// (get) Token: 0x0600123B RID: 4667 RVA: 0x0007BBB5 File Offset: 0x00079DB5
	public virtual Color EmergencyColor
	{
		get
		{
			return Color.red;
		}
	}

	// Token: 0x0600123C RID: 4668
	protected abstract void OnTick(float dt, bool firstTick);

	// Token: 0x1700028B RID: 651
	// (get) Token: 0x0600123D RID: 4669 RVA: 0x0007BBBC File Offset: 0x00079DBC
	protected float displayTime
	{
		get
		{
			return this._displayTime;
		}
	}

	// Token: 0x1700028C RID: 652
	// (get) Token: 0x0600123E RID: 4670 RVA: 0x0007BBC4 File Offset: 0x00079DC4
	protected bool isPermenentlyVisible
	{
		get
		{
			return this.visible && this._displayTime == 0f;
		}
	}

	// Token: 0x0600123F RID: 4671 RVA: 0x0007BBDD File Offset: 0x00079DDD
	protected void SetVisible(bool visible, float displayTime)
	{
		this.shouldBeVisible = visible;
		this._displayTime = displayTime;
	}

	// Token: 0x06001240 RID: 4672 RVA: 0x0007BBED File Offset: 0x00079DED
	public void SetBuff(BuffValue _buff)
	{
	}

	// Token: 0x06001241 RID: 4673 RVA: 0x0007BBEF File Offset: 0x00079DEF
	public void SetStats(EntityStats _stats)
	{
		this.stats = _stats;
	}

	// Token: 0x06001242 RID: 4674 RVA: 0x0007BBF8 File Offset: 0x00079DF8
	public void Reset()
	{
		this.visible = false;
	}

	// Token: 0x06001243 RID: 4675 RVA: 0x0007BC01 File Offset: 0x00079E01
	public void NotifyBuffRemoved()
	{
	}

	// Token: 0x1700028D RID: 653
	// (get) Token: 0x06001244 RID: 4676 RVA: 0x0007BC03 File Offset: 0x00079E03
	public virtual float MinValue
	{
		get
		{
			return 0f;
		}
	}

	// Token: 0x1700028E RID: 654
	// (get) Token: 0x06001245 RID: 4677 RVA: 0x0007BC0A File Offset: 0x00079E0A
	public virtual float MaxValue
	{
		get
		{
			return 0f;
		}
	}

	// Token: 0x1700028F RID: 655
	// (get) Token: 0x06001246 RID: 4678
	public abstract float MinWarningLevel { get; }

	// Token: 0x17000290 RID: 656
	// (get) Token: 0x06001247 RID: 4679
	public abstract float MaxWarningLevel { get; }

	// Token: 0x17000291 RID: 657
	// (get) Token: 0x06001248 RID: 4680
	public abstract float CurrentValue { get; }

	// Token: 0x17000292 RID: 658
	// (get) Token: 0x06001249 RID: 4681
	public abstract string Units { get; }

	// Token: 0x17000293 RID: 659
	// (get) Token: 0x0600124A RID: 4682
	public abstract string Icon { get; }

	// Token: 0x17000294 RID: 660
	// (get) Token: 0x0600124B RID: 4683 RVA: 0x0007BC11 File Offset: 0x00079E11
	public float FadeOutTime
	{
		get
		{
			return 0.15f;
		}
	}

	// Token: 0x17000295 RID: 661
	// (get) Token: 0x0600124C RID: 4684 RVA: 0x0007BC18 File Offset: 0x00079E18
	public virtual BuffValue Buff
	{
		get
		{
			return null;
		}
	}

	// Token: 0x17000296 RID: 662
	// (get) Token: 0x0600124D RID: 4685 RVA: 0x0007BC1B File Offset: 0x00079E1B
	public virtual string Description
	{
		get
		{
			return "";
		}
	}

	// Token: 0x17000297 RID: 663
	// (get) Token: 0x0600124E RID: 4686 RVA: 0x0007BC22 File Offset: 0x00079E22
	public EntityStats EntityStats
	{
		get
		{
			return this.stats;
		}
	}

	// Token: 0x17000298 RID: 664
	// (get) Token: 0x0600124F RID: 4687 RVA: 0x0007BC2A File Offset: 0x00079E2A
	public virtual bool Visible
	{
		get
		{
			return this.visible;
		}
	}

	// Token: 0x17000299 RID: 665
	// (get) Token: 0x06001250 RID: 4688 RVA: 0x0007BC32 File Offset: 0x00079E32
	public virtual bool Expired
	{
		get
		{
			return !this.Visible;
		}
	}

	// Token: 0x1700029A RID: 666
	// (get) Token: 0x06001251 RID: 4689 RVA: 0x0007BC3D File Offset: 0x00079E3D
	public virtual EnumEntityUINotificationDisplayMode DisplayMode
	{
		get
		{
			return EnumEntityUINotificationDisplayMode.IconPlusCurrentValue;
		}
	}

	// Token: 0x1700029B RID: 667
	// (get) Token: 0x06001252 RID: 4690
	public abstract EnumEntityUINotificationSubject Subject { get; }

	// Token: 0x04000B7A RID: 2938
	private EntityStats stats;

	// Token: 0x04000B7B RID: 2939
	private bool visible;

	// Token: 0x04000B7C RID: 2940
	private float _displayTime;

	// Token: 0x04000B7D RID: 2941
	private bool shouldBeVisible;

	// Token: 0x04000B7E RID: 2942
	private bool firstTick = true;

	// Token: 0x04000B7F RID: 2943
	protected const float MaxWaitTime = 2f;

	// Token: 0x04000B80 RID: 2944
	protected float waitTime = 2f;
}
