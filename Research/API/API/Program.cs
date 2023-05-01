namespace API
{
    public class Pokemon
    {
        public Ability[] abilities { get; set; }
        public class Ability
        {
            public Description ability { get; set; }
            public bool is_hidden { get; set; }
            public int slot { get; set; }
        }
        public class Description
        {
            public string name { get; set; }
            public string url { get; set; }
        }
        public int base_experience { get; set; }
        public Description[] forms { get; set; }
    }
  
     
    public class ResponseTest
    {
        public Dictionary<string, string> args { get; set; }
        public string data { get; set; }
        public Dictionary<string, string> headers { get; set; }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            /*try
            {
                /*
                HttpClient client = new();
                var response = client.GetAsync("https://pokeapi.co/api/v2/pokemon/charmander")
                                        .GetAwaiter()
                                        .GetResult();

                string content = response.Content.ReadAsStringAsync()
                                                    .GetAwaiter()
                                                    .GetResult();

                var pokemon = JsonSerializer.Deserialize<Pokemon>(content);*/
            /*
            StringContent requestBody = new("{}", Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();

            var response = client.PostAsync("https://httpbin.org/post?key=value", requestBody)
                                    .GetAwaiter()
                                    .GetResult();

            string content = response.Content.ReadAsStringAsync()
                                                .GetAwaiter()
                                                .GetResult();

                var resp = JsonSerializer.Deserialize<ResponseTest>(content);
            }
            catch
            {
                throw new Exception();
            }*/

            test();

        }
    



        struct Poligono
        {

        }


        static void test()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0};
            
            var t = DateTime.UtcNow;
            for (int i = 0; i < 2000000; i++)
            {
                var l = new List<int>(); 
                foreach(int n in arr)
                {
                    if (n % 2 == 0)
                        l.Add(n);
                }
            }
            Console.WriteLine("Tiempo en filtrar pares con foreach: " + (DateTime.UtcNow - t));

            t = DateTime.UtcNow;
            for (int i = 0; i < 2000000; i++)
            {
                var l = new List<int>();
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[j] % 2 == 0)
                        l.Add(arr[j]);
                }
            }
            Console.WriteLine("Tiempo en filtrar pares con for: " + (DateTime.UtcNow - t));
            
            t = DateTime.UtcNow;
            for (int i = 0; i < 2000000; i++)
            {
                var l = from n in arr
                         where n % 2 == 0
                         select n;
            }
            Console.WriteLine("Tiempo en filtrar pares con select: " + (DateTime.UtcNow - t));

            t = DateTime.UtcNow;
            for (int i = 0; i < 2000000; i++)
            {
                var l = arr.Where(n => n % 2 == 0);
            }
            Console.WriteLine("Tiempo en filtrar pares con where: " + (DateTime.UtcNow - t));
        }
    }
}