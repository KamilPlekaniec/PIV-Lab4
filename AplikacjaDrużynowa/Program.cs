using RestSharp;
using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Lab4;
using Microsoft.EntityFrameworkCore;

namespace AplikacjaDrużynowa
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var druzyny = await Website.Download("https://api.collegefootballdata.com", "/teams/fbs");
            var json = druzyny.Content;
            var wynik1 = JsonConvert.DeserializeObject<Teams>(json);

            var trenerzy = await Website.Download("https://api.collegefootballdata.com", "/coaches");
            var json2 = trenerzy.Content;
            var wynik2 = JsonConvert.DeserializeObject<Coaches>(json);

           
            var db = new Kontekst();
            db.Database.EnsureCreated();
            db.Teamss.Add(new Teams(wynik1));
            db.Coachess.Add(new Coaches(wynik2));
            db.SaveChanges();



        }
    }
}
