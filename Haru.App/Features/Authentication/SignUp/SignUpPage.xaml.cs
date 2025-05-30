using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.DependencyInjection;

namespace Haru.App.Features.Authentication.SignUp; // Updated namespace

public partial class SignUpPage : ContentPage
{
    public SignUpPage()
    {
        InitializeComponent();
        BindingContext = Ioc.Default.GetRequiredService<SignUpViewModel>();
    }
}