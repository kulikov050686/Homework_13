using System.Windows.Controls;
using System.ComponentModel;
using System.Windows;
using System.Collections.Generic;
using System;
using Homework_13.Enums;

namespace Homework_13.UserControls
{
    public partial class PersonUserControl : UserControl
    {
        #region Название

        public static readonly DependencyProperty TitleUCProperty =
            DependencyProperty.Register(nameof(TitleUC),
                                        typeof(string),
                                        typeof(PersonUserControl),
                                        new PropertyMetadata(default(string)));

        [Description("Название")]
        public string TitleUC
        {
            get => (string)GetValue(TitleUCProperty);
            set => SetValue(TitleUCProperty, value);
        }

        #endregion

        #region Имя

        public static readonly DependencyProperty NameUCProperty =
            DependencyProperty.Register(nameof(NameUC),
                                        typeof(string),
                                        typeof(PersonUserControl),
                                        new PropertyMetadata(default(string)));

        [Description("Имя")]
        public string NameUC
        {
            get => (string)GetValue(NameUCProperty);
            set => SetValue(NameUCProperty, value);
        }

        #endregion

        #region Фамилия

        public static readonly DependencyProperty SurnameUCProperty =
            DependencyProperty.Register(nameof(SurnameUC),
                                        typeof(string),
                                        typeof(PersonUserControl),
                                        new PropertyMetadata(default(string)));

        [Description("Фамилия")]
        public string SurnameUC 
        {
            get => (string)GetValue(SurnameUCProperty);
            set => SetValue(SurnameUCProperty, value);
        }

        #endregion

        #region Отчество

        public static readonly DependencyProperty PatronymicUCProperty =
            DependencyProperty.Register(nameof(PatronymicUC),
                                        typeof(string),
                                        typeof(PersonUserControl),
                                        new PropertyMetadata(default(string)));

        [Description("Отчество")]
        public string PatronymicUC
        {
            get => (string)GetValue(PatronymicUCProperty);
            set => SetValue(PatronymicUCProperty, value);
        }

        #endregion

        #region Место рождения

        public static readonly DependencyProperty PlaceOfBirthUCProperty =
            DependencyProperty.Register(nameof(PlaceOfBirthUC),
                                        typeof(string),
                                        typeof(PersonUserControl),
                                        new PropertyMetadata(default(string)));

        [Description("Место рождения")]
        public string PlaceOfBirthUC
        {
            get => (string)GetValue(PlaceOfBirthUCProperty);
            set => SetValue(PlaceOfBirthUCProperty, value);
        }

        #endregion

        #region Список полов

        [Description("Список полов")]
        public List<string> GenderListUC { get; set; } = new List<string> { "муж", "жен" };

        #endregion

        #region Выбранный пол

        public static readonly DependencyProperty GenderUCProperty =
            DependencyProperty.Register(nameof(GenderUC),
                                        typeof(Gender),
                                        typeof(PersonUserControl),
                                        new PropertyMetadata(default(Gender)));

        [Description("Выбранный пол")]
        public Gender GenderUC
        {
            get => (Gender)GetValue(GenderUCProperty);
            set => SetValue(GenderUCProperty, value);
        }

        #endregion

        #region Дата рождения

        public static readonly DependencyProperty DateOfBirthrUCProperty =
            DependencyProperty.Register(nameof(DateOfBirthrUC),
                                        typeof(DateTime?),
                                        typeof(PersonUserControl),
                                        new PropertyMetadata(default(DateTime?)));

        [Description("Дата рождения")]
        public DateTime? DateOfBirthrUC
        {
            get => (DateTime?)GetValue(DateOfBirthrUCProperty);
            set => SetValue(DateOfBirthrUCProperty, value);
        }

        #endregion

        public PersonUserControl() => InitializeComponent();        
    }
}
