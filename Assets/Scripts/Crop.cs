using UnityEngine;

public class Crop : MonoBehaviour
{
    [SerializeField] private Transform cropRenderer;
    [SerializeField] private ParticleSystem cropEffect;
    public void GrowUp(float a)
    {
        LeanTween.scale(cropRenderer.gameObject, cropRenderer.localScale *= a, 1f)
            .setEase(LeanTweenType.easeInOutBack);
    }

    public void ScaleDown()
    {
        LeanTween.scale(cropRenderer.gameObject, Vector3.zero, 0.5f).setOnComplete(DestroyCrop);
    }

    public void PlayEffect()
    {
        cropEffect.gameObject.SetActive(true);
        cropEffect.transform.parent = null;
        cropEffect.Play();
    }
    private void DestroyCrop()
    {
        Destroy(gameObject);
    }
}
