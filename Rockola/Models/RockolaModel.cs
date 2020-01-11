using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System;
using System.Threading.Tasks;
using Rockola.Models;
using System.Collections.Generic;
//using Google.Apis.Samples.Helper;


namespace Rockola.Models
{
    public class RockolaModel
    {

        public static   List<Videos> Buscars(string videoToSearch)
        {
                SearchVideos videos = new SearchVideos();
            List<Videos> vvv = new List<Videos>(); 

            try
            {
                YouTubeService youtube = new YouTubeService(new BaseClientService.Initializer {
                    ApiKey = "AIzaSyBJjUKCgCuPP2BbXCl8fsvAAiuK1xdmId4",
                    ApplicationName = "Rockola-264715"
                }
                );
                SearchResource.ListRequest searchListRequest = youtube.Search.List("snippet");
                searchListRequest.Q = videoToSearch;
                searchListRequest.MaxResults = 40;
                SearchListResponse searchListResponse = searchListRequest.Execute();

                foreach (var searchResult in searchListResponse.Items)
                {
                    switch (searchResult.Id.Kind)
                    {
                        case "youtube#video":
                            vvv.Add(new Videos {
                                id = searchResult.Id.VideoId,
                                Nombre = searchResult.Snippet.Title,
                                Url="http://youtu.be/" + searchResult.Id.VideoId,
                                Thumbnail = "http://img.youtube.com/vi/" + searchResult.Id.VideoId + "/hqdefault.jpg"

                    });
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Exception x = ex;
            }
            return vvv;
        }
    }
}