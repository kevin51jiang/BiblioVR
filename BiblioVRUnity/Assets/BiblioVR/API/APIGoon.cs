using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BiblioVR.Core;
using SimpleJSON;

public class APIGoon : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public static void GetMangaTop()
    {
        MangadexAPI.GetMangaTop().Then(res =>
        {
            var json = JsonUtility.ToJson(res, true);
            Debug.Log(json);
        });

    }

    public static void GetMangaSearch()
    {
        MangadexAPI.GetMangaSearch("attack").Then(res =>
        {
            var json = JsonUtility.ToJson(res, true);
            Debug.Log(json);
        });
    }

    public static void GetMangaVolumesAndChapters()
    {
        MangadexAPI.GetMangaVolumesAndChapters("304ceac3-8cdb-4fe7-acf7-2b6ff7a60613").Then(res =>
        {
            var json = JsonUtility.ToJson(res, true);
            Debug.Log(json);
        });
    }


    public static void GetManga()
    {
        MangadexAPI.GetManga("304ceac3-8cdb-4fe7-acf7-2b6ff7a60613").Then(res =>
        {
            var json = JsonUtility.ToJson(res, true);
            Debug.Log(json);
        });
    }

    public static void GetChapters()
    {
        MangadexAPI.GetChapters("304ceac3-8cdb-4fe7-acf7-2b6ff7a60613").Then(res =>
        {
            var json = JsonUtility.ToJson(res, true);
            Debug.Log(json);
        });
    }

    public static void GetChapterImage()
    {
        const string hash = "05e7c31138f373bc9d8763ccfb5ecb46";
        string[] imageUrls = {
            "x1-fb49e8e939ec95b6ed22d9f91160acfcdf839fc04516775a92afe04558bb8a51.png",
            "x2-d2f2853c0b1ef2894b28a9f4d7576722d76a2b91e9b2da923f708cc6ada53831.png",
            "x3-06151c6cf062751716ecadfa3adfe7dc04ec41bf6cd46a09d070a553a78d256d.png",
            "x4-e897ffcd58330b2421e4fa233a756c053373daa7a06ff81573d4ba362fee38b9.png",
            "x5-a1ef0b162ae7b6f190a932a2814791f96371e31f1e1783f3f126bfbe77da5637.png" };

        foreach (var imageurl in imageUrls)
        {
            MangadexAPI.GetChapterImage("05e7c31138f373bc9d8763ccfb5ecb46", imageurl).Then(res =>
            {
                var json = JsonUtility.ToJson(res, true);
                Debug.Log(json);
            });
        }

     
    }
}
