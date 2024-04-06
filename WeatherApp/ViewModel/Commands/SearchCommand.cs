using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeatherApp.ViewModel.Commands;
public class SearchCommand : ICommand
{

    public WeatherVM VM { get; set; }

    //when PropertyChanged event execute it will leteveryone using those properties that props are changed
    public event EventHandler? CanExecuteChanged
    {
        //add and remove value to event 
        add { CommandManager.RequerySuggested += value; }
        remove {  CommandManager.RequerySuggested -= value;}
    }

    public SearchCommand(WeatherVM vm)
    {
        VM = vm;
    }

    public bool CanExecute(object? parameter)
    {
        string query = parameter as string;

        //ako nema query - nije nista uneseno u polje - return false
        if (string.IsNullOrWhiteSpace(query))
        {
            return false;
        }
        return true;
    }

    //for calling method in VM
    public void Execute(object? parameter)
    {
        VM.MakeQuery();
    }
}
