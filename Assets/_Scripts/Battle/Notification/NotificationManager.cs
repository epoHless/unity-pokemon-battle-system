using System.Collections;
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
        StartCoroutine(nameof(ShowNotificationCOR), message);
    }

    public IEnumerator ShowNotificationCOR(string message, float duration = 1f)
    {
        IsDone = false;
        this.message.text = message;
        notificationPanel.ToggleCanvas(true).setOnComplete(() =>
        {
            LeanTween.delayedCall(duration, () =>
            {
                notificationPanel.ToggleCanvas(false).setOnComplete((() =>
                {
                    IsDone = true;
                }));
            });
        });

        yield return new WaitUntil((() => IsDone));
    }
}

