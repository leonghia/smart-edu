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
                    UserName = "an0149107377",
                    Email = "an0149107377@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 1,
                    MainClassId = 1
                },
                new RegisterUserDTO // 2
                {
                    FullName = "Nguyen Ngoc Tram Anh",
                    UserName = "anh0116701758",
                    Email = "anh0116701758@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 2,
                    MainClassId = 1
                },
                new RegisterUserDTO // 3
                {
                    FullName = "Pham Viet Anh",
                    UserName = "anh0133530105",
                    Email = "anh0133530105@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 3,
                    MainClassId = 1
                },
                new RegisterUserDTO // 4
                {
                    FullName = "Bui Thi Quynh Anh",
                    UserName = "anh3616460199",
                    Email = "anh3616460199@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 4,
                    MainClassId = 1
                },
                new RegisterUserDTO // 5
                {
                    FullName = "Vu Duc Anh",
                    UserName = "anh1734705112",
                    Email = "anh1734705112@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 5,
                    MainClassId = 1
                },
                new RegisterUserDTO // 6
                {
                    FullName = "Nguyen Phung Linh Chi",
                    UserName = "chi0149107460",
                    Email = "chi0149107460@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 6,
                    MainClassId = 1
                },
                new RegisterUserDTO // 7
                {
                    FullName = "Duong My Dung",
                    UserName = "dung0116989583",
                    Email = "dung0116989583@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 7,
                    MainClassId = 1
                },
                new RegisterUserDTO // 8
                {
                    FullName = "Nguyen Manh Duy",
                    UserName = "duy0150499677",
                    Email = "duy0150499677@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 8,
                    MainClassId = 1
                },
                new RegisterUserDTO // 9
                {
                    FullName = "Pham Phuong Duy",
                    UserName = "duy0116479556",
                    Email = "duy0116479556@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 9,
                    MainClassId = 1
                },
                new RegisterUserDTO // 10
                {
                    FullName = "Nguyen Thuy Duong",
                    UserName = "duong0133058338",
                    Email = "duong0133058338@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 10,
                    MainClassId = 1
                },
                new RegisterUserDTO // 11
                {
                    FullName = "Luu Minh Hang",
                    UserName = "hang0116971907",
                    Email = "hang0116971907@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 11,
                    MainClassId = 1
                },
                new RegisterUserDTO // 12
                {
                    FullName = "Nguyen Huu Minh Hoang",
                    UserName = "hoang0116952467",
                    Email = "hoang0116952467@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 12,
                    MainClassId = 1
                },
                new RegisterUserDTO // 13
                {
                    FullName = "Nguyen Huy Hoang",
                    UserName = "hoang0149107469",
                    Email = "hoang0149107469@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 13,
                    MainClassId = 1
                },
                new RegisterUserDTO // 14
                {
                    FullName = "Nguyen Duc Huy",
                    UserName = "huy0116575041",
                    Email = "huy0116575041@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 14,
                    MainClassId = 1
                },
                new RegisterUserDTO // 15
                {
                    FullName = "Vu Duc Huy",
                    UserName = "huy0116701214",
                    Email = "huy0116701214@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 15,
                    MainClassId = 1
                },
                new RegisterUserDTO // 16
                {
                    FullName = "Nguyen Trung Kien",
                    UserName = "kien3316697828",
                    Email = "kien3316697828@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 16,
                    MainClassId = 1
                },
                new RegisterUserDTO // 17
                {
                    FullName = "Le Duy Khiem",
                    UserName = "khiem0137566271",
                    Email = "khiem0137566271@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 17,
                    MainClassId = 1
                },
                new RegisterUserDTO // 18
                {
                    FullName = "Nguyen Minh Khue",
                    UserName = "khue0150707773",
                    Email = "khue0150707773@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 18,
                    MainClassId = 1
                },
                new RegisterUserDTO //19
                {
                    FullName = "Bui Hai Lam",
                    UserName = "lam0134001874",
                    Email = "lam0134001874@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 19,
                    MainClassId = 1
                },
                new RegisterUserDTO //20
                {
                    FullName = "Nguyen Ha Gia Linh",
                    UserName = "linh0116973081",
                    Email = "linh0116973081@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 20,
                    MainClassId = 1
                },
                new RegisterUserDTO //21
                {
                    FullName = "Nguyen Phuc Loc",
                    UserName = "loc0116574901",
                    Email = "loc0116574901@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 21,
                    MainClassId = 1
                },
                new RegisterUserDTO //22
                {
                    FullName = "Hoang Huong Ly",
                    UserName = "ly0150498659",
                    Email = "ly0150498659@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 22,
                    MainClassId = 1
                },
                new RegisterUserDTO //23
                {
                    FullName = "Trinh Xuan Minh",
                    UserName = "minh0155210714",
                    Email = "minh0155210714@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 23,
                    MainClassId = 1
                },
                new RegisterUserDTO //24
                {
                    FullName = "Nguyen Vu Tien Nam",
                    UserName = "nam0116695176",
                    Email = "nam0116695176@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 24,
                    MainClassId = 1
                },
                new RegisterUserDTO //25
                {
                    FullName = "Pham Thi Hang Nga",
                    UserName = "nga0134705129",
                    Email = "nga0134705129@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 25,
                    MainClassId = 1
                },
                new RegisterUserDTO //26
                {
                    FullName = "Hoang Kim Ngan",
                    UserName = "ngan0133530178",
                    Email = "ngan0133530178@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 26,
                    MainClassId = 1
                },
                new RegisterUserDTO //27
                {
                    FullName = "Hoang Yen Nhi",
                    UserName = "nhi0134705133",
                    Email = "nhi0134705133@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 27,
                    MainClassId = 1
                },
                new RegisterUserDTO //28
                {
                    FullName = "Mai Ngo Thien Phu",
                    UserName = "phu0134705135",
                    Email = "phu0134705135@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 28,
                    MainClassId = 1
                },
                new RegisterUserDTO //29
                {
                    FullName = "Le Tien Tam",
                    UserName = "tam0100712147",
                    Email = "tam0100712147@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 29,
                    MainClassId = 1
                },
                new RegisterUserDTO //30
                {
                    FullName = "Tran Xuan Toan",
                    UserName = "toan0133487571",
                    Email = "toan0133487571@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 30,
                    MainClassId = 1
                },
                new RegisterUserDTO //31
                {
                    FullName = "Le Minh Tuan",
                    UserName = "tuan0133530254",
                    Email = "tuan0133530254@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 31,
                    MainClassId = 1
                },
                new RegisterUserDTO //32
                {
                    FullName = "Duong Tat Thanh",
                    UserName = "thanh0134100841",
                    Email = "thanh0134100841@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 32,
                    MainClassId = 1
                },
                new RegisterUserDTO //33
                {
                    FullName = "Le Cao Thang",
                    UserName = "thang0155203520",
                    Email = "thang0155203520@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 33,
                    MainClassId = 1
                },
                new RegisterUserDTO //34
                {
                    FullName = "Dang Phuong Thuy",
                    UserName = "thuy0144525596",
                    Email = "thuy0144525596@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 34,
                    MainClassId = 1
                },
                new RegisterUserDTO //35
                {
                    FullName = "Nguyen Thu Trang",
                    UserName = "trang0134100853",
                    Email = "trang0134100853@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 35,
                    MainClassId = 1
                },
                new RegisterUserDTO //36
                {
                    FullName = "Nguyen Thuy Trang",
                    UserName = "trang0134100856",
                    Email = "trang0134100856@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 36,
                    MainClassId = 1
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
                        MainClassId = registerUserDTO.MainClassId
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
