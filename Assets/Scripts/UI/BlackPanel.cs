using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlackPanel : BasePanel
{
    public float fadeTime = 0.5f;
    public float LoadingTime = 2;

    [Header("加载场景进度条")]
    public Image loadingBar;
    [Header("加载进度 %")]
    public TMP_Text loadingText;
    public override void HidePanel()
    {
        base.HidePanel();
    }

    public override IEnumerator HidePanelTweenEffect()
    {
        UITween.Instance.UIDoFade(transform, 1, 0, transTime / 2);
        yield return new WaitForSeconds(transTime / 2);
    }

    public override void ShowPanel()
    {
        base.ShowPanel();
    }

    public override IEnumerator ShowPanelTweenEffect()
    {

        yield return null;
        UITween.Instance.UIDoFade(transform, 0, 1, fadeTime);
    }

    protected override void Init()
    {
        base.Init();
    }

    public void SceneLoadingTrans(int index)
    {
        StartCoroutine(LoadingBar(index));
    }

    IEnumerator ShaderTrans()
    {
        yield return null;
    }

    private IEnumerator LoadingBar(int index)
    {
        yield return new WaitForSeconds(fadeTime);
        float timer = 0;
        while (timer < LoadingTime * 0.8f)
        {
            float value = Mathf.Lerp(0, 1, timer / LoadingTime);
            timer += Time.deltaTime;
            yield return null;
            loadingBar.fillAmount = value;
            loadingText.text = ((int)(loadingBar.fillAmount * 100)).ToString() + "%";
        }

        yield return SceneLoader.Instance.LoadNewScene(index);

        yield return new WaitForSeconds(0.8f);
        loadingBar.fillAmount = 1;
        yield return new WaitForSeconds(fadeTime);
        UIManager.Instance.HidePanel<BlackPanel>();

    }


}
