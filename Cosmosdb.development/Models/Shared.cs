using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

namespace Cosmosdb.development.Models
{
	public static class Shared
	{
		public static CosmosClient Client { get; set; }

		static Shared()
		{
			var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

			var endpoint = config["CosmosEndPoint"];
			var masterKey = config["MasterKey"];

			Client = new CosmosClient(endpoint, masterKey);
		}
	}
}
