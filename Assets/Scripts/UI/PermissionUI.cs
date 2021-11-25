using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PermissionUI : MonoBehaviour
{
    public Text FullNameText;
    public Text DescribeText;

    public Text ResultText;
    public Button CheckBtn;
    public Button RequireBtn;

    public PermissionInfo info;
 
    public UnityEngine.Android.PermissionCallbacks callbacks;
 
    public void SetInfo(PermissionInfo info)
    {
        this.info = info;
        Init();
    }
    public void Init()
    {
        FullNameText = transform.Find("FullNameText").GetComponent<Text>();
        DescribeText = transform.Find("DescribeText").GetComponent<Text>();

        CheckBtn = transform.Find("Content/CheckBtn").GetComponent<Button>();
        RequireBtn = transform.Find("Content/RequireBtn").GetComponent<Button>();
        ResultText = transform.Find("Content/ResultText").GetComponent<Text>();

        FullNameText.text = info.FullName;
        DescribeText.text = info.Describe;
 
        callbacks = new UnityEngine.Android.PermissionCallbacks();
        callbacks.PermissionDenied += OnPermissionGranted;
        callbacks.PermissionDenied += OnPermissionDenied;
        callbacks.PermissionDeniedAndDontAskAgain += OnPermissionDeniedAndDontAskAgain;

        CheckBtn.onClick.AddListener
        (
            () =>
            {
                if (UnityEngine.Android.Permission.HasUserAuthorizedPermission(info.FullName))
                {
                    ResultText.color = Color.green;
                    ResultText.text = "����Ȩ";
                }
                else
                {
                    ResultText.color = Color.red;
                    ResultText.text = "δ��Ȩ!";
                }
            }
        );

        RequireBtn.onClick.AddListener
        (
         () =>
         {
             UnityEngine.Android.Permission.RequestUserPermission(info.FullName, callbacks);
         }
         );
    }

    public void OnPermissionGranted(string permissionName)
    {
        Debug.Log(permissionName + "����Ȩ");
        ResultText.color = Color.green;
        ResultText.text = "����Ȩ";
    }

    public void OnPermissionDenied(string permissionName)
    {
        Debug.Log(permissionName + "δ��Ȩ");
        ResultText.color = Color.red;
        ResultText.text = "δ��Ȩ!";
    }

    public void OnPermissionDeniedAndDontAskAgain(string permissionName)
    {
        Debug.Log(permissionName + "δ��Ȩ���Ҳ���ѯ��!");
        ResultText.color = Color.red;
        ResultText.text = "δ��Ȩ���Ҳ���ѯ��!";
    }
}
