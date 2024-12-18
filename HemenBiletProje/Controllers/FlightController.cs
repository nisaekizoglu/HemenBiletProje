using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace HemenBiletProje.Controllers
{
    public class FlightController : Controller
    {
        // API URL ve Anahtar
        private readonly string _apiUrl = "https://api.aviationstack.com/v1/flights";
        private readonly string _apiKey = "b42cedd7ea1352bf8982debd17f3a1cc";

        // Veritabaný baðlantý dizesi
        private readonly string _connectionString = "Server=GULSEN;Database=Flights;Trusted_Connection=True;";

        // Index Action: API'den veri çekip veritabanýna kaydeder ve görüntüler
        public async Task<ActionResult> Index()
        {
            var flights = await GetFlightDataAsync(); // API'den veri çek
            int rowsInserted = SaveFlightsToDatabase(flights); // Veritabanýna kaydet

            ViewBag.Message = $"{rowsInserted} adet uçuþ verisi baþarýyla kaydedildi.";
            return View(flights); // Veriyi View'a gönder
        }

        // API'den Veri Çekme Metodu
        private async Task<List<Flight>> GetFlightDataAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string requestUrl = $"{_apiUrl}?access_key={_apiKey}";
                HttpResponseMessage response = await client.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
                    return apiResponse?.Data;
                }
                return null;
            }
        }

        // Veriyi Veritabanýna Kaydetme Metodu
        private int SaveFlightsToDatabase(List<Flight> flights)
        {
            int rowsInserted = 0;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                foreach (var flight in flights)
                {
                    // Scheduled tarihini dönüþtür
                    DateTime scheduledDate;
                    object scheduledValue = DateTime.TryParse(flight.Departure?.Scheduled, out scheduledDate)
                        ? (object)scheduledDate
                        : DBNull.Value;

                    var command = new SqlCommand(
                        "INSERT INTO FlightInfoes (FlightDate, FlightStatus, Airport, Scheduled) " +
                        "VALUES (@FlightDate, @FlightStatus, @Airport, @Scheduled)", connection);

                    command.Parameters.AddWithValue("@FlightDate", flight.FlightDate ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@FlightStatus", flight.FlightStatus ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Airport", flight.Departure?.Airport ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Scheduled", scheduledValue);

                    rowsInserted += command.ExecuteNonQuery();
                }
            }
            return rowsInserted;
        }
    }

    // JSON Model Sýnýflarý
    public class ApiResponse
    {
        [JsonProperty("data")]
        public List<Flight> Data { get; set; }
    }

    public class Flight
    {
        [JsonProperty("flight_date")]
        public string FlightDate { get; set; }

        [JsonProperty("flight_status")]
        public string FlightStatus { get; set; }

        [JsonProperty("departure")]
        public DepartureInfo Departure { get; set; }
    }

    public class DepartureInfo
    {
        [JsonProperty("airport")]
        public string Airport { get; set; }

        [JsonProperty("scheduled")]
        public string Scheduled { get; set; }
    }
}
