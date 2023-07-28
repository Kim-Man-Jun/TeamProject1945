using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossWaring : MonoBehaviour
{
    [SerializeField]
    float lerptime = 0.2f;
    TextMeshProUGUI textBossWarning;

    private void Awake()
    {
        textBossWarning = GetComponent<TextMeshProUGUI>();
        Destroy(textBossWarning, 2.5f);
    }

    private void OnEnable()
    {
        StartCoroutine("ColorLerpLoop");
    }

    IEnumerator ColorLerpLoop()
    {
        while (this)
        {
            //�� ������ �Ͼ������ ����������
            yield return StartCoroutine(ColorLerp(Color.white, Color.red));
            //�� ������ ���������� �Ͼ������
            yield return StartCoroutine(ColorLerp(Color.red, Color.white));
        }
    }

    //������ �ε巴�� �ٲٱ�
    IEnumerator ColorLerp(Color startcolor, Color endcolor)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            //lerptime �ð� ���� while �ݺ� ����
            currentTime += Time.deltaTime;
            percent = currentTime / lerptime;

            //startcolor���� endcolor�� ����
            textBossWarning.color = Color.Lerp(startcolor, endcolor, percent);

            yield return null;
        }

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
