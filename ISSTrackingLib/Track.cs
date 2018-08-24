using System;
using System.Net;
using Newtonsoft.Json;

namespace ISSTracking
{
    public struct Location {
        public float lon;
        public float lat;
    }

    public class Track {
        public static Location GetLocation() {
            var RawResponse = new WebClient().DownloadString("http://api.open-notify.org/iss-now.json");

            dynamic Response = JsonConvert.DeserializeObject(RawResponse);
            Location location = new Location();
            location.lat = Response.iss_position.latitude;
            location.lon = Response.iss_position.longitude;
            return location;
        } 
    }

}
