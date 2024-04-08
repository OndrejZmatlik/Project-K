﻿using Project_K.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Project_K.Services
{
    public static class GetRozvrh
    {
        public static ObservableCollection<Models.Cell> Rozvrh { get; private set; } = new ObservableCollection<Models.Cell>();
        static GetRozvrh()
        {
            RefreshRozvrh();
        }
        public static void RefreshRozvrh()
        {
            try
            {
                Rozvrh.Clear();
                var storage = SecureStorage.GetAsync("Id").Result;
                int id = Convert.ToInt32(storage);
                DateTime date = DateTime.Now;
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                    return;
                HttpClient client = new HttpClient();
                var data = new { userid = id.ToString(), dateTime = date };
                var dataJson = JsonSerializer.Serialize(data);
                var response = client.PostAsync("https://sis.ssakhk.cz/api/v1/getTimeTableByUserId", new StringContent(dataJson, System.Text.Encoding.UTF8, "application/json")).Result;
                if (!response.IsSuccessStatusCode) return;
                var responseString = response.Content.ReadAsStringAsync().Result;
                var dataJson2 = JsonSerializer.Deserialize<DataJson>(responseString);
                if (dataJson2 == null) return;
                Device.BeginInvokeOnMainThread(() =>
                {
                    Rozvrh.Clear();
                    foreach (var cell in dataJson2.Cells.OrderBy(cell => cell.StartTime))
                    {
                        Rozvrh.Add(cell);
                    }
                });

            }
            catch (Exception)
            {

                return;
            }

        }
    }
}
