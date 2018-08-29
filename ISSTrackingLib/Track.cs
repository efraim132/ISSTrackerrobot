using System;
using System.Net;
using Newtonsoft.Json;
using ISStracking;

namespace ISStracking {
    public struct Location {
        public double lon;
        public double lat;
        public double alt;
    }
}

namespace ISSTracking.Web {


    public class Track {
        public static Location GetLocation() {
            var RawResponse = new WebClient().DownloadString("https://api.wheretheiss.at/v1/satellites/25544");

            dynamic Response = JsonConvert.DeserializeObject(RawResponse);
            Location location;
            location.lat = Response.latitude;
            location.lon = Response.longitude;
            location.alt = Response.altitude;
            return location;
        }
    }

}
