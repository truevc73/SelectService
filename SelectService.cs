using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class SelectService : ISelectService
{
    ShowTrackerEntities ste = new ShowTrackerEntities();
    public List<string> GetArtist()
    {
        List<string> Artists = new List<string>();

        var art = from a in ste.Artists select new { a.ArtistName };
        foreach (var n in art)
        {
            Artists.Add(n.ArtistName.ToString());
        }
        return Artists;
    }

    public List<string> GetShow()
    {
        List<string> Shows = new List<string>();

        var show = from s in ste.Shows select new { s.ShowName };
        foreach (var n in show)
        {
            Shows.Add(n.ShowName.ToString());
        }
        return Shows;
    }

    public List<ShowInfo> GetShowbyArtist(string artistShowName)
    {
        List<ShowInfo> artistshow = new List<ShowInfo>();

        var artshow = from a in ste.Shows
                      from b in a.ShowDetails
                      where b.Artist.ArtistName.Equals(artistShowName)
                      select new
                      {
                          a.ShowName,
                          a.ShowDate,
                          a.ShowTime,
                          a.Venue.VenueName
                      };
        foreach (var s in artshow)
        {
            ShowInfo info = new ShowInfo();
            info.ShowName = s.ShowName;
            info.ShowDate = s.ShowDate.ToString();
            info.ShowTime = s.ShowTime.ToString();
            info.VenueName = s.VenueName;
            artistshow.Add(info);
        }
        return artistshow;
    }


    public List<ShowInfo> GetShowbyVenue(string showName)
    {
        List<ShowInfo> venueshow = new List<ShowInfo>();

        var venshow = from a in ste.Shows

                      where a.Venue.VenueName.Equals(showName)
                      select new
                      {
                          a.ShowName,
                          a.ShowDate,
                          a.ShowTime,
                          a.Venue.VenueName
                      };
        foreach (var v in venshow)
        {
            ShowInfo info = new ShowInfo();
            info.ShowName = v.ShowName;
            info.ShowDate = v.ShowDate.ToString();
            info.ShowTime = v.ShowTime.ToString();
            info.VenueName = v.VenueName;
            venueshow.Add(info);
        }
        return venueshow;
    }

    public List<string> GetVenue()
    {
        List<string> Venues = new List<string>();

        var ven = from a in ste.Venues select new { a.VenueName };
        foreach (var v in ven)
        {
            Venues.Add(v.VenueName.ToString());
        }
        return Venues;
    }
}