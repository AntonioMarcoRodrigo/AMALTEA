using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RefreshFitter : MonoBehaviour
{
    private ContentSizeFitter contentSizeFitter;

    private void Awake()
    {
        contentSizeFitter = GetComponent<ContentSizeFitter>();
    }

    private void OnEnable()
    {
        if (contentSizeFitter != null)
            StartCoroutine(ToggleContentSizeFitter());     
    }

    private IEnumerator ToggleContentSizeFitter()
    {
        if (gameObject.CompareTag("Content"))
            yield return new WaitForSeconds(0.5f);
        contentSizeFitter.enabled = true;
        yield return new WaitForSeconds(0.5f);
        contentSizeFitter.enabled = false;
    }
}