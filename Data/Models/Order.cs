using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int ID { get; set; }

        [Display(Name ="Введите имя")]
        [StringLength(10)]
        [Required(ErrorMessage ="Заполните колонку с имнем")]
        public string _name { get; set; }

        [Display(Name = "Введите фамилию")]
        [StringLength(10)]
        [Required(ErrorMessage = "Заполните колонку с фамилией")]
        public string _surname { get; set; }

        [Display(Name = "Введите адресс")]
        [StringLength(20)]
        [Required(ErrorMessage = "Заполните колонку с адресом")]
        public string _address { get; set; }

        [Display(Name = "Укажите Ваш телефонный номер")]
        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Заполните колонку с номером телефона")]
        public string _phoneNumber { get; set; }

        [Display(Name = "Введите email адрес")]
        [StringLength(20)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Заполните колонку с email адресом")]
        public string _email { get; set; }

        [BindNever]
        public bool _shipped { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime _orderTime { get; set; } //время когда сделал заказ

        
        public List<OrderDetail> _orderDetails { get; set; } // описывает те товары, что мы преобретаем
    }
}
