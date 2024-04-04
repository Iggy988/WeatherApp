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




    public event PropertyChangedEventHandler? PropertyChanged;

    //name of property that we changing
    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
