﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using MySpaProject.PhoneBook.PhoneBooks.Persons;

namespace MySpaProject.PhoneBook.PhoneBooks.PhoneNumbers
{
    /// <summary>
    /// 电话号码
    /// </summary>
    [Table("PhoneNumbers")]
    public class PhoneNumber : Entity<long>, IHasCreationTime
    {

        /// <summary>
        /// 电话号码
        /// </summary>
        [Required]
        [MaxLength(11)]
        public string Number { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public PhoneNumberType Type { get; set; }

        public int PersonId { get; set; }


        public Person Person { get; set; }



        public DateTime CreationTime { get; set; }
    }
}
