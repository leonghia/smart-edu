using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartEdu.DTOs.UserDTO;
using SmartEdu.Entities;
using SmartEdu.Models;
using SmartEdu.UnitOfWork;
 
namespace SmartEdu.Services.SeederService
{
    public class SeederService : ISeederService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SeederService(UserManager<User> userManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServerResponse<object>> SeedingData()
        {
            var serverResponse = new ServerResponse<object>();
            
            var count = await _userManager.Users.CountAsync();

            if (count > 0)
            {
                serverResponse.Succeeded = false;
                serverResponse.Message = "Data had been seeded before. No need to seed anymore.";
                return serverResponse;
            }

            var roles = new List<string> { "User" };

            var registerUserDTOs = new List<RegisterUserDTO>
            {

                // Teachers users
                new RegisterUserDTO
                {
                    FullName = "Nguyen Thi Giang",
                    UserName = "giang",
                    Email = "giang@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 1
                },              
                new RegisterUserDTO
                {
                    FullName = "Pham Thi Nguyet Anh",
                    UserName = "anhpham",
                    Email = "anh.pham@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 2
                },
                new RegisterUserDTO
                {
                    FullName = "Nguyen Dam Thuy Duong",
                    UserName = "duong",
                    Email = "duong@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 3
                },
                new RegisterUserDTO
                {
                    FullName = "Le Thi Thuy Ha",
                    UserName = "hale",
                    Email = "ha.le@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 1
                },
                new RegisterUserDTO
                {
                    FullName = "Nguyen Ngoc Hai",
                    UserName = "hain",
                    Email = "hai.n@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 1
                },
                new RegisterUserDTO
                {
                    FullName = "Nguyen Thi Hong Phuong",
                    UserName = "hphuong",
                    Email = "hphuong@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 1
                },
                new RegisterUserDTO
                {
                    FullName = "Luong Thi Hai Yen",
                    UserName = "hyen",
                    Email = "hyen@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 1
                },
                new RegisterUserDTO
                {
                    FullName = "Dam Thi Lan Anh",
                    UserName = "lananh",
                    Email = "lananh@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 1
                },
                new RegisterUserDTO
                {
                    FullName = "Nguyen Duc Manh",
                    UserName = "manhnguyenduc",
                    Email = "manh.nguyenduc@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 1
                },
                new RegisterUserDTO
                {
                    FullName = "Pham Thi Kim Oanh",
                    UserName = "oanhphamkim",
                    Email = "oanh.phamkim@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 1
                },
                new RegisterUserDTO
                {
                    FullName = "Phung Thi Kim Oanh",
                    UserName = "oanh",
                    Email = "oanh@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 1
                },
                new RegisterUserDTO
                {
                    FullName = "Do Thi Thuy Trang",
                    UserName = "trangdo",
                    Email = "trang.do@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 1
                },
                new RegisterUserDTO
                {
                    FullName = "Ngo Thi Thu Trang",
                    UserName = "trangngo",
                    Email = "trang.ngo@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 1
                },
                new RegisterUserDTO
                {
                    FullName = "Nguyen Ba Tuan",
                    UserName = "tuan",
                    Email = "tuan@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 1
                },
                new RegisterUserDTO
                {
                    FullName = "Do Thi Anh Van",
                    UserName = "van",
                    Email = "van@c3chuvanan.edu",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 1
                },
                new RegisterUserDTO
                {
                    FullName = "Trinh Duy Tien",
                    UserName = "tien",
                    Email = "tien@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 1
                },
                new RegisterUserDTO
                {
                    FullName = "Dang Thi Dinh",
                    UserName = "dinh",
                    Email = "dinh@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 2
                },
                new RegisterUserDTO
                {
                    FullName = "Phan Hong Hanh",
                    UserName = "hanhphanhong",
                    Email = "hanh.phanhong@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 2
                },
                new RegisterUserDTO
                {
                    FullName = "Tran Thi Thu Hien",
                    UserName = "hientran",
                    Email = "hien.tran@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 2
                },
                new RegisterUserDTO
                {
                    FullName = "Phung Thi Thanh Huyen",
                    UserName = "huyenphung",
                    Email = "huyen.phung@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 2
                },
                new RegisterUserDTO
                {
                    FullName = "Pham Mai Huyen",
                    UserName = "huyen",
                    Email = "huyen@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 2
                },
                new RegisterUserDTO
                {
                    FullName = "Dao Thi Huong Lan",
                    UserName = "lanvan",
                    Email = "lanvan@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 2
                },
                new RegisterUserDTO
                {
                    FullName = "Pham Thi Thuy Linh",
                    UserName = "linhpham",
                    Email = "linh.pham@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles= roles,
                    Type = 3,
                    SubjectId = 2
                },
                new RegisterUserDTO
                {
                    FullName = "Le Thi Thanh Loan",
                    UserName = "loan",
                    Email = "loan@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 2
                },
                new RegisterUserDTO
                {
                    FullName = "Nguyen Thi Thanh Mai",
                    UserName = "mainguyen",
                    Email = "mai.nguyen@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 2
                },
                new RegisterUserDTO
                {
                    FullName = "Mai Thi Nguyet",
                    UserName = "nguyet",
                    Email = "nguyet@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 2
                },
                new RegisterUserDTO
                {
                    FullName = "Tran Thi Phuong",
                    UserName = "phuongtran",
                    Email = "phuong.tran@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 2
                },
                new RegisterUserDTO
                {
                    FullName = "Nguyen Thi Thanh Tam",
                    UserName = "tamh",
                    Email = "tamh@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 2
                },
                new RegisterUserDTO
                {
                    FullName = "Nguyen Thi Huong Thuy",
                    UserName = "thuy",
                    Email = "thuy@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 2
                },
                new RegisterUserDTO
                {
                    FullName = "Vu Van Thang",
                    UserName = "vuthang",
                    Email = "vuthang@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 2
                },
                new RegisterUserDTO
                {
                    FullName = "Giap Thi Hai Chi",
                    UserName = "gchi",
                    Email = "gchi@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 3
                },
                new RegisterUserDTO
                {
                    FullName = "Nguyen Thi Lien",
                    UserName = "lien",
                    Email = "lien@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 3
                },
                new RegisterUserDTO
                {
                    FullName = "Thai Thi Phuong Nga",
                    UserName = "nga",
                    Email = "nga@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 3
                },
                new RegisterUserDTO
                {
                    FullName = "Nguyen Le Hong Nhung",
                    UserName = "nhung",
                    Email = "nhung@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 3
                },
                new RegisterUserDTO
                {
                    FullName = "Nguyen Van Thao",
                    UserName = "thaonguyenvan",
                    Email = "thao.nguyenvan@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 3
                },
                new RegisterUserDTO
                {
                    FullName = "Nguyen Bao Tram",
                    UserName = "tram",
                    Email = "tram@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId= 3
                },
                new RegisterUserDTO
                {
                    FullName = "Mai Thi Thu Trang",
                    UserName = "trangmai",
                    Email = "trang.mai@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 3
                },
                new RegisterUserDTO
                {
                    FullName = "Nguyen Thi Mai Trang",
                    UserName = "trangnguyen",
                    Email = "trang.nguyen@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 3
                },
                new RegisterUserDTO
                {
                    FullName = "Trinh Thu Trang",
                    UserName = "trangtrinh",
                    Email = "trang.trinh@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 3
                },
                new RegisterUserDTO
                {
                    FullName = "Nong Thi Khanh Van",
                    UserName = "vannongkhanh",
                    Email = "van.nongkhanh@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 3
                },
                new RegisterUserDTO
                {
                    FullName = "Vu Dieu Linh",
                    UserName = "vudlinh",
                    Email = "vudlinh@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 3
                },
                new RegisterUserDTO
                {
                    FullName = "Pham Tuat Dat",
                    UserName = "dat",
                    Email = "dat@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 4
                },
                new RegisterUserDTO
                {
                    FullName = "Tran Thi Kieu Giang",
                    UserName = "giangly",
                    Email = "giangly@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 4
                },
                new RegisterUserDTO
                {
                    FullName = "Nguyen Thuy Hang",
                    UserName = "hang",
                    Email = "hang@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 4
                },
                new RegisterUserDTO
                {
                    FullName = "Trinh Thi Huong",
                    UserName = "huongtrinhthi",
                    Email = "huong.trinhthi@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 4
                },
                new RegisterUserDTO
                {
                    FullName = "Nguyen Thi Lan",
                    UserName = "lan",
                    Email = "lan@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 4
                },
                new RegisterUserDTO
                {
                    FullName = "Tran Thi Ngoan",
                    UserName = "ngoan",
                    Email = "ngoan@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 4
                },
                new RegisterUserDTO
                {
                    FullName = "Bui Thi Quynh Anh",
                    UserName = "quynhanh",
                    Email = "quynhanh@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 4
                },
                new RegisterUserDTO
                {
                    FullName = "Pham Ngoc Thang",
                    UserName = "thangpham",
                    Email = "thangpham@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 4
                },
                new RegisterUserDTO
                {
                    FullName = "Dao Tri Thuc",
                    UserName = "thuc",
                    Email = "thuc@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 4
                },
                new RegisterUserDTO
                {
                    FullName = "Tran Thanh Thuy",
                    UserName = "thuytranthanh",
                    Email = "thuy.tranthanh@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 4
                },
                new RegisterUserDTO
                {
                    FullName = "Nguyen Kim Chi",
                    UserName = "chi",
                    Email = "chi@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 5
                },
                new RegisterUserDTO
                {
                    FullName = "Nguyen Thi Hanh",
                    UserName = "hanh",
                    Email = "hanh@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 5
                },
                new RegisterUserDTO
                {
                    FullName = "Nguyen Thi Kim Hoa",
                    UserName = "hoa",
                    Email = "hoa@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 5
                },
                new RegisterUserDTO
                {
                    FullName = "Le Thi Thu Huong",
                    UserName = "huongle",
                    Email = "huong.le@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 5
                },
                new RegisterUserDTO
                {
                    FullName = "Phan Thi Phuong Khanh",
                    UserName = "khanh",
                    Email = "khanh@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 5
                },
                new RegisterUserDTO
                {
                    FullName = "Nguyen Van Kien",
                    UserName = "kien",
                    Email = "kien@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 5
                },
                new RegisterUserDTO
                {
                    FullName = "Vo Thi Hai Ly",
                    UserName = "ly",
                    Email = "ly@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 5
                },
                new RegisterUserDTO
                {
                    FullName = "Do Thi Ngoc Mai",
                    UserName = "maido",
                    Email = "mai.do@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 5
                },
                new RegisterUserDTO
                {
                    FullName = "Phan Huy Minh",
                    UserName = "minh",
                    Email = "minh@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 5
                },
                new RegisterUserDTO
                {
                    FullName = "Nguyen Thi Nhung",
                    UserName = "nguyennhung",
                    Email = "nguyennhung@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 5
                },
                new RegisterUserDTO
                {
                    FullName = "Trinh Kim Thu",
                    UserName = "thutrinh",
                    Email = "thu.trinh@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 5
                },
                new RegisterUserDTO
                {
                    FullName = "Dao Huu Toan",
                    UserName = "toan",
                    Email = "toan@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 5
                },
                new RegisterUserDTO
                {
                    FullName = "Nguyen Thi Thanh Binh",
                    UserName = "binhnguyen",
                    Email = "binh.nguyen@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 6
                },
                new RegisterUserDTO
                {
                    FullName = "Nguyen Thi Minh Ha",
                    UserName = "hanguyen",
                    Email = "ha.nguyen@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 6
                },
                new RegisterUserDTO
                {
                    FullName = "Vo Thi My Hanh",
                    UserName = "hanhvo",
                    Email = "hanh.vo@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 6
                },
                new RegisterUserDTO
                {
                    FullName = "Nguyen Thi Thu Ha",
                    UserName = "hasinh",
                    Email = "hasinh@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 6
                },
                new RegisterUserDTO
                {
                    FullName = "Nguyen Thi Thanh Huyen",
                    UserName = "huyennguyen",
                    Email = "huyen.nguyen@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 6
                },
                new RegisterUserDTO
                {
                    FullName = "Nguyen Thi Phuong Thanh",
                    UserName = "thanh",
                    Email = "thanh@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 6
                },
                new RegisterUserDTO
                {
                    FullName = "Pham Thi Hai Van",
                    UserName = "van",
                    Email = "van@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 6
                },
                new RegisterUserDTO
                {
                    FullName = "Nguyen Thi Thu Hien",
                    UserName = "hiennguyen",
                    Email = "hien.nguyen@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 7
                },
                new RegisterUserDTO
                {
                    FullName = "Nguyen Thi Hoan",
                    UserName = "hoan",
                    Email = "hoan@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles ,
                    Type = 3,
                    SubjectId = 7
                },
                new RegisterUserDTO
                {
                    FullName = "Hoang Thi Lan Huong",
                    UserName = "huonghoang",
                    Email = "huong.hoang@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 7
                },
                new RegisterUserDTO
                {
                    FullName = "Le Thi Mai Huong",
                    UserName = "huong",
                    Email = "huong@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 7
                },
                new RegisterUserDTO
                {
                    FullName = "Tran Thi Mai",
                    UserName = "mai",
                    Email = "mai@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 7
                },
                new RegisterUserDTO
                {
                    FullName = "Pham Thi Minh Quyen",
                    UserName = "quyen",
                    Email = "quyen@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 7
                },
                new RegisterUserDTO
                {
                    FullName = "Dinh Thi Gia",
                    UserName = "gia",
                    Email = "gia@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 8
                },
                new RegisterUserDTO
                {
                    FullName = "Nguyen Thi Tu Hong",
                    UserName = "hong",
                    Email = "hong@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 8
                },
                new RegisterUserDTO
                {
                    FullName = "Pham Thi Thu Huyen",
                    UserName = "huyenpham",
                    Email = "huyen.pham@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 8
                },
                new RegisterUserDTO
                {
                    FullName = "Ha Thi Lien",
                    UserName = "lienha",
                    Email = "lien.ha@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 8
                },
                new RegisterUserDTO
                {
                    FullName = "Hoang Thi Lien",
                    UserName = "lienhoangthi",
                    Email = "lien.hoangthi@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 8
                },
                new RegisterUserDTO
                {
                    FullName = "Do Thi Thanh Nga",
                    UserName = "ngado",
                    Email = "nga.do@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 8
                },
                // Admins users
                new RegisterUserDTO
                {
                    FullName = "Nguyen Thi Huong",
                    UserName = "huongadmin",
                    Email = "nguyenhuongg1104@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = new List<string> { "Admin" },
                    Type = 0
                },
                new RegisterUserDTO
                {
                    FullName = "Trinh Van Phuc",
                    UserName = "phucadmin",
                    Email = "phuctv1112004@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = new List<string> { "Admin" },
                    Type = 0
                },

                // Students users
                new RegisterUserDTO // 1
                {
                    FullName = "Leu Ngoc An",
                    UserName = "an04003228",
                    Email = "an04003228@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003228",
                    DateOfBirth = new DateTime(2008, 9, 21),
                    Roles = roles,
                    Type = 1,
                    ParentId = 1,
                    MainClassId = 1
                },
                new RegisterUserDTO // 2
                {
                    FullName = "Nguyen Ngoc Tram Anh",
                    UserName = "anh04003229",
                    Email = "anh04003229@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003229",
                    DateOfBirth = new DateTime(2008, 11, 27),
                    Roles = roles,
                    Type = 1,
                    ParentId = 2,
                    MainClassId = 1
                },
                new RegisterUserDTO // 3
                {
                    FullName = "Pham Viet Anh",
                    UserName = "anh04003230",
                    Email = "anh04003230@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003230",
                    DateOfBirth = new DateTime(2008, 12, 8),
                    Roles = roles,
                    Type = 1,
                    ParentId = 3,
                    MainClassId = 1
                },
                new RegisterUserDTO // 4
                {
                    FullName = "Bui Thi Quynh Anh",
                    UserName = "anh04003231",
                    Email = "anh04003231@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003231",
                    DateOfBirth = new DateTime(2008, 10, 15),
                    Roles = roles,
                    Type = 1,
                    ParentId = 4,
                    MainClassId = 1
                },
                new RegisterUserDTO // 5
                {
                    FullName = "Vu Duc Anh",
                    UserName = "anh04003232",
                    Email = "anhanh04003232@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003232",
                    DateOfBirth = new DateTime(2008, 3, 1),
                    Roles = roles,
                    Type = 1,
                    ParentId = 5,
                    MainClassId = 1
                },
                new RegisterUserDTO // 6
                {
                    FullName = "Nguyen Phung Linh Chi",
                    UserName = "chi04003233",
                    Email = "chi04003233@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003233",
                    DateOfBirth = new DateTime(2008, 12, 14),
                    Roles = roles,
                    Type = 1,
                    ParentId = 6,
                    MainClassId = 1
                },
                new RegisterUserDTO // 7
                {
                    FullName = "Duong My Dung",
                    UserName = "dung04003234",
                    Email = "dung04003234@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003234",
                    DateOfBirth = new DateTime(2008, 12, 5),
                    Roles = roles,
                    Type = 1,
                    ParentId = 7,
                    MainClassId = 1
                },
                new RegisterUserDTO // 8
                {
                    FullName = "Nguyen Manh Duy",
                    UserName = "duy04003235",
                    Email = "duy04003235@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003235",
                    DateOfBirth = new DateTime(2008, 8, 10),
                    Roles = roles,
                    Type = 1,
                    ParentId = 8,
                    MainClassId = 1
                },
                new RegisterUserDTO // 9
                {
                    FullName = "Pham Phuong Duy",
                    UserName = "duy04003236",
                    Email = "duy04003236@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003236",
                    DateOfBirth = new DateTime(2008, 11, 30),
                    Roles = roles,
                    Type = 1,
                    ParentId = 9,
                    MainClassId = 1
                },
                new RegisterUserDTO // 10
                {
                    FullName = "Nguyen Thuy Duong",
                    UserName = "duong04003237",
                    Email = "duong04003237@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003237",
                    DateOfBirth = new DateTime(2008, 1, 4),
                    Roles = roles,
                    Type = 1,
                    ParentId = 10,
                    MainClassId = 1
                },
                new RegisterUserDTO // 11
                {
                    FullName = "Luu Minh Hang",
                    UserName = "hang04003238",
                    Email = "hang04003238@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003238",
                    DateOfBirth = new DateTime(2008, 11, 24),
                    Roles = roles,
                    Type = 1,
                    ParentId = 11,
                    MainClassId = 1
                },
                new RegisterUserDTO // 12
                {
                    FullName = "Nguyen Huu Minh Hoang",
                    UserName = "hoang04003239",
                    Email = "hoang04003239@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003239",
                    DateOfBirth = new DateTime(2008, 5, 7),
                    Roles = roles,
                    Type = 1,
                    ParentId = 12,
                    MainClassId = 1
                },
                new RegisterUserDTO // 13
                {
                    FullName = "Nguyen Huy Hoang",
                    UserName = "hoang04003240",
                    Email = "hoang04003240@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003240",
                    DateOfBirth = new DateTime(2008, 11, 27),
                    Roles = roles,
                    Type = 1,
                    ParentId = 13,
                    MainClassId = 1
                },
                new RegisterUserDTO // 14
                {
                    FullName = "Nguyen Duc Huy",
                    UserName = "huy04003241",
                    Email = "huy04003241@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003241",
                    DateOfBirth = new DateTime(2008, 2, 2),
                    Roles = roles,
                    Type = 1,
                    ParentId = 14,
                    MainClassId = 1
                },
                new RegisterUserDTO // 15
                {
                    FullName = "Vu Duc Huy",
                    UserName = "huy04003242",
                    Email = "huy04003242@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003242",
                    DateOfBirth = new DateTime(2008, 3, 7),
                    Roles = roles,
                    Type = 1,
                    ParentId = 15,
                    MainClassId = 1
                },
                new RegisterUserDTO // 16
                {
                    FullName = "Nguyen Trung Kien",
                    UserName = "kien04003243",
                    Email = "kien04003243@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003243",
                    DateOfBirth = new DateTime(2008, 7, 12),
                    Roles = roles,
                    Type = 1,
                    ParentId = 16,
                    MainClassId = 1
                },
                new RegisterUserDTO // 17
                {
                    FullName = "Le Duy Khiem",
                    UserName = "khiem04003244",
                    Email = "khiem04003244@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003244",
                    DateOfBirth = new DateTime(2008, 8, 5),
                    Roles = roles,
                    Type = 1,
                    ParentId = 17,
                    MainClassId = 1
                },
                new RegisterUserDTO // 18
                {
                    FullName = "Nguyen Minh Khue",
                    UserName = "khue04003245",
                    Email = "khue04003245@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003245",
                    DateOfBirth = new DateTime(2008, 12, 9),
                    Roles = roles,
                    Type = 1,
                    ParentId = 18,
                    MainClassId = 1
                },
                new RegisterUserDTO //19
                {
                    FullName = "Bui Hai Lam",
                    UserName = "lam04002587",
                    Email = "lam04002587@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.002587",
                    DateOfBirth = new DateTime(2008, 8, 11),
                    Roles = roles,
                    Type = 1,
                    ParentId = 19,
                    MainClassId = 1
                },
                new RegisterUserDTO //20
                {
                    FullName = "Nguyen Ha Gia Linh",
                    UserName = "linh04002588",
                    Email = "linh04002588@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.002588",
                    DateOfBirth = new DateTime(2008, 12, 5),
                    Roles = roles,
                    Type = 1,
                    ParentId = 20,
                    MainClassId = 1
                },
                new RegisterUserDTO //21
                {
                    FullName = "Nguyen Phuc Loc",
                    UserName = "loc04002590",
                    Email = "loc04002590@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.002590",
                    DateOfBirth = new DateTime(2008, 6, 26),
                    Roles = roles,
                    Type = 1,
                    ParentId = 21,
                    MainClassId = 1
                },
                new RegisterUserDTO //22
                {
                    FullName = "Hoang Huong Ly",
                    UserName = "ly04002591",
                    Email = "ly04002591@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.002591",
                    DateOfBirth = new DateTime(2008, 1, 10),
                    Roles = roles,
                    Type = 1,
                    ParentId = 22,
                    MainClassId = 1
                },
                new RegisterUserDTO //23
                {
                    FullName = "Trinh Xuan Minh",
                    UserName = "minh04002589",
                    Email = "minh04002589@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.002589",
                    DateOfBirth = new DateTime(2008, 2, 25),
                    Roles = roles,
                    Type = 1,
                    ParentId = 23,
                    MainClassId = 1
                },
                new RegisterUserDTO //24
                {
                    FullName = "Nguyen Vu Tien Nam",
                    UserName = "nam04002592",
                    Email = "nam04002592@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.002592",
                    DateOfBirth = new DateTime(2008, 12, 1),
                    Roles = roles,
                    Type = 1,
                    ParentId = 24,
                    MainClassId = 1
                },
                new RegisterUserDTO //25
                {
                    FullName = "Pham Thi Hang Nga",
                    UserName = "nga04002593",
                    Email = "nga04002593@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.002593",
                    DateOfBirth = new DateTime(2008, 7, 6),
                    Roles = roles,
                    Type = 1,
                    ParentId = 25,
                    MainClassId = 1
                },
                new RegisterUserDTO //26
                {
                    FullName = "Hoang Kim Ngan",
                    UserName = "ngan04002594",
                    Email = "ngan04002594@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.002594",
                    DateOfBirth = new DateTime(2008, 1, 31),
                    Roles = roles,
                    Type = 1,
                    ParentId = 26,
                    MainClassId = 1
                },
                new RegisterUserDTO //27
                {
                    FullName = "Hoang Yen Nhi",
                    UserName = "nhi04002595",
                    Email = "nhi04002595@gmail.com",
                    Identifier = "STU04.002595",
                    DateOfBirth = new DateTime(2008, 1, 20),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 27,
                    MainClassId = 1
                },
                new RegisterUserDTO //28
                {
                    FullName = "Mai Ngo Thien Phu",
                    UserName = "phu04002596",
                    Email = "phu04002596@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.002596",
                    DateOfBirth = new DateTime(2008, 9, 10),
                    Roles = roles,
                    Type = 1,
                    ParentId = 28,
                    MainClassId = 1
                },
                new RegisterUserDTO //29
                {
                    FullName = "Le Tien Tam",
                    UserName = "tam04002597",
                    Email = "tam04002597@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.002597",
                    DateOfBirth = new DateTime(2008, 7, 11),
                    Roles = roles,
                    Type = 1,
                    ParentId = 29,
                    MainClassId = 1
                },
                new RegisterUserDTO //30
                {
                    FullName = "Tran Xuan Toan",
                    UserName = "toan04002599",
                    Email = "toan04002599@gmail.com",
                    Identifier = "STU04.002599",
                    DateOfBirth = new DateTime(2008, 11, 10),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 30,
                    MainClassId = 1
                },
                new RegisterUserDTO //31
                {
                    FullName = "Le Minh Tuan",
                    UserName = "tuan04002598",
                    Email = "tuan04002598@gmail.com",
                    Identifier = "STU04.002598",
                    DateOfBirth = new DateTime(2008, 2, 13),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 31,
                    MainClassId = 1
                },
                new RegisterUserDTO //32
                {
                    FullName = "Duong Tat Thanh",
                    UserName = "thanh04002603",
                    Email = "thanh04002603@gmail.com",
                    Identifier = "STU04.002603",
                    DateOfBirth = new DateTime(2008, 8, 1),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 32,
                    MainClassId = 1
                },
                new RegisterUserDTO //33
                {
                    FullName = "Le Cao Thang",
                    UserName = "thang04002602",
                    Email = "thang04002602@gmail.com",
                    Identifier = "STU04.002602",
                    DateOfBirth = new DateTime(2008, 1, 3),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 33,
                    MainClassId = 1
                },
                new RegisterUserDTO //34
                {
                    FullName = "Dang Phuong Thuy",
                    UserName = "thuy04002601",
                    Email = "thuy04002601@gmail.com",
                    Identifier = "STU04.002601",
                    DateOfBirth = new DateTime(2008, 12, 31),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 34,
                    MainClassId = 1
                },
                new RegisterUserDTO //35
                {
                    FullName = "Nguyen Thu Trang",
                    UserName = "trang04002600",
                    Email = "trang0134100853@gmail.com",
                    Identifier = "STU04002600",
                    DateOfBirth = new DateTime(2008, 3, 30),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 35,
                    MainClassId = 1
                },
                new RegisterUserDTO //36
                {
                    FullName = "Nguyen Thuy Trang",
                    UserName = "trang04002608",
                    Email = "trang04002608@gmail.com",
                    Identifier = "STU04.002608",
                    DateOfBirth = new DateTime(2008, 10, 22),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 36,
                    MainClassId = 1
                },
                new RegisterUserDTO //37
                {
                    FullName = "Le Dinh Phong",
                    UserName = "phong04002605",
                    Email = "phong04002605@gmail.com",
                    Identifier = "STU04.002605",
                    DateOfBirth = new DateTime(2008, 6, 6),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 37,
                    MainClassId = 1
                },
                new RegisterUserDTO //38
                {
                    FullName = "Bui Ta Phuong",
                    UserName = "phuong04002604",
                    Email = "phuong04002604@gmail.com",
                    Identifier = "STU04.002604",
                    DateOfBirth = new DateTime(2008, 9, 22),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 38,
                    MainClassId = 1
                },
                new RegisterUserDTO //39
                {
                    FullName = "Nguyen Van Thanh",
                    UserName = "thanh04002607",
                    Email = "thanh04002607@gmail.com",
                    Identifier = "STU04.002607",
                    DateOfBirth = new DateTime(2008, 8, 14),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 39,
                    MainClassId = 1
                },
                new RegisterUserDTO //40
                {
                    FullName = "Nguyen Ngoc Tuyen",
                    UserName = "tuyen04002606",
                    Email = "thanh04002606@gmail.com",
                    Identifier = "STU04.002606",
                    DateOfBirth = new DateTime(2008, 12, 18),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 40,
                    MainClassId = 1
                },
                new RegisterUserDTO //41
                {
                    FullName = "Dao Tuan Anh",
                    UserName = "anh04002610",
                    Email = "anh04002610@gmail.com",
                    Identifier = "STU04.002610",
                    DateOfBirth = new DateTime(2008, 10, 14),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 41,
                    MainClassId = 2
                },
                new RegisterUserDTO //42
                {
                    FullName = "Dang Ngoc Chieu",
                    UserName = "chieu04002609",
                    Email = "chieu04002609@gmail.com",
                    Identifier = "STU04.002609",
                    DateOfBirth = new DateTime(2008, 12, 7),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 42,
                    MainClassId = 2
                },
                new RegisterUserDTO //43
                {
                    FullName = "Tran Tien Dung",
                    UserName = "dung04002616",
                    Email = "dung04002616@gmail.com",
                    Identifier = "STU04.002616",
                    DateOfBirth = new DateTime(2008, 3, 27),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 43,
                    MainClassId = 2
                },
                new RegisterUserDTO //44
                {
                    FullName = "Tran Minh Duong",
                    UserName = "duong04002615",
                    Email = "duong04002615@gmail.com",
                    Identifier = "STU04.002615",
                    DateOfBirth = new DateTime(2008, 9, 23),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 44,
                    MainClassId = 2
                },
                new RegisterUserDTO //45
                {
                    FullName = "Nguyen Minh Hieu",
                    UserName = "hieu04002614",
                    Email = "hieu04002614@gmail.com",
                    Identifier = "STU04.002614",
                    DateOfBirth = new DateTime(2008, 10, 14),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 45,
                    MainClassId = 2
                },
                new RegisterUserDTO //46
                {
                    FullName = "Le Van Oai",
                    UserName = "oai04002612",
                    Email = "oai04002612@gmail.com",
                    Identifier = "STU04.002612",
                    DateOfBirth = new DateTime(2008, 10, 3),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 46,
                    MainClassId = 2
                },
                new RegisterUserDTO //47
                {
                    FullName = "Le Ngoc Quang",
                    UserName = "quang04002611",
                    Email = "quang04002611@gmail.com",
                    Identifier = "STU04.002611",
                    DateOfBirth = new DateTime(2008, 11, 29),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 47,
                    MainClassId = 2
                },
                new RegisterUserDTO //48
                {
                    FullName = "Nguyen Khac Tho",
                    UserName = "tho04002613",
                    Email = "tho04002613@gmail.com",
                    Identifier = "STU04.002613",
                    DateOfBirth = new DateTime(2008, 9, 5),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 48,
                    MainClassId = 2
                },
                new RegisterUserDTO //49
                {
                    FullName = "Pham Quang Dai",
                    UserName = "dai04002620",
                    Email = "dai04002620@gmail.com",
                    Identifier = "STU04.002620",
                    DateOfBirth = new DateTime(2008, 6, 2),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 49,
                    MainClassId = 2
                },
                new RegisterUserDTO //50
                {
                    FullName = "Nguyen Van Hung",
                    UserName = "hung04002618",
                    Email = "hung04002618@gmail.com",
                    Identifier = "STU04.002618",
                    DateOfBirth = new DateTime(2008, 11, 4),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 50,
                    MainClassId = 2
                },
                new RegisterUserDTO //81
                {
                    FullName = "Nguyen Quang Tu",
                    UserName = "tu04002648",
                    Email = "tu04002648@gmail.com",
                    Identifier = "STU04.002648",
                    DateOfBirth = new DateTime(2008, 4, 16),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 81,
                    MainClassId = 3
                },
                new RegisterUserDTO //82
                {
                    FullName = "Nguyen Dai Thang",
                    UserName = "thang04002650",
                    Email = "thang04002650@gmail.com",
                    Identifier = "STU04.002650",
                    DateOfBirth = new DateTime(2008, 10, 20),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 82,
                    MainClassId = 3
                },
                new RegisterUserDTO //83
                {
                    FullName = "Nguyen Van Tien",
                    UserName = "tien04002651",
                    Email = "tien04002651@gmail.com",
                    Identifier = "STU04.002651",
                    DateOfBirth = new DateTime(2008, 2, 5),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 83,
                    MainClassId = 3
                },
                new RegisterUserDTO //84
                {
                    FullName = "Tran Viet Cuong",
                    UserName = "cuong04002653",
                    Email = "cuong04002653@gmail.com",
                    Identifier = "STU04.002653",
                    DateOfBirth = new DateTime(2008, 7, 26),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 84,
                    MainClassId = 3
                },
                new RegisterUserDTO //85
                {
                    FullName = "Hoang Tran Hao",
                    UserName = "hao04002652",
                    Email = "hao04002652@gmail.com",
                    Identifier = "STU04.002652",
                    DateOfBirth = new DateTime(2008, 6, 1),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 85,
                    MainClassId = 3
                },
                new RegisterUserDTO //86
                {
                    FullName = "Le Van Dac",
                    UserName = "dac04002655",
                    Email = "dac04002655@gmail.com",
                    Identifier = "STU04.002655",
                    DateOfBirth = new DateTime(2008, 11, 7),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 86,
                    MainClassId = 3
                },
                new RegisterUserDTO //87
                {
                    FullName = "Nguyen Minh Hiep",
                    UserName = "hiep04002657",
                    Email = "hiep04002657@gmail.com",
                    Identifier = "STU04.002657",
                    DateOfBirth = new DateTime(2008, 8, 9),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 87,
                    MainClassId = 3
                },
                new RegisterUserDTO //88
                {
                    FullName = "Le Van Hieu",
                    UserName = "hieu04002656",
                    Email = "hieu04002656@gmail.com",
                    Identifier = "STU04.002656",
                    DateOfBirth = new DateTime(2008, 7, 17),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 88,
                    MainClassId = 3
                },
                new RegisterUserDTO //89
                {
                    FullName = "Dang Le Hoang",
                    UserName = "hoang04002654",
                    Email = "hoang04002654@gmail.com",
                    Identifier = "STU04.002654",
                    DateOfBirth = new DateTime(2008, 7, 21),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 89,
                    MainClassId = 3
                },
                new RegisterUserDTO //90
                {
                    FullName = "Dinh Cong Don",
                    UserName = "don04002658",
                    Email = "don04002658@gmail.com",
                    Identifier = "STU04.002658",
                    DateOfBirth = new DateTime(2008, 3, 27),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 90,
                    MainClassId = 3
                },
                new RegisterUserDTO //91
                {
                    FullName = "Le Thi Van Anh",
                    UserName = "anh04002659",
                    Email = "anh04002659@gmail.com",
                    Identifier = "STU04.002659",
                    DateOfBirth = new DateTime(2008, 5, 15),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 91,
                    MainClassId = 3
                },
                new RegisterUserDTO //92
                {
                    FullName = "Nguyen Van Quan",
                    UserName = "quan04002662",
                    Email = "quan04002662@gmail.com",
                    Identifier = "STU04.002662",
                    DateOfBirth = new DateTime(2008, 12, 17),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 92,
                    MainClassId = 3
                },
                new RegisterUserDTO //93
                {
                    FullName = "Luong Anh Quang",
                    UserName = "quang04002660",
                    Email = "quang04002660@gmail.com",
                    Identifier = "STU04.002660",
                    DateOfBirth = new DateTime(2008, 10, 19),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 93,
                    MainClassId = 3
                },
                new RegisterUserDTO //94
                {
                    FullName = "Phan Van Thanh",
                    UserName = "thanh04002663",
                    Email = "thanh04002663@gmail.com",
                    Identifier = "STU04.002663",
                    DateOfBirth = new DateTime(2008, 5, 9),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 94,
                    MainClassId = 3
                },
                new RegisterUserDTO //95
                {
                    FullName = "Nguyen Minh Thanh",
                    UserName = "thanh04002661",
                    Email = "thanh04002661@gmail.com",
                    Identifier = "STU04.002661",
                    DateOfBirth = new DateTime(2008, 5, 9),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 95,
                    MainClassId = 3
                },
                new RegisterUserDTO //96
                {
                    FullName = "Vu Van Cao",
                    UserName = "cao04002667",
                    Email = "cao04002667@gmail.com",
                    Identifier = "STU04.002667",
                    DateOfBirth = new DateTime(2008, 11, 2),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 96,
                    MainClassId = 3
                },
                new RegisterUserDTO //97
                {
                    FullName = "Le Xuan Huynh",
                    UserName = "huynh04002665",
                    Email = "huynh04002665@gmail.com",
                    Identifier = "STU04.002665",
                    DateOfBirth = new DateTime(2008, 12, 22),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 97,
                    MainClassId = 3
                },
                new RegisterUserDTO //98
                {
                    FullName = "Dang Quang Loc",
                    UserName = "loc04002664",
                    Email = "loc04002664@gmail.com",
                    Identifier = "STU04.002664",
                    DateOfBirth = new DateTime(2008, 6, 12),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 98,
                    MainClassId = 3
                },
                new RegisterUserDTO //99
                {
                    FullName = "Nguyen Thi Thanh Nga",
                    UserName = "nga04002666",
                    Email = "nga04002666@gmail.com",
                    Identifier = "STU04.002666",
                    DateOfBirth = new DateTime(2008, 10, 18),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 99,
                    MainClassId = 3
                },
                new RegisterUserDTO //100
                {
                    FullName = "Nguyen Thi Van Anh",
                    UserName = "anh04002669",
                    Email = "anh04002669@gmail.com",
                    Identifier = "STU04.002669",
                    DateOfBirth = new DateTime(2008, 11, 20),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 100,
                    MainClassId = 3
                },
                new RegisterUserDTO //101
                {
                    FullName = "Pham Hoang Hung",
                    UserName = "hung04002670",
                    Email = "hung04002670@gmail.com",
                    Identifier = "STU04.002670",
                    DateOfBirth = new DateTime(2008, 9, 20),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 101,
                    MainClassId = 3
                },
                new RegisterUserDTO //102
                {
                    FullName = "Duong Van Thang",
                    UserName = "thang04002668",
                    Email = "thang04002668@gmail.com",
                    Identifier = "STU04.002668",
                    DateOfBirth = new DateTime(2008, 5, 7),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 102,
                    MainClassId = 3
                },
                new RegisterUserDTO //103
                {
                    FullName = "Dang Van Ha",
                    UserName = "ha04002671",
                    Email = "ha04002671@gmail.com",
                    Identifier = "STU04.002671",
                    DateOfBirth = new DateTime(2008, 1, 15),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 103,
                    MainClassId = 3
                },
                new RegisterUserDTO //104
                {
                    FullName = "Nguyen Trung Hieu",
                    UserName = "hieu04002677",
                    Email = "hieu04002677@gmail.com",
                    Identifier = "STU04.002677",
                    DateOfBirth = new DateTime(2008, 4, 6),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 104,
                    MainClassId = 3
                },
                new RegisterUserDTO //105
                {
                    FullName = "Nguyen Huy Hoang",
                    UserName = "hoang04002673",
                    Email = "hoang04002673@gmail.com",
                    Identifier = "STU04.002673",
                    DateOfBirth = new DateTime(2008, 12, 24),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 105,
                    MainClassId = 3
                },
                new RegisterUserDTO //106
                {
                    FullName = "Tran Tuan Hung",
                    UserName = "hung04002679",
                    Email = "hung04002679@gmail.com",
                    Identifier = "STU04.002679",
                    DateOfBirth = new DateTime(2008, 12, 30),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 106,
                    MainClassId = 3
                },
                new RegisterUserDTO //107
                {
                    FullName = "Nguyen Ngoc Phuong Huy",
                    UserName = "huy04002674",
                    Email = "huy04002674@gmail.com",
                    Identifier = "STU04.002674",
                    DateOfBirth = new DateTime(2008, 11, 6),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 107,
                    MainClassId = 3
                },
                new RegisterUserDTO //108
                {
                    FullName = "Le Thi Thu HUyen",
                    UserName = "huyen04002672",
                    Email = "huyen04002672@gmail.com",
                    Identifier = "STU04.002672",
                    DateOfBirth = new DateTime(2008, 7, 11),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 108,
                    MainClassId = 3
                },
                new RegisterUserDTO //109
                {
                    FullName = "Nguyen Thi Quynh",
                    UserName = "quynh04002676",
                    Email = "quynh04002676@gmail.com",
                    Identifier = "STU04.002676",
                    DateOfBirth = new DateTime(2008, 3, 8),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 109,
                    MainClassId = 3
                },
                new RegisterUserDTO //110
                {
                    FullName = "Nguyen Van Thang",
                    UserName = "thang04002678",
                    Email = "thang04002678@gmail.com",
                    Identifier = "STU04.002678",
                    DateOfBirth = new DateTime(2008, 10, 12),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 110,
                    MainClassId = 3
                },
                new RegisterUserDTO //111
                {
                    FullName = "Nguyen Thanh Tung",
                    UserName = "tung04002675",
                    Email = "tung04002675@gmail.com",
                    Identifier = "STU04.002675",
                    DateOfBirth = new DateTime(2008, 10, 25),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 111,
                    MainClassId = 3
                },
                new RegisterUserDTO //112
                {
                    FullName = "Le Thang Canh",
                    UserName = "canh04002682",
                    Email = "canh04002682@gmail.com",
                    Identifier = "STU04.002682",
                    DateOfBirth = new DateTime(2008, 7, 31),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 112,
                    MainClassId = 3
                },
                new RegisterUserDTO //113
                {
                    FullName = "Le Dinnh Giang",
                    UserName = "giang04002681",
                    Email = "giang04002681@gmail.com",
                    Identifier = "STU04.002681",
                    DateOfBirth = new DateTime(2008, 3, 25),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 113,
                    MainClassId = 3
                },
                new RegisterUserDTO //114
                {
                    FullName = "Hoang Ngoc Ha",
                    UserName = "ha04002680",
                    Email = "ha04002680@gmail.com",
                    Identifier = "STU04.002680",
                    DateOfBirth = new DateTime(2008, 6, 14),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 114,
                    MainClassId = 3
                },
                new RegisterUserDTO //115
                {
                    FullName = "Nguyen Ba Huy",
                    UserName = "huy04002685 ",
                    Email = "huy04002685@gmail.com",
                    Identifier = "STU04.002685 ",
                    DateOfBirth = new DateTime(2008, 12, 28),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 115,
                    MainClassId = 3
                },
                new RegisterUserDTO //116
                {
                    FullName = "Nguyen Huu Linh",
                    UserName = "linh04002687",
                    Email = "linh04002687@gmail.com",
                    Identifier = "STU04.002687",
                    DateOfBirth = new DateTime(2008, 12, 12),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 116,
                    MainClassId = 3
                },
                new RegisterUserDTO //117
                {
                    FullName = "Nguyen Thi Ly",
                    UserName = "ly04002689",
                    Email = "ly04002689@gmail.com",
                    Identifier = "STU04.002689",
                    DateOfBirth = new DateTime(2008, 4, 22),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 117,
                    MainClassId = 3
                },
                new RegisterUserDTO //118
                {
                    FullName = "Nguyen Hong Nhung",
                    UserName = "nhung04002686",
                    Email = "nhung04002686@gmail.com",
                    Identifier = "STU04.002686",
                    DateOfBirth = new DateTime(2008, 5, 6),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 118,
                    MainClassId = 3
                },
                new RegisterUserDTO //119
                {
                    FullName = "Luu Thi Quynh",
                    UserName = "quynh04002683",
                    Email = "quynh04002683@gmail.com",
                    Identifier = "STU04.002683",
                    DateOfBirth = new DateTime(2008, 6, 10),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 119,
                    MainClassId = 3
                },
                new RegisterUserDTO //120
                {
                    FullName = "Pham Van Truong",
                    UserName = "truong04002690",
                    Email = "truong04002690@gmail.com",
                    Identifier = "STU04.002690",
                    DateOfBirth = new DateTime(2008, 5, 20),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 120,
                    MainClassId = 3
                },

                // Parents
                new RegisterUserDTO // 1
                {
                    FullName = "Leu Minh Duc",
                    UserName = "duc0149107377",
                    Email = "duc0149107377@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO // 2
                {
                    FullName = "Nguyen Ngoc Bao",
                    UserName = "bao0116701758",
                    Email = "bao0116701758@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO // 3
                {
                    FullName = "Pham Viet Hung",
                    UserName = "hung0133530105",
                    Email = "hung0133530105@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO // 4
                {
                    FullName = "Bui Thi Quynh Mai",
                    UserName = "mai3616460199",
                    Email = "mai3616460199@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO // 5
                {
                    FullName = "Vu Tuan Minh ",
                    UserName = "minh1734705112",
                    Email = "minh1734705112@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO // 6
                {
                    FullName = "Nguyen The Toan",
                    UserName = "toan0149107460",
                    Email = "toan0149107460@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO // 7
                {
                    FullName = "Duong My Hanh",
                    UserName = "hanh0116989583",
                    Email = "hanh0116989583@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO // 8
                {
                    FullName = "Nguyen Manh Dung",
                    UserName = "dung0150499677",
                    Email = "dung0150499677@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO // 9
                {
                    FullName = "Pham Phuong Thuy",
                    UserName = "thuy0116479556",
                    Email = "thuy0116479556@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO // 10
                {
                    FullName = "Nguyen Thuy Dung",
                    UserName = "dung0133058338",
                    Email = "dung0133058338@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO // 11
                {
                    FullName = "Luu Thi Hong",
                    UserName = "hong0116971907",
                    Email = "hong0116971907@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO // 12
                {
                    FullName = "Nguyen Huu Minh",
                    UserName = "minh0116952467",
                    Email = "minh0116952467@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO // 13
                {
                    FullName = "Nguyen Huy Long",
                    UserName = "long0149107469",
                    Email = "long0149107469@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO // 14
                {
                    FullName = "Nguyen Duc Toan",
                    UserName = "toan0116575041",
                    Email = "toan0116575041@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO // 15
                {
                    FullName = "Vu Duc Dam",
                    UserName = "dam0116701214",
                    Email = "dam0116701214@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO // 16
                {
                    FullName = "Nguyen Trung Thanh",
                    UserName = "thanh3316697828",
                    Email = "thanh3316697828@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO // 17
                {
                    FullName = "Le Duy Khanh",
                    UserName = "khanh0137566271",
                    Email = "khanh0137566271@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO // 18
                {
                    FullName = "Nguyen Minh Ngoc",
                    UserName = "ngoc0150707773",
                    Email = "ngoc0150707773@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //19
                {
                    FullName = "Bui Hai Luong",
                    UserName = "luong0134001874",
                    Email = "luong0134001874@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //20
                {
                    FullName = "Nguyen Gia Bao",
                    UserName = "bao0116973081",
                    Email = "bao0116973081@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //21
                {
                    FullName = "Nguyen Phuc Duc",
                    UserName = "duc0116574901",
                    Email = "duc0116574901@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //22
                {
                    FullName = "Hoang Huong Nhung",
                    UserName = "nhung0150498659",
                    Email = "nhung0150498659@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //23
                {
                    FullName = "Trinh Xuan Thanh",
                    UserName = "thanh0155210714",
                    Email = "thanh0155210714@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //24
                {
                    FullName = "Nguyen Vu Tien",
                    UserName = "tien0116695176",
                    Email = "tien0116695176@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //25
                {
                    FullName = "Pham Thi Hang",
                    UserName = "hang0134705129",
                    Email = "hang0134705129@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //26
                {
                    FullName = "Hoang Kim Trang",
                    UserName = "trang0133530178",
                    Email = "trang0133530178@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //27
                {
                    FullName = "Hoang Thi Men",
                    UserName = "men0134705133",
                    Email = "men0134705133@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //28
                {
                    FullName = "Mai Thien Hoang",
                    UserName = "hoang0134705135",
                    Email = "hoang0134705135@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //29
                {
                    FullName = "Le Tien Tuan",
                    UserName = "tuan0100712147",
                    Email = "tuan0100712147@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //30
                {
                    FullName = "Tran Xuan Linh",
                    UserName = "linh0133487571",
                    Email = "linh0133487571@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },new RegisterUserDTO //31
                {
                    FullName = "Le Minh Quan",
                    UserName = "quan0133530254",
                    Email = "quan0133530254@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //32
                {
                    FullName = "Duong Tat Phuc",
                    UserName = "phuc0134100841",
                    Email = "phuc0134100841@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //33
                {
                    FullName = "Le Cao Duc",
                    UserName = "duc0155203520",
                    Email = "duc0155203520@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //34
                {
                    FullName = "Dang Phuong Linh",
                    UserName = "linh0144525596",
                    Email = "linh0144525596@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //35
                {
                    FullName = "Nguyen Le Thu",
                    UserName = "thu0134100853",
                    Email = "thu0134100853@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //36
                {
                    FullName = "Nguyen  Thi Thuy",
                    UserName = "thuy0134100856",
                    Email = "thuy0134100856@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
            };

            foreach (var registerUserDTO in registerUserDTOs)
            {
                var user = _mapper.Map<User>(registerUserDTO);

                await _userManager.CreateAsync(user,
                    registerUserDTO.Password);
                await _userManager.AddToRolesAsync(user,
                    roles);
            }

            await SeedingUsers(registerUserDTOs);
            await SeedingTeachers(registerUserDTOs);
            await SeedingMainClasses();
            await SeedingExtraClasses();
            await SeedingParents(registerUserDTOs);
            await SeedingStudents(registerUserDTOs);

            serverResponse.Message = "Seeding data successfully.";
            return serverResponse;
        }

        public async Task SeedingTeachers(List<RegisterUserDTO> registerUserDTOs)
        {                 
            var teachers = new List<Teacher>();

            foreach (var registerUserDTO in registerUserDTOs)
            {
                if (registerUserDTO.Type == 3 && registerUserDTO.SubjectId > 0)
                {
                    var user = await _userManager.FindByNameAsync(registerUserDTO.UserName);
                    var teacher = new Teacher
                    {
                        UserId = user.Id,                      
                        SubjectId = registerUserDTO.SubjectId
                    };
                    teachers.Add(teacher);
                }
            }

            await _unitOfWork.TeacherRepository.AddRange(teachers);
            await _unitOfWork.Save();
        }

        public async Task SeedingStudents(List<RegisterUserDTO> registerUserDTOs)
        {           
            var students = new List<Student>();

            foreach (var registerUserDTO in registerUserDTOs)
            {
                if (registerUserDTO.Type == 1 && registerUserDTO.ParentId > 0 && registerUserDTO.MainClassId > 0)
                {
                    var user = await _userManager.FindByNameAsync(registerUserDTO.UserName);
                    var student = new Student
                    {
                        UserId = user.Id,
                        ParentId = registerUserDTO.ParentId,
                        MainClassId = registerUserDTO.MainClassId,
                        Identifier = registerUserDTO.Identifier
                    };
                    students.Add(student);
                }
            }

            await _unitOfWork.StudentRepository.AddRange(students);
            await _unitOfWork.Save();
        }

        public async Task SeedingParents(List<RegisterUserDTO> registerUserDTOs)
        {
            var parents = new List<Parent>();

            foreach (var registerUserDTO in registerUserDTOs)
            {
                if (registerUserDTO.Type == 2)
                {
                    var user = await _userManager.FindByNameAsync(registerUserDTO.UserName);
                    var parent = new Parent
                    {
                        UserId = user.Id
                    };
                    parents.Add(parent);
                }
            }

            await _unitOfWork.ParentRepository.AddRange(parents);
            await _unitOfWork.Save();
        }

        public async Task SeedingUsers(List<RegisterUserDTO> registerUserDTOs)
        {
            foreach (var registerUserDTO in registerUserDTOs)
            {
                var user = _mapper.Map<User>(registerUserDTO);
                await _userManager.CreateAsync(user, registerUserDTO.Password);
                await _userManager.AddToRolesAsync(user, registerUserDTO.Roles);
            }
        }

        public async Task SeedingMainClasses()
        {
            var mainClasses = new List<MainClass>
            {
                new MainClass
                {
                    Name = "10A",
                    TeacherId = 1
                },
                new MainClass
                {
                    Name = "10B",
                    TeacherId = 2,
                },
                new MainClass
                {
                    Name = "10C",
                    TeacherId = 3
                }
            };
            await _unitOfWork.MainClassRepository.AddRange(mainClasses);
            await _unitOfWork.Save();
        }

        public async Task SeedingExtraClasses()
        {
            var extraClasses = new List<ExtraClass>
            {
                new ExtraClass
                {
                    Name = "Maths M2208-10",
                    SubjectId = 1,
                    TeacherId = 1
                },
                new ExtraClass
                {
                    Name = "Literature A2208-10",
                    SubjectId = 2,
                    TeacherId = 2
                },
                new ExtraClass
                {
                    Name = "English M2208-10",
                    SubjectId = 3,
                    TeacherId = 3
                }
            };

            await _unitOfWork.ExtraClassRepository.AddRange(extraClasses);
            await _unitOfWork.Save();
        }
    }
}
