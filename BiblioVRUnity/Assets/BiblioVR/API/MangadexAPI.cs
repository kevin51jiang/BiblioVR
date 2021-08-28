using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using RSG;
using UnityEngine.Networking;
using System;
using SimpleJSON;
using UnityEditor;

namespace BiblioVR.Core
{

    public static class MangadexAPI
    {
        public const string API_URL = "https://api.mangadex.org";
        public const string DATA_URL = "https://uploads.mangadex.org/data";


        [Serializable]
        public struct MangadexResponse
        {
            public string result;
            public JSONNode data;
        }

        [Serializable]
        public struct Relationship
        {
            public string id;
            public string type;
        }

        /// <summary>
        /// Shorthand for getting top manga
        /// </summary>
        /// <returns></returns>
        public static IPromise<GetMangaListResponse> GetMangaTop()
        {
            return GetMangaSearch();
        }

        /// <summary>
        /// Searches for manga according to pararms
        /// </summary>
        /// <returns></returns>
        public static IPromise<GetMangaListResponse> GetMangaSearch(string title = "")
        {
            RequestHelper rh = new RequestHelper { Uri = $"{API_URL}/manga" };

            if (title != "")
            {
                rh.Params.Add("title", title);
            }
            

            return RestClient.Get<GetMangaListResponse>(rh);

        }

        [Serializable]
        public struct GetMangaListResponse
        {
            public int limit;
            public int offset;
            public int total;
            public MangadexResponse[] results;
        }

        /// <summary>
        /// Aggregates information about a certain manga
        /// </summary>
        /// <param name="id">Manga ID</param>
        /// <returns></returns>

        public static IPromise<GetMangaVolumesAndChaptersResponse> GetMangaVolumesAndChapters(string id)
        {

            RequestHelper rh = new RequestHelper { Uri = $"{API_URL}/manga/{id}/aggregate" };
            return RestClient.Get<GetMangaVolumesAndChaptersResponse>(rh);
        }

        [Serializable]
        public struct GetMangaVolumesAndChaptersResponse
        {
            public MangadexResponse res;
        }


        /// <summary>
        /// Gets details about a specific manga
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IPromise<GetMangaResponse> GetManga(string id)
        {

            RequestHelper rh = new RequestHelper { Uri = $"{API_URL}/manga/{id}" };
            return RestClient.Get<GetMangaResponse>(rh);
        }

        [Serializable]
        public struct GetMangaResponse
        {
            public MangadexResponse res;
            public Relationship[] relationships;
        }

        /// <summary>
        /// Gets details about a specific chapter, including the links to the images for download
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IPromise<GetChaptersResponse> GetChapters(string id)
        {

            RequestHelper rh = new RequestHelper
            {
                Uri = $"{API_URL}/chapter",
                Params = new Dictionary<string, string> { { "manga", id } }
            };
            return RestClient.Get<GetChaptersResponse>(rh);
        }

        [Serializable]
        public struct GetChaptersResponse
        {
            public MangadexResponse[] results;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="chapterHash">Hash returned from <see cref="MangadexAPI.GetChapter(string)">Get Chapter</see></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static IPromise<GetChapterImageResponse> GetChapterImage(string chapterHash, string filename)
        {
            RequestHelper rh = new RequestHelper
            {
                Uri = $"{DATA_URL}/{chapterHash}/{filename}",
                ParseResponseBody = false
            };



            return RestClient.Get<GetChapterImageResponse>(rh);
        }

        [Serializable]
        public struct GetChapterImageResponse
        {
            public Texture tex;
        }




    }
}
