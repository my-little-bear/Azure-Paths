using System;
using StackExchange.Redis;

namespace RedisCaching
{
    class Program
    {
        static void Main(string[] args)
        {
            SaveData();
            ReadData();
        }

        public static async void SaveData()
        {
            int vehicleCount = 1000;
            Random random = new();
            var cache = RedisConnectionHelper.Connection.GetDatabase();
            for (int i = 1; i < vehicleCount; i++)
            {
                var speed = random.Next(0, 100);
                Console.WriteLine($"Vehicle-{i}");
                cache.StringSet($"Vehicle-{i}", speed, TimeSpan.FromMinutes(10));
            }
        }

        public static void ReadData()
        {
            var cache = RedisConnectionHelper.Connection.GetDatabase();
            var vehicleCount = 1000;
            for (int i = 1; i < vehicleCount; i++)
            {
                Console.WriteLine(cache.StringGet($"Vehicle-{i}"));
            }
        }
    }

    public class RedisConnectionHelper
    {
        static RedisConnectionHelper()
        {
            string connectionString = "mycaches.redis.cache.windows.net:6380,password=h0UmuYuqtETDQaf58Zsp3kJwtxBQTLsalAzCaHeHpS0=,ssl=True,abortConnect=False";
            ConfigurationOptions options = ConfigurationOptions.Parse(connectionString);
            options.ReconnectRetryPolicy = new ExponentialRetry(5000);
            options.ConnectTimeout = 15000;
            lazyConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(options));
        }
        private static Lazy<ConnectionMultiplexer> lazyConnection;

        public static ConnectionMultiplexer Connection { get => lazyConnection.Value; }
    }
}
