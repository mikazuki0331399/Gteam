using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthGauge : MonoBehaviour
{
    [SerializeField] private Image healthImage;
    [SerializeField] private Image burnImage;

    public float duration = 0.5f;
    public float strength = 20f;
    public int vibrate = 100;

    public float debugDamageRate = 0.1f;

    private float currentRate = 1f;

    private void Start()
    {
        SetGauge(1f);
    }

    public void SetGauge(float value)
    {
        // DoTweenÇòAåãÇµÇƒìÆÇ©Ç∑
        healthImage.DOFillAmount(value, duration)
                .OnComplete(() =>
                {
                    burnImage
                        .DOFillAmount(value, duration / 2f)
                        .SetDelay(0.5f);
                });

        currentRate = value;

    }

    // HPÉoÅ[ÇóhÇÁÇ∑
    public void ShakeGauge()
    {
        transform.DOShakePosition(
            duration / 2f,
            strength,
            vibrate);
    }


    public void TakeDamage(float rate)
    {
        SetGauge(currentRate - rate);
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        TakeDamage(debugDamageRate);
    //    }

    //    if (Input.GetKeyDown(KeyCode.A))
    //    {
    //        transform.DOShakePosition(
    //            duration / 2f,
    //            strength, vibrate);
    //    }
    //}
}