﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace View.Login
{
    /// <summary>
    /// Interaction logic for LogInWindow_Start_.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        RegistrationPage RegistrationPage = new RegistrationPage();
        public LogInWindow()
        {
            InitializeComponent();
        }

        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            RegistrationPage.
            Close();

        }
    }
