using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PermissionUIController : MonoBehaviour
{
    public PermissionUI prefab;
    public RectTransform Content;
    public PermissionInfos Info;

    void Start()
    {
        foreach (var item in Info.Infos)
        {
            PermissionUI clone = Instantiate(prefab);
            clone.transform.SetParent(Content);
            clone.transform.localScale = Vector3.one;
            clone.SetInfo(item);
        }
        prefab.gameObject.SetActive(false);
    }
}