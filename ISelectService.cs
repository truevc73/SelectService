using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface ISelectService
{
    [OperationContract]
    List<string> GetArtist();

    [OperationContract]
    List<string> GetShow();

    [OperationContract]
    List<string> GetVenue();

    [OperationContract]
    List<ShowInfo> GetShowbyVenue(string showName);

    [OperationContract]
    List<ShowInfo> GetShowbyArtist(string artistShowName);

}

[DataContract]

public class ShowInfo
{
    [DataMember]
    public string ArtistName { set; get; }

    [DataMember]
    public string ShowName { set; get; }

    [DataMember]
    public string ShowDate { set; get; }

    [DataMember]
    public string ShowTime { set; get; }


    [DataMember]
    public string VenueName { set; get; }

}