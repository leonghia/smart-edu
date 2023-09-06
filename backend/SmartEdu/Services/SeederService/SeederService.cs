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
                new RegisterUserDTO //51
                {
                    FullName = "Vu Tuan Huy",
                    UserName = "huy04002621",
                    Email = "huy04002621@gmail.com",
                    Identifier = "STU04.002621",
                    DateOfBirth = new DateTime(2008, 4, 29),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 51,
                    MainClassId = 2
                },
                new RegisterUserDTO //52
                {
                    FullName = "Nguyen Van Quan",
                    UserName = "quan04002619 ",
                    Email = "quan04002619@gmail.com",
                    Identifier = "STU04.002619",
                    DateOfBirth = new DateTime(2008, 7, 22),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 52,
                    MainClassId = 2
                },
                new RegisterUserDTO //53
                {
                    FullName = "Can Van Thang",
                    UserName = "thang04002617  ",
                    Email = "thang04002617@gmail.com",
                    Identifier = "STU04.002617",
                    DateOfBirth = new DateTime(2008, 2, 12),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 53,
                    MainClassId = 2
                },
                new RegisterUserDTO //54
                {
                    FullName = "Nguyen Van Ban",
                    UserName = "ban04002627   ",
                    Email = "ban04002627@gmail.com",
                    Identifier = "STU04.002627",
                    DateOfBirth = new DateTime(2008, 3, 18),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 54,
                    MainClassId = 2
                },
                new RegisterUserDTO //55
                {
                    FullName = "Nguyen Van Ha",
                    UserName = "ha04002630",
                    Email = "ha04002630@gmail.com",
                    Identifier = "STU04.002630",
                    DateOfBirth = new DateTime(2008, 9, 8),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 55,
                    MainClassId = 2
                },
                new RegisterUserDTO //56
                {
                    FullName = "Nguyen Quang Huy",
                    UserName = "huy04002628",
                    Email = "huy04002628@gmail.com",
                    Identifier = "STU04.002628 ",
                    DateOfBirth = new DateTime(2008, 9, 20),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 56,
                    MainClassId = 2
                },
                new RegisterUserDTO //57
                {
                    FullName = "Doan Xuan Khang",
                    UserName = "khang04002624",
                    Email = "khang04002624@gmail.com",
                    Identifier = "STU04.002624",
                    DateOfBirth = new DateTime(2008, 4, 30),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 57,
                    MainClassId = 2
                },
                new RegisterUserDTO //58
                {
                    FullName = "Le Dinh Lam",
                    UserName = "lam04002626",
                    Email = "lam04002626@gmail.com",
                    Identifier = "STU04.002626",
                    DateOfBirth = new DateTime(2008, 11, 5),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 58,
                    MainClassId = 2
                },
                new RegisterUserDTO //59
                {
                    FullName = "Nguyen Tung Lam",
                    UserName = "lam04002629",
                    Email = "lam04002629@gmail.com",
                    Identifier = "STU04.002629",
                    DateOfBirth = new DateTime(2008, 10, 10),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 59,
                    MainClassId = 2
                },
                new RegisterUserDTO //60
                {
                    FullName = "Hoang Cong Quyet",
                    UserName = "quyet04002625",
                    Email = "quyet04002625@gmail.com",
                    Identifier = "STU04.002625",
                    DateOfBirth = new DateTime(2008, 09, 25),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 60,
                    MainClassId = 2
                },
                new RegisterUserDTO //61
                {
                    FullName = "Vu Truong Sinh",
                    UserName = "sinh04002632",
                    Email = "sinh04002632@gmail.com",
                    Identifier = "STU04.002632",
                    DateOfBirth = new DateTime(2008, 8, 4),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 61,
                    MainClassId = 2
                },
                new RegisterUserDTO //62
                {
                    FullName = "Dao Phuc Son",
                    UserName = "son04002622",
                    Email = "son04002622@gmail.com",
                    Identifier = "STU04.002622",
                    DateOfBirth = new DateTime(2008, 11, 16),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 62,
                    MainClassId = 2
                },
                new RegisterUserDTO //63
                {
                    FullName = "Doan Van Trieu",
                    UserName = "trieu04002623",
                    Email = "trieu04002623@gmail.com",
                    Identifier = "STU04.002623",
                    DateOfBirth = new DateTime(2008, 5, 12),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 63,
                    MainClassId = 2
                },
                new RegisterUserDTO //64
                {
                    FullName = "Nguyen Van Thai",
                    UserName = "thai04002623",
                    Email = "thai04002623@gmail.com",
                    Identifier = "STU04.002623",
                    DateOfBirth = new DateTime(2008, 6, 2),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 64,
                    MainClassId = 2
                },
                new RegisterUserDTO //65
                {
                    FullName = "Dang Van Anh",
                    UserName = "anh04002634",
                    Email = "anh04002634@gmail.com",
                    Identifier = "STU04.002634",
                    DateOfBirth = new DateTime(2008, 10, 5),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 65,
                    MainClassId = 2
                },
                new RegisterUserDTO //66
                {
                    FullName = "Dang Van Anh",
                    UserName = "anh04002639",
                    Email = "anh04002639@gmail.com",
                    Identifier = "STU04.002639",
                    DateOfBirth = new DateTime(2008, 10, 10),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 66,
                    MainClassId = 2
                },
                new RegisterUserDTO //67
                {
                    FullName = "Tran Trung Hieu",
                    UserName = "hieu04002638",
                    Email = "hieu04002638@gmail.com",
                    Identifier = "STU04.002638",
                    DateOfBirth = new DateTime(2008, 1, 24),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 67,
                    MainClassId = 2
                },
                new RegisterUserDTO //68
                {
                    FullName = "Nguyen Quang Hung",
                    UserName = "hung04002637",
                    Email = "hung04002637@gmail.com",
                    Identifier = "STU04.002637",
                    DateOfBirth = new DateTime(2008, 4, 24),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 68,
                    MainClassId = 2
                },
                new RegisterUserDTO //69
                {
                    FullName = "Ngo Duc Manh",
                    UserName = "manh04002635",
                    Email = "manh04002635@gmail.com",
                    Identifier = "STU04.002635",
                    DateOfBirth = new DateTime(2008, 9, 24),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 69,
                    MainClassId = 2
                },
                new RegisterUserDTO //70
                {
                    FullName = "Nguyen Duc Manh",
                    UserName = "manh04002636",
                    Email = "manh04002636@gmail.com",
                    Identifier = "STU04.002636",
                    DateOfBirth = new DateTime(2008, 8, 26),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 70,
                    MainClassId = 2
                },
                new RegisterUserDTO //71
                {
                    FullName = "Bui Van Tai",
                    UserName = "tai04002633",
                    Email = "tai04002633@gmail.com",
                    Identifier = "STU04.002633",
                    DateOfBirth = new DateTime(2008, 10, 31),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 71,
                    MainClassId = 2
                },
                new RegisterUserDTO //72
                {
                    FullName = "Nguyen Van Cong",
                    UserName = "cong04002640",
                    Email = "cong04002640@gmail.com",
                    Identifier = "STU04.002640",
                    DateOfBirth = new DateTime(2008, 5, 6),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 72,
                    MainClassId = 2
                },
                new RegisterUserDTO //73
                {
                    FullName = "Vu Trung Hieu",
                    UserName = "hieu04002643",
                    Email = "hieu04002643@gmail.com",
                    Identifier = "STU04.002643",
                    DateOfBirth = new DateTime(2008, 7, 5),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 73,
                    MainClassId = 2
                },
                new RegisterUserDTO //74
                {
                    FullName = "Vu Quanh Minh",
                    UserName = "minh04002642",
                    Email = "minh04002642@gmail.com",
                    Identifier = "STU04.002642",
                    DateOfBirth = new DateTime(2008, 12, 5),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 74,
                    MainClassId = 2
                },
                new RegisterUserDTO //75
                {
                    FullName = "Van Hai Nam",
                    UserName = "nam04002641",
                    Email = "nam04002641@gmail.com",
                    Identifier = "STU04.002641",
                    DateOfBirth = new DateTime(2008, 12, 17),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 75,
                    MainClassId = 2
                },
                new RegisterUserDTO //76
                {
                    FullName = "Van Van Tung",
                    UserName = "tung04002644",
                    Email = "tung04002644@gmail.com",
                    Identifier = "STU04.002644",
                    DateOfBirth = new DateTime(2008, 4, 28),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 76,
                    MainClassId = 2
                },
                new RegisterUserDTO //77
                {
                    FullName = "Lam Duc Dat",
                    UserName = "dat04002645",
                    Email = "dat04002645@gmail.com",
                    Identifier = "STU04.002645",
                    DateOfBirth = new DateTime(2008, 1, 26),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 77,
                    MainClassId = 2
                },
                new RegisterUserDTO //78
                {
                    FullName = "Lam Tuan Vu",
                    UserName = "vu04002646",
                    Email = "vu04002646@gmail.com",
                    Identifier = "STU04.002646",
                    DateOfBirth = new DateTime(2008, 8, 28),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 78,
                    MainClassId = 2
                },
                new RegisterUserDTO //79
                {
                    FullName = "Pham Ding Cuong",
                    UserName = "cuong04002647",
                    Email = "cuong04002647@gmail.com",
                    Identifier = "STU04.002647",
                    DateOfBirth = new DateTime(2008, 3, 19),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 79,
                    MainClassId = 2
                },
                new RegisterUserDTO //80
                {
                    FullName = "Phung Duc Long",
                    UserName = "long04002649",
                    Email = "long04002649@gmail.com",
                    Identifier = "STU04.002649",
                    DateOfBirth = new DateTime(2008, 9, 30),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 80,
                    MainClassId = 2
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
                    FullName = "Nguyen Thi Thuy",
                    UserName = "thuy0134100856",
                    Email = "thuy0134100856@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //37
                {
                    FullName = "Nguyen Thi Tu Quyen",
                    UserName = "quyen03000833",
                    Email = "quyen03000833@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //38
                {
                    FullName = "Nguyen Thi Nhu Quynh",
                    UserName = "quynh03000830",
                    Email = "quynh03000830@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //39
                {
                    FullName = "Vu Thanh Thuy",
                    UserName = "thuy03000839",
                    Email = "thuy03000839@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //40
                {
                    FullName = "Vu Thi Huyen Trang",
                    UserName = "trang03000840",
                    Email = "trang03000840@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //41
                {
                    FullName = "Pham Thi Thu Uyen",
                    UserName = "uyen03000836",
                    Email = "uyen03000836@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //42
                {
                    FullName = "Nguyen Hong Van",
                    UserName = "van03000825",
                    Email = "van03000825@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //43
                {
                    FullName = "Nguyen Thi Yen Anh",
                    UserName = "yen03000851",
                    Email = "yen03000851@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //44
                {
                    FullName = "Tran Thi Hai Anh",
                    UserName = "anh03000854",
                    Email = "hai03000854@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //45
                {
                    FullName = "Pham Kim Chi",
                    UserName = "chi03000852",
                    Email = "chi03000852@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //46
                {
                    FullName = "Nguyen Minh Hoang",
                    UserName = "hoang03000845",
                    Email = "hoang03000845@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //47
                {
                    FullName = "Nguyen Thi Truc Linh",
                    UserName = "linh03000850",
                    Email = "linh03000850@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //47
                {
                    FullName = "Vu My Linh",
                    UserName = "linh03000856",
                    Email = "linh03000856@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //48
                {
                    FullName = "Le Thi Bich Loan",
                    UserName = "loan03000842",
                    Email = "loan03000842@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //49
                {
                    FullName = "Nguyen Thi Minh Ly",
                    UserName = "ly03000847",
                    Email = "ly03000847@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //50
                {
                    FullName = "Ngo Tra My",
                    UserName = "my03000844",
                    Email = "my03000844@gmail.com",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 2
                },
                new RegisterUserDTO //51
                {
                    FullName = "Nguyen Thi Tra My",
                    UserName = "my03000849",
                    Email = "my03000849@gmail.com",
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
