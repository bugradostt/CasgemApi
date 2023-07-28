using System;

namespace CasgemApiConsume.Dtos.UserDtos
{
    public class GetByIdUserDto
    {
        public string _id { get; set; }

        public string UserName { get; set; }

        public string UserPassword { get; set; }
    }
}
