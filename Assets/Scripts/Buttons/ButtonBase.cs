
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonBase : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public delegate void OnUIEvent(GameObject obj);
    #region 交互事件
    /// <summary>
    /// 点击事件
    /// </summary>
    private OnUIEvent onClick;
    /// <summary>
    /// 按下事件
    /// </summary>
    private OnUIEvent onDown;
    /// <summary>
    /// 抬起事件
    /// </summary>
    private OnUIEvent onUp;
    #endregion

    #region 注册事件
    /// <summary>
    /// 注册点击事件
    /// </summary>
    public void RegistClick(OnUIEvent uiEvent)
    {
        onClick = uiEvent;
    }

    public void RegistDown(OnUIEvent uiEvent)
    {
        onDown = uiEvent;
    }

    public void RegistUp(OnUIEvent uiEvent)
    {
        onUp = uiEvent;
    }

    #endregion

    #region 事件响应
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        onClick?.Invoke(gameObject);
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        onDown?.Invoke(gameObject);
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        onUp?.Invoke(gameObject);
    }
    #endregion
}
