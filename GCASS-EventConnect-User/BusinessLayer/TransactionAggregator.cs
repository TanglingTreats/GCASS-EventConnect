using GCASS_EventConnect.Models;
using GCASS_EventConnect_User.Config;
using GCASS_EventConnect_User.DataLayer;
using GCASS_EventConnect_User.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
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
        public Task<DataLayer.Transaction> BuildTransaction(string ballotId);
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

        public async Task<DataLayer.Transaction> BuildTransaction(string ballotId)
        {
            var transaction = new DataLayer.Transaction();
            var httpClient = _http.CreateClient();

            //Get ballot
            var ballotData = await FetchBallotData(httpClient, ballotId);
            var balData = ballotData.ToList().FirstOrDefault();

            //Get ballot status
            if ( balData != null ) {
                var ballotStatusData = await FetchBallotStatusData(httpClient, balData.status.ToString());
                var bSD = ballotStatusData.ToList().FirstOrDefault();

                if (bSD != null)
                {
                    if (bSD.value == "Approved")
                    {
                        //Get booth data
                        var boothData = await FetchBoothData(httpClient, balData.boothId.ToString());
                        var bD = boothData.ToList().FirstOrDefault();

                        if (bD != null)
                        {
                            //Populate transaction
                            transaction.eventId = Guid.Parse(bD.eventId);
                            transaction.userId = balData.userId;
                            transaction.ballotId = balData.id;
                            transaction.createdBy = "System";
                            transaction.createdTime = DateTime.Now;

                            //Save transaction to DB
                            _db.Add(transaction);
                            await _db.SaveChangesAsync();

                        }
                    }
                }
            }
            return transaction;
        }

        private async Task<List<Ballot>> FetchBallotData(HttpClient httpClient, string ballotId)
        {
            var endpoint = BuildBallotServiceEndpoint(ballotId);
            var ballotRecords = await httpClient.GetAsync(endpoint);
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var ballotData = await ballotRecords.Content.ReadFromJsonAsync<List<Ballot>>(jsonSerializerOptions);
            return ballotData ?? new List<Ballot>();
        }

        private string? BuildBallotServiceEndpoint(string ballotId)
        {
            var ballotServiceProtocol = _transactionConfig.BallotDataProtocol;
            var ballotServiceHost = _transactionConfig.BallotDataHost;
            var ballotServicePort = _transactionConfig.BallotDataPort;
            return $"{ballotServiceProtocol}://{ballotServiceHost}:{ballotServicePort}/ballot/{ballotId}";
        }

        private async Task<List<BallotStatus>> FetchBallotStatusData(HttpClient httpClient, string Id)
        {
            var endpoint = BuildBallotStatusServiceEndpoint(Id);
            var ballotStatusRecords = await httpClient.GetAsync(endpoint);
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var ballotStatusData = await ballotStatusRecords.Content.ReadFromJsonAsync<List<BallotStatus>>(jsonSerializerOptions);
            return ballotStatusData ?? new List<BallotStatus>();
        }

        private string? BuildBallotStatusServiceEndpoint(string Id)
        {
            var ballotServiceProtocol = _transactionConfig.BallotDataProtocol;
            var ballotServiceHost = _transactionConfig.BallotDataHost;
            var ballotServicePort = _transactionConfig.BallotDataPort;
            return $"{ballotServiceProtocol}://{ballotServiceHost}:{ballotServicePort}/ballotStatus/{Id}";
        }

        private async Task<List<Booth>> FetchBoothData(HttpClient httpClient, string boothId)
        {
            var endpoint = BuildEventServiceEndpoint(boothId);
            var boothRecords = await httpClient.GetAsync(endpoint);
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var boothData = await boothRecords.Content.ReadFromJsonAsync<List<Booth>>(jsonSerializerOptions);
            return boothData ?? new List<Booth>();
        }

        private string? BuildEventServiceEndpoint(string boothId)
        {
            var eventServiceProtocol = _transactionConfig.EventDataProtocol;
            var eventServiceHost = _transactionConfig.EventDataHost;
            var eventServicePort = _transactionConfig.EventDataPort;
            return $"{eventServiceProtocol}://{eventServiceHost}:{eventServicePort}/event/{boothId}";
        }
    }
}
