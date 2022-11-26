using System;

namespace DTO
{
    public class UserDTO
    {
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public byte[] Passsword { get; set; }
        public Guid Salt { get; set; }
        public string Keyword { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        
        public override string ToString()
        {
            return $"{UserID,-3}*\t{FirstName,-10}*\t{LastName,-10}*\t{Email,-15}* {PhoneNumber,-15} * {RowInsertTime} * {RowUpdateTime}";
        }
    }
}
Footer
© 2022 GitHub, Inc.
