using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EmployeeDetails.Models;

public partial class EmployeeDetail : INotifyPropertyChanged
{
    private string? id;
    private string? name;
    private string? age;
    private string? gender;
    private string? address;

    public string? Id { get => id; set { id = value; OnPropertyChanged(nameof(Id)); } }

    public string? Name { get => name; set { name = value; OnPropertyChanged(nameof(Name)); } }

    public string? Age { get => age; set { age = value; OnPropertyChanged(nameof(Age)); } }

    public string? Gender { get => gender; set { gender = value; OnPropertyChanged(nameof(Gender)); } }

    public string? Address { get => address; set { address = value; OnPropertyChanged(nameof(Address)); } }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
