﻿using Project_K.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project_K.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UcitelPickerPage : ContentPage
    {
        public static string teacherRealName;
        public UcitelPickerPage()
        {
            this.Appearing += OnPageAppearing;
            InitializeComponent();
        }
        private void OnPageAppearing(object sender, EventArgs e)
        {
            ResetView();
        }
        private void ResetView()
        {
            PickerOfTeachers.IsVisible = true;
            AcceptButton.IsVisible = true;
            label1.IsVisible = true;
            TeacherView.IsVisible = false;
            TeacherView.IsEnabled = false;
            TeacherName.Text = null;
            TeacherName.IsVisible = false;
            TeacherView.ItemsSource = null;
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            var selectedItem = PickerOfTeachers.SelectedItem as string;
            if (selectedItem != null)
            {
                
                Dictionary<string, string> teachers = new Dictionary<string, string>
                {
                    { "Jan Lang", "LA" },
                    { "Richard Rejthar", "RE" },
                    { "Matěj Lang", "LN" },
                    { "Libor Beneš", "BE" },
                    { "Michaela Ducháčková", "DU" },
                    { "Milan Hloušek", "HS" },
                    { "Jaroslav Hývl", "HY" },
                    { "Zlata Karpíšková", "KR" },
                    { "Eva Kuntová", "KT" },
                    { "Roman Loskot", "LO" },
                    { "Jaroslav Maťátko", "MA" },
                    { "Martin Mercl", "MC" },
                    { "Štěpán Mach", "MH" },
                    { "Josef Matějus", "MJ" },
                    { "Martin Markoš", "MR" },
                    { "Ilona Mayerová", "MV" },
                    { "Jiří Petera", "PE" },
                    { "Miloslav Penc", "PN" },
                    { "Lucie Porter", "PO" },
                    { "David Podzimek", "PZ" },
                    { "Jana Radoňová", "RA" },
                    { "Igor Ročín", "RO" },
                    { "Jiří Špičan", "SP" },
                    { "Simona Trnková", "TK" },
                    { "Tomáš Záhořík", "TR" },
                    { "Pavel Trnka", "TZ" },
                    { "Josef Zelba", "ZE" },
                    { "Šárka Žemličková", "ZM" },
                    { "Shane Hertnon", "CI" },
                    { "Michal Janko", "JA" },
                    { "Tadeáš Němec", "NE" },
                    { "Michal Macinka", "MI" },

                };
                bool selection = teachers.TryGetValue(selectedItem, out teacherRealName);
                if (!selection)
                {
                    DisplayAlert("Něco je špatně", $"Nenašli jsme učitele, prosím kontaktujte vývojáře", "OK");
                    return;
                }
                string result = GetTeacher.TeacherRefresh();
                if(result!="good")
                {
                    if(result== "noteacherselected")
                    {
                        DisplayAlert("Varování", $"Teacher je null neco se stalo idk wtf pls posli mi to dik<3", "OK");
                    }
                    if(result== "ucitelneuci")
                    {
                    DisplayAlert("Varování", $"Učitel dneska neučí", "OK");

                    }
                    if (result == "nointernet")
                    {
                        DisplayAlert("Varování", $"Není připojení k internetu", "OK");

                    }
                    return;
                }
                PickerOfTeachers.IsVisible = false;
                AcceptButton.IsVisible = false;
                label1.IsVisible = false;
                TeacherView.IsVisible = true;
                TeacherView.IsEnabled= true;
                TeacherName.Text = selectedItem;
                TeacherName.IsVisible = true;
                TeacherView.ItemsSource = GetTeacher.Teacher;
            }
        }
    }
}

