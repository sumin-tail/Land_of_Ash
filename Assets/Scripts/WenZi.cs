using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WenZi : MonoBehaviour
{
    [Header("UI组件")]
    public Text textLabel;
    public Image faceImage;

    [Header("文本文件")]
    public TextAsset textFile;
    public int index;
    public float textSpeed;

    [Header("头像")]
    public Sprite face01, face02, face03;

    bool textFinished;

    List<string> textList = new List<string>();

    void Awake()
    {
        GetTextFormFile(textFile);
    }

    private void OnEnable()
    {
        textFinished = true;
        StartCoroutine(setTextUI());

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Z)&& textFinished)
        {
            StartCoroutine(setTextUI());
        }
    }

    void GetTextFormFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var lineDate = file.text.Split('\n');

        foreach (var line in lineDate)
        {
            textList.Add(line);
        }
    
    
    }   

    IEnumerator setTextUI()
    {
        textFinished = false;
        textLabel.text = "";

        switch (textList[index])
        {
            case "플레이어\r":
                faceImage.sprite = face01;
                index++;
                break;
            case "일레비\r":
                faceImage.sprite = face02;
                index++;
                break;
            case "꿈의 그림자\r":
                faceImage.sprite = face03;
                index++;
                break;
            case "현실의 빛\r":
                faceImage.sprite = face02;
                index++;
                break;
        }

        for (int i = 0; i < textList[index].Length; i++)
        {
            textLabel.text += textList[index][i];

            yield return new WaitForSeconds(textSpeed);
        }
        textFinished = true;
        index++;
    }


}
