using System.ComponentModel.DataAnnotations;

namespace MySpaProject.PhoneBook.PhoneBooks.Persons.Dtos
{
    public class PersonEditDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public int? Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [MaxLength(MySpaProjectConsts.MaxNameLength)]
        public string Name { get; set; }
        [MaxLength(MySpaProjectConsts.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }


        /// <summary>
        /// 地址信息
        /// </summary>
        [MaxLength(MySpaProjectConsts.MaxAddressLength)]
        public string Address { get; set; }
    }
}