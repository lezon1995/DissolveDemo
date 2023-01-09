using System;
using AmazingAssets.AdvancedDissolve;
using DG.Tweening;
using UnityEngine;

public class StageDoor : MonoBehaviour
{
    public string Entry1Stage;
    public string Entry2Stage;
    public ColliderTrigger ColliderTrigger1;
    public ColliderTrigger ColliderTrigger2;
    public GameObject Door;
    public event Action<string, string, StageDoor> OnStageChanged;

    private Action m_OnEntry1Enter;
    private Action m_OnEntry2Enter;

    public bool IsOpen
    {
        get
        {
            if (Door)
            {
                return !Door.activeInHierarchy;
            }

            return false;
        }
        set
        {
            if (Door)
            {
                Door.SetActive(!value);
            }
        }
    }

    public bool IsClose
    {
        get
        {
            if (Door)
            {
                return Door.activeInHierarchy;
            }

            return false;
        }
        set
        {
            if (Door)
            {
                Door.SetActive(value);
            }
        }
    }


    private AdvancedDissolvePropertiesController PropertiesController;

    private void Awake()
    {
        PropertiesController = FindObjectOfType<AdvancedDissolvePropertiesController>();

        var filter = new ColliderFilter
        {
            Name = "TriggerEnterPlayer",
            Layer = LayerMask.NameToLayer("Player"),
            Type = CollideType.TriggerEnter,
            ColliderCallback = this.OnPlayerEnterEntry1
        };
        ColliderTrigger1.AddFilter(filter);

        filter = new ColliderFilter
        {
            Name = "TriggerEnterPlayer",
            Layer = LayerMask.NameToLayer("Player"),
            Type = CollideType.TriggerEnter,
            ColliderCallback = this.OnPlayerEnterEntry2
        };
        ColliderTrigger2.AddFilter(filter);

        OnStageChanged = (stage1, stage2, door) =>
        {
            // var preStage = GameRoot.Stage.GetStage(stage1);
            // var curStage = GameRoot.Stage.GetStage(stage2);
            // GameRoot.Hero.GetHero().Get<CHeroBelongStage>().CurrentStage(curStage);

            switch (stage2)
            {
                case "Inside":
                    DOTween.To(value => PropertiesController.cutoutStandard.clip = value, 0, 1, 1.5F).SetEase(Ease.OutCubic);

                    Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Ground")); //tree   在原来的基础上减掉第11层
                    break;
                case "Outside":
                    DOTween.To(value => PropertiesController.cutoutStandard.clip = value, 1, 0, 1.5F).SetEase(Ease.OutCubic);
                    Camera.main.cullingMask |= (1 << LayerMask.NameToLayer("Ground")); //tree  在原来的基础上增加第11层
                    break;
            }

            Debug.Log($"OnStageChanged{stage1}->{stage2}");
        };
    }

    private void OnPlayerEnterEntry1(Collider c)
    {
        if (m_OnEntry1Enter != null)
        {
            m_OnEntry1Enter.Invoke();
            m_OnEntry1Enter = null;
        }
        else
        {
            m_OnEntry2Enter = OnEntry2Enter;
        }
    }

    private void OnEntry2Enter()
    {
        //从stage1到stage2
        OnStageChanged?.Invoke(Entry1Stage, Entry2Stage, this);
    }

    private void OnPlayerEnterEntry2(Collider c)
    {
        if (m_OnEntry2Enter != null)
        {
            m_OnEntry2Enter.Invoke();
            m_OnEntry2Enter = null;
        }
        else
        {
            m_OnEntry1Enter = OnEntry1Enter;
        }
    }

    private void OnEntry1Enter()
    {
        //从stage2到stage1
        OnStageChanged?.Invoke(Entry2Stage, Entry1Stage, this);
    }

    public void Close()
    {
        IsClose = true;
    }

    public void Open()
    {
        IsOpen = true;
    }
}