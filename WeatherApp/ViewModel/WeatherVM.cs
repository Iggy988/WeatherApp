using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    public event PropertyChangedEventHandler? PropertyChanged;

    //name of property that we changing
    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
