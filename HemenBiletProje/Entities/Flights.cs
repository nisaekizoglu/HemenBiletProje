using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HemenBiletProje.Entities
{
    public class Flights
    {

        public class Rootobject
        {
          
            public Data data { get; set; }
        }

        public class Data
        {
            public Session session { get; set; }
            public bool complete { get; set; }
            public int numOfFilters { get; set; }
            public int totalNumResults { get; set; }
            public Flight[] flights { get; set; }
        }

        public class Session
        {
            public string searchHash { get; set; }
            public string pageLoadUid { get; set; }
            public string searchId { get; set; }
        }

     

        public class Flight
        {
            public Segment[] segments { get; set; }
            public Purchaselink[] purchaseLinks { get; set; }
            public Itinerarytag itineraryTag { get; set; }
        }

        public class Itinerarytag
        {
            public string tag { get; set; }
            public string type { get; set; }
        }

        public class Segment
        {
            public Leg[] legs { get; set; }
            public object[] layovers { get; set; }
        }

        public class Leg
        {
            public string originStationCode { get; set; }
            public string destinationStationCode { get; set; }
            public DateTime departureDateTime { get; set; }
            public DateTime arrivalDateTime { get; set; }
           
        }

       
        public class Purchaselink
        {
            public string purchaseLinkId { get; set; }
            public string providerId { get; set; }
            public string commerceName { get; set; }
            public string currency { get; set; }
            public string originalCurrency { get; set; }
            public int seatAvailability { get; set; }
            public int taxesAndFees { get; set; }
            public int taxesAndFeesPerPassenger { get; set; }
            public float totalPrice { get; set; }
            public float totalPricePerPassenger { get; set; }
            public object[] fareBasisCodes { get; set; }
            public object[] containedPurchaseLinks { get; set; }
            public bool isPaid { get; set; }
            public object[] fareAttributesList { get; set; }
            public string url { get; set; }
        }


     

    }
}