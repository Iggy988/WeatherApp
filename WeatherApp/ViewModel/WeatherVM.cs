using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;

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
            OnPropertyChanged(nameof(Query));
        }
    }

    private CurrentConditions _currentConditions;

    public CurrentConditions CurrentConditions
    {
        get { return _currentConditions; }
        set 
        {
            _currentConditions = value;
            OnPropertyChanged(nameof(CurrentConditions));
        }
    }

    private City _selectedCity;

    public City SelectedCity
    {
        get { return _selectedCity; }
        set 
        { 
            _selectedCity = value;
            OnPropertyChanged("SelectedCity");
        }
    }

    public WeatherVM()
    {
        //if this is true it means that we are not currently running app - we are in design mode
        // necde se prikazati podaci kad pokrenemo app, ali ce se prikazati u design modu
        if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
        {
            SelectedCity = new City
            {
                LocalizedName = "Belgrade"
            };

            CurrentConditions = new CurrentConditions
            {
                WeatherText = "Partly cloudy",
                Temperature = new Temperature
                {
                    Metric = new Units
                    {
                        Value = 21
                    }
                }
            };
        }
       
    }


    public event PropertyChangedEventHandler? PropertyChanged;

    //name of property that we changing
    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
