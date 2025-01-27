﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;
using WeatherApp.ViewModel.Commands;
using WeatherApp.ViewModel.Helpers;

namespace WeatherApp.ViewModel;
public class WeatherVM : INotifyPropertyChanged
{

    private string query;

    public string Query
    {
        get { return query; }
        set 
        { 
            query = value;
            // calling event, that will update anyone who subscribes to it, leting them know this property "Query" has changed
            OnPropertyChanged("Query");
        }
    }

    public ObservableCollection<City> Cities { get; set; }

    private CurrentConditions _currentConditions;

    public CurrentConditions CurrentConditions
    {
        get { return _currentConditions; }
        set
        {
            _currentConditions = value;
            OnPropertyChanged("CurrentConditions");
        }
    }

  

    private City selectedCity;

    public City SelectedCity
    {
        get { return selectedCity; }
        set
        {
            selectedCity = value;
            OnPropertyChanged("SelectedCity");
            GetCurrentConditions();
        }
    }

    public SearchCommand SearchCommand { get; set; }

    public WeatherVM()
    {
        //if this is true it means that we are not currently running app - we are in design mode
        // necde se prikazati podaci kad pokrenemo app, ali ce se prikazati u design modu
        if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
        {
            SelectedCity = new City
            {
                LocalizedName = "New York"
            };
            CurrentConditions = new CurrentConditions
            {
                WeatherText = "Partly cloudy",
                Temperature = new Temperature
                {
                    Metric = new Units
                    {
                        Value = "21"
                    }
                }
            };
        }

        SearchCommand = new SearchCommand(this); //this -instance of current class

        Cities = new ObservableCollection<City>();
       
    }

    //this method will be executed every time whem SelectedCity changes
    private async void GetCurrentConditions()
    {
        // when city is selected, clear box, and collection
        Query = string.Empty;
        Cities.Clear();
        CurrentConditions = await AccuWeatherHelper.GetCurrentConditions(SelectedCity.Key);
    }

    public async void MakeQuery()
    {
        var cities = await AccuWeatherHelper.GetCities(Query);
        // first to ensure, that every time we call GetCities method, Cities collection is cleared
        Cities.Clear();
        foreach (var city in cities)
        {
            Cities.Add(city);
        }
    }


    public event PropertyChangedEventHandler? PropertyChanged;

    //name of property that we changing
    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
