using TMPro;
using UnityEngine;

public class NotificationManager : Singleton<NotificationManager>
{
    private CanvasHider notificationPanel;
    [SerializeField] private TMP_Text message;

    public static bool IsDone = false;
    
    protected override void Awake()
    {
        base.Awake();

        notificationPanel = GetComponent<CanvasHider>();
    }

    public void ShowNotification(string message)
    {
        IsDone = false;
        this.message.text = message;
        notificationPanel.ToggleCanvas(true).setOnComplete(() =>
        {
            LeanTween.delayedCall(1f, () =>
            {
                notificationPanel.ToggleCanvas(false);
                IsDone = true;
            });
        });
    }
}

