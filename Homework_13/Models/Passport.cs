﻿using Homework_13.Interfaces;
using System;

namespace Homework_13.Models
{
    /// <summary>
    /// Класс паспорт
    /// </summary>
    public class Passport : IPassport
    {
        /// <summary>
        /// Номер
        /// </summary>
        public long? Number { get; }
        
        /// <summary>
        /// Серия
        /// </summary>
        public long? Series { get; }

        /// <summary>
        /// Место выдачи
        /// </summary>
        public string PlaceOfIssue { get; }

        /// <summary>
        /// Дата выпуска
        /// </summary>
        public DateTime? DateOfIssue { get; }

        /// <summary>
        /// Код подразделения
        /// </summary>
        public IDivisionCode DivisionCode { get; }

        /// <summary>
        /// Владелец
        /// </summary>
        public IPerson Holder { get; }
        
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="series"> Серия </param>
        /// <param name="number"> Номер </param>
        /// <param name="placeOfIssue"> Место выдачи </param>
        /// <param name="dateOfIssue"> Дата выпуска </param>
        /// <param name="divisionCode"> Код подразделения </param>
        /// <param name="holder"> Владелец </param>
        public Passport(long? series,
                        long? number,
                        string placeOfIssue,
                        DateTime? dateOfIssue,
                        IDivisionCode divisionCode,
                        IPerson holder)
        {
            if(holder is null) 
                throw new ArgumentException("Владелец не может быть null!!!");
            if (divisionCode is null) 
                throw new ArgumentException("Код подразделения не может быть null!!!");
            if(string.IsNullOrWhiteSpace(placeOfIssue)) 
                throw new ArgumentException("Место выдачи не может быть null!!!");
            if(series <= 0 || number <= 0) 
                throw new ArgumentException("Номера не могут быть нулями или отрицательными!!!");
            
            Series = series;
            Number = number;
            PlaceOfIssue = placeOfIssue;
            DateOfIssue = dateOfIssue;
            DivisionCode = divisionCode;
            Holder = holder;
        }

        /// <summary>
        /// Изменить место жительства (прописка)
        /// </summary>
        /// <param name="newPlaceOfResidence"> Новое место жительства (прописка) </param>
        public void EditPlaceOfResidence(IAddress newPlaceOfResidence)
        {
            if(newPlaceOfResidence is null) 
                throw new ArgumentException("Новый адрес не может быть null!!!");
            Holder.PlaceOfResidence = newPlaceOfResidence;
        }

        /// <summary>
        /// Изменить место регистрации
        /// </summary>
        /// <param name="newPlaceOfRegistration"> Новое место регистрации </param>
        public void EditPlaceOfRegistration(IAddress newPlaceOfRegistration)
        {
            if(newPlaceOfRegistration is null) 
                throw new ArgumentException("Новый адрес не может быть null!!!");
            Holder.PlaceOfRegistration = newPlaceOfRegistration;
        }        
    }
}
