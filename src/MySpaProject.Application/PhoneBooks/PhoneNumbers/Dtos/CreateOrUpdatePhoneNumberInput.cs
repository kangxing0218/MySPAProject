using System.ComponentModel.DataAnnotations;

namespace MySpaProject.PhoneBook.PhoneBooks.PhoneNumbers.Dtos
{
    public class CreateOrUpdatePhoneNumberInput
{
////BCC/ BEGIN CUSTOM CODE SECTION
////ECC/ END CUSTOM CODE SECTION
        [Required]
        public PhoneNumberEditDto PhoneNumber { get; set; }

}
}