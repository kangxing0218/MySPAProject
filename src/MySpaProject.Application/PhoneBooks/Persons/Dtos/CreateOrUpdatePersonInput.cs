using System.ComponentModel.DataAnnotations;

namespace MySpaProject.PhoneBook.PhoneBooks.Persons.Dtos
{
    public class CreateOrUpdatePersonInput
{
        /// <summary>
        /// 用户创建
        /// </summary>
        [Required]
        public PersonEditDto Person { get; set; }

}
}