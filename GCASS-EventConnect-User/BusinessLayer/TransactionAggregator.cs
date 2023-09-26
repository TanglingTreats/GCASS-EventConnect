using GCASS_EventConnect_User.Config;
using GCASS_EventConnect_User.DataLayer;
using GCASS_EventConnect_User.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace GCASS_EventConnect_User.BusinessLayer
{
    /// <summary>
    /// Aggregates data from event and ballot services to build transaction
    /// </summary>

    public interface ITransactionAggregator
    {
        /// <summary>
        /// Builds and returns a transaction
        /// Persists transaction data (cache)
        /// </summary>
        public Task<DataLayer.Transaction> BuildTransaction(string userId);
    }

    public class TransactionAggregator : ITransactionAggregator
    {
        private readonly IHttpClientFactory _http;
        private readonly ILogger<TransactionAggregator> _logger;
        private readonly TransactionConfig _transactionConfig;
        private readonly TransactionDbContext _db;

        public TransactionAggregator(
            IHttpClientFactory http,
            ILogger<TransactionAggregator> logger,
            IOptions<TransactionConfig> transactionConfig,
            TransactionDbContext db
        ) { 
            _http = http;
            _logger = logger;
            _transactionConfig = transactionConfig.Value;
            _db = db;
        }

        public async Task<DataLayer.Transaction> BuildTransaction(string userId)
        {
            var httpClient = _http.CreateClient();
            var ballotData = await FetchBallotData(httpClient, userId);
            var eventData = await FetchEventData(httpClient, userId);

            //fill in code here
        }

        private async Task<List<Ballot>> FetchBallotData(HttpClient httpClient, string userId)
        {
            var endpoint = BuildBallotServiceEndpoint(userId);
            var ballotRecords = await httpClient.GetAsync(endpoint);
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var ballotData = await ballotRecords.Content.ReadFromJsonAsync<List<Ballot>>(jsonSerializerOptions);
            return ballotData ?? new List<Ballot>();
        }

        private string? BuildBallotServiceEndpoint(string userId)
        {
            var ballotServiceProtocol = _transactionConfig.BallotDataProtocol;
            var ballotServiceHost = _transactionConfig.BallotDataHost;
            var ballotServicePort = _transactionConfig.BallotDataPort;
            return $"{ballotServiceProtocol}://{ballotServiceHost}:{ballotServicePort}/transaction/{userId}";
        }

        private async Task<List<Event>> FetchEventData(HttpClient httpClient, string userId)
        {
            var endpoint = BuildEventServiceEndpoint(userId);
            var eventRecords = await httpClient.GetAsync(endpoint);
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var eventData = await eventRecords.Content.ReadFromJsonAsync<List<Event>>(jsonSerializerOptions);
            return eventData ?? new List<Event>();
        }

        private string? BuildEventServiceEndpoint(string userId)
        {
            var eventServiceProtocol = _transactionConfig.EventDataProtocol;
            var eventServiceHost = _transactionConfig.EventDataHost;
            var eventServicePort = _transactionConfig.EventDataPort;
            return $"{eventServiceProtocol}://{eventServiceHost}:{eventServicePort}/transaction/{userId}";
        }
    }
}
