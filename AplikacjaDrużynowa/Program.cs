using RestSharp;
using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Lab4;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Linq;
using System.Text.Json;

namespace AplikacjaDrużynowa
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int _year = 2019;
            using var db = new Kontekst();
            db.Database.EnsureCreated();
            //var druzyny = await Website.Download("https://api.collegefootballdata.com", $"/teams/fbs?year={_year}");
            // var json = druzyny.Content;
            //var wynik1 = JsonConvert.DeserializeObject<Teams>(json);
            var client = new RestClient("https://api.collegefootballdata.com");
            var teamsRequest = new RestRequest($"/teams/fbs?year={_year}", Method.GET);
            var response = await client.ExecuteAsync(teamsRequest);
            var content = response.Content;

            var teams = System.Text.Json.JsonSerializer.Deserialize<Teams[]>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            var tasks = new List<Task<IRestResponse>>();

            foreach (var item in teams)
            {
                var coachRequest = new RestRequest($"/coaches?team={item.School}&year={_year}", Method.GET);
                tasks.Add(client.ExecuteAsync(coachRequest));
            }
            var responses = await Task.WhenAll(tasks);
            var coaches = responses.SelectMany(x => System.Text.Json.JsonSerializer.Deserialize<Coaches[]>(x.Content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }));
            foreach (var item in coaches)
            {
                teams.Single(x => x.School == item.Seasonss.First().School).Coachess.Add(item);
            }
            var addTasks = teams.Select(x => db.AddAsync(x).AsTask());
            await Task.WhenAll(addTasks);
            await db.SaveChangesAsync();
            //var trenerzy = await Website.Download("https://api.collegefootballdata.com", "/coaches");
            //var json2 = trenerzy.Content;
            //var wynik2 = JsonConvert.DeserializeObject<Coaches>(json);
            /* var db = new Kontekst();
             db.Database.EnsureCreated();
             db.Teamss.Add(new Teams(wynik1));
             db.Coachess.Add(new Coaches(wynik2));
             db.SaveChanges();*/

        }
    }
}
