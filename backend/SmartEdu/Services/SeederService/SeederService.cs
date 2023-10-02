using AutoMapper;
using AutoMapper.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartEdu.DTOs.UserDTO;
using SmartEdu.Entities;
using SmartEdu.Models;
using SmartEdu.Services.CrawlerService;
using SmartEdu.UnitOfWork;
using SmartEdu.Helpers.TimetableRandomer;
using SmartEdu.Helpers.AcademicRandomer;

namespace SmartEdu.Services.SeederService
{
    public class SeederService : ISeederService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICrawlerService _crawlerService;

        public SeederService(UserManager<User> userManager, IUnitOfWork unitOfWork, IMapper mapper, ICrawlerService crawlerService)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _crawlerService = crawlerService;
        }

        public async Task<ServerResponse<object>> SeedingData()
        {
            var serverResponse = new ServerResponse<object>();

            var roles = new List<string> { "User" };

            var registerUserDTOs = new List<RegisterUserDTO>
            {

                // Teachers users
                new RegisterUserDTO // 1
                {
                    FullName = "Nguyen Thi Giang",
                    UserName = "giang",
                    Email = "giang@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 1
                },
                new RegisterUserDTO // 2
                {
                    FullName = "Pham Thi Nguyet Anh",
                    UserName = "anhpham",
                    Email = "anh.pham@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 2
                },
                new RegisterUserDTO // 3
                {
                    FullName = "Nguyen Dam Thuy Duong",
                    UserName = "duong",
                    Email = "duong@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 3
                },
                new RegisterUserDTO // 4
                {
                    FullName = "Le Thi Thuy Ha",
                    UserName = "hale",
                    Email = "ha.le@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 1
                },
                new RegisterUserDTO // 5
                {
                    FullName = "Nguyen Ngoc Hai",
                    UserName = "hain",
                    Email = "hai.n@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 1
                },
                new RegisterUserDTO //6
                {
                    FullName = "Nguyen Thi Hong Phuong",
                    UserName = "hphuong",
                    Email = "hphuong@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 1
                },
                new RegisterUserDTO // 7
                {
                    FullName = "Luong Thi Hai Yen",
                    UserName = "hyen",
                    Email = "hyen@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 1
                },
                new RegisterUserDTO // 8
                {
                    FullName = "Dam Thi Lan Anh",
                    UserName = "lananh",
                    Email = "lananh@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 1
                },
                new RegisterUserDTO // 9
                {
                    FullName = "Nguyen Duc Manh",
                    UserName = "manhnguyenduc",
                    Email = "manh.nguyenduc@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 1
                },
                new RegisterUserDTO // 10
                {
                    FullName = "Pham Thi Kim Oanh",
                    UserName = "oanhphamkim",
                    Email = "oanh.phamkim@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 1
                },
                new RegisterUserDTO // 11
                {
                    FullName = "Phung Thi Kim Oanh",
                    UserName = "oanh",
                    Email = "oanh@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 1
                },
                new RegisterUserDTO // 12
                {
                    FullName = "Do Thi Thuy Trang",
                    UserName = "trangdo",
                    Email = "trang.do@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 1
                },
                new RegisterUserDTO // 13
                {
                    FullName = "Ngo Thi Thu Trang",
                    UserName = "trangngo",
                    Email = "trang.ngo@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 1
                },
                new RegisterUserDTO // 14
                {
                    FullName = "Nguyen Ba Tuan",
                    UserName = "tuan",
                    Email = "tuan@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 1
                },
                new RegisterUserDTO // 15
                {
                    FullName = "Do Thi Anh Van",
                    UserName = "vant",
                    Email = "vant@c3chuvanan.edu",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 1
                },
                new RegisterUserDTO // 16
                {
                    FullName = "Trinh Duy Tien",
                    UserName = "tien",
                    Email = "tien@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 1
                },
                new RegisterUserDTO // 17
                {
                    FullName = "Dang Thi Dinh",
                    UserName = "dinh",
                    Email = "dinh@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 2
                },
                new RegisterUserDTO // 18
                {
                    FullName = "Phan Hong Hanh",
                    UserName = "hanhphanhong",
                    Email = "hanh.phanhong@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 2
                },
                new RegisterUserDTO // 19
                {
                    FullName = "Tran Thi Thu Hien",
                    UserName = "hientran",
                    Email = "hien.tran@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 2
                },
                new RegisterUserDTO // 20
                {
                    FullName = "Phung Thi Thanh Huyen",
                    UserName = "huyenphung",
                    Email = "huyen.phung@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 2
                },
                new RegisterUserDTO // 21
                {
                    FullName = "Pham Mai Huyen",
                    UserName = "huyen",
                    Email = "huyen@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 2
                },
                new RegisterUserDTO // 22
                {
                    FullName = "Dao Thi Huong Lan",
                    UserName = "lanvan",
                    Email = "lanvan@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 2
                },
                new RegisterUserDTO // 23
                {
                    FullName = "Pham Thi Thuy Linh",
                    UserName = "linhpham",
                    Email = "linh.pham@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles= roles,
                    Type = 3,
                    SubjectId = 2
                },
                new RegisterUserDTO // 24
                {
                    FullName = "Le Thi Thanh Loan",
                    UserName = "loan",
                    Email = "loan@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 2
                },
                new RegisterUserDTO // 25
                {
                    FullName = "Nguyen Thi Thanh Mai",
                    UserName = "mainguyen",
                    Email = "mai.nguyen@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 2
                },
                new RegisterUserDTO // 26
                {
                    FullName = "Mai Thi Nguyet",
                    UserName = "nguyet",
                    Email = "nguyet@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 2
                },
                new RegisterUserDTO // 27
                {
                    FullName = "Tran Thi Phuong",
                    UserName = "phuongtran",
                    Email = "phuong.tran@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 2
                },
                new RegisterUserDTO // 28
                {
                    FullName = "Nguyen Thi Thanh Tam",
                    UserName = "tamh",
                    Email = "tamh@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 2
                },
                new RegisterUserDTO // 29
                {
                    FullName = "Nguyen Thi Huong Thuy",
                    UserName = "thuy",
                    Email = "thuy@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 2
                },
                new RegisterUserDTO // 30
                {
                    FullName = "Vu Van Thang",
                    UserName = "vuthang",
                    Email = "vuthang@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 2
                },
                new RegisterUserDTO // 31
                {
                    FullName = "Giap Thi Hai Chi",
                    UserName = "gchi",
                    Email = "gchi@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 3
                },
                new RegisterUserDTO // 32
                {
                    FullName = "Nguyen Thi Lien",
                    UserName = "lien",
                    Email = "lien@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 3
                },
                new RegisterUserDTO // 33
                {
                    FullName = "Thai Thi Phuong Nga",
                    UserName = "nga",
                    Email = "nga@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 3
                },
                new RegisterUserDTO // 34
                {
                    FullName = "Nguyen Le Hong Nhung",
                    UserName = "nhung",
                    Email = "nhung@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 3
                },
                new RegisterUserDTO // 35
                {
                    FullName = "Nguyen Van Thao",
                    UserName = "thaonguyenvan",
                    Email = "thao.nguyenvan@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 3
                },
                new RegisterUserDTO // 36
                {
                    FullName = "Nguyen Bao Tram",
                    UserName = "tram",
                    Email = "tram@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId= 3
                },
                new RegisterUserDTO // 37
                {
                    FullName = "Mai Thi Thu Trang",
                    UserName = "trangmai",
                    Email = "trang.mai@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 3
                },
                new RegisterUserDTO // 38
                {
                    FullName = "Nguyen Thi Mai Trang",
                    UserName = "trangnguyen",
                    Email = "trang.nguyen@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 3
                },
                new RegisterUserDTO // 39
                {
                    FullName = "Trinh Thu Trang",
                    UserName = "trangtrinh",
                    Email = "trang.trinh@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 3
                },
                new RegisterUserDTO // 40
                {
                    FullName = "Nong Thi Khanh Van",
                    UserName = "vannongkhanh",
                    Email = "van.nongkhanh@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 3
                },
                new RegisterUserDTO // 41
                {
                    FullName = "Vu Dieu Linh",
                    UserName = "vudlinh",
                    Email = "vudlinh@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 3
                },
                new RegisterUserDTO // 42
                {
                    FullName = "Pham Tuat Dat",
                    UserName = "dat",
                    Email = "dat@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 4
                },
                new RegisterUserDTO // 43
                {
                    FullName = "Tran Thi Kieu Giang",
                    UserName = "giangly",
                    Email = "giangly@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 4
                },
                new RegisterUserDTO // 44
                {
                    FullName = "Nguyen Thuy Hang",
                    UserName = "hang",
                    Email = "hang@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 4
                },
                new RegisterUserDTO // 45
                {
                    FullName = "Trinh Thi Huong",
                    UserName = "huongtrinhthi",
                    Email = "huong.trinhthi@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 4
                },
                new RegisterUserDTO // 46
                {
                    FullName = "Nguyen Thi Lan",
                    UserName = "lan",
                    Email = "lan@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 4
                },
                new RegisterUserDTO // 47
                {
                    FullName = "Tran Thi Ngoan",
                    UserName = "ngoan",
                    Email = "ngoan@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 4
                },
                new RegisterUserDTO // 48
                {
                    FullName = "Bui Thi Quynh Anh",
                    UserName = "quynhanh",
                    Email = "quynhanh@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 4
                },
                new RegisterUserDTO // 49
                {
                    FullName = "Pham Ngoc Thang",
                    UserName = "thangpham",
                    Email = "thangpham@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 4
                },
                new RegisterUserDTO // 50
                {
                    FullName = "Dao Tri Thuc",
                    UserName = "thuc",
                    Email = "thuc@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 4
                },
                new RegisterUserDTO // 51
                {
                    FullName = "Tran Thanh Thuy",
                    UserName = "thuytranthanh",
                    Email = "thuy.tranthanh@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 4
                },
                new RegisterUserDTO // 52
                {
                    FullName = "Nguyen Kim Chi",
                    UserName = "chi",
                    Email = "chi@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 5
                },
                new RegisterUserDTO // 53
                {
                    FullName = "Nguyen Thi Hanh",
                    UserName = "hanh",
                    Email = "hanh@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 5
                },
                new RegisterUserDTO // 54
                {
                    FullName = "Nguyen Thi Kim Hoa",
                    UserName = "hoa",
                    Email = "hoa@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 5
                },
                new RegisterUserDTO // 55
                {
                    FullName = "Le Thi Thu Huong",
                    UserName = "huongle",
                    Email = "huong.le@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 5
                },
                new RegisterUserDTO // 56
                {
                    FullName = "Phan Thi Phuong Khanh",
                    UserName = "khanh",
                    Email = "khanh@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 5
                },
                new RegisterUserDTO // 57
                {
                    FullName = "Nguyen Van Kien",
                    UserName = "kien",
                    Email = "kien@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 5
                },
                new RegisterUserDTO // 58
                {
                    FullName = "Vo Thi Hai Ly",
                    UserName = "ly",
                    Email = "ly@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 5
                },
                new RegisterUserDTO // 59
                {
                    FullName = "Do Thi Ngoc Mai",
                    UserName = "maido",
                    Email = "mai.do@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 5
                },
                new RegisterUserDTO //60
                {
                    FullName = "Phan Huy Minh",
                    UserName = "minh",
                    Email = "minh@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 5
                },
                new RegisterUserDTO // 61
                {
                    FullName = "Nguyen Thi Nhung",
                    UserName = "nguyennhung",
                    Email = "nguyennhung@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 5
                },
                new RegisterUserDTO // 62
                {
                    FullName = "Trinh Kim Thu",
                    UserName = "thutrinh",
                    Email = "thu.trinh@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 5
                },
                new RegisterUserDTO // 63
                {
                    FullName = "Dao Huu Toan",
                    UserName = "toan",
                    Email = "toan@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 5
                },
                new RegisterUserDTO // 64
                {
                    FullName = "Nguyen Thi Thanh Binh",
                    UserName = "binhnguyen",
                    Email = "binh.nguyen@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 6
                },
                new RegisterUserDTO // 65
                {
                    FullName = "Nguyen Thi Minh Ha",
                    UserName = "hanguyen",
                    Email = "ha.nguyen@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 6
                },
                new RegisterUserDTO // 66
                {
                    FullName = "Vo Thi My Hanh",
                    UserName = "hanhvo",
                    Email = "hanh.vo@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 6
                },
                new RegisterUserDTO // 67
                {
                    FullName = "Nguyen Thi Thu Ha",
                    UserName = "hasinh",
                    Email = "hasinh@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 6
                },
                new RegisterUserDTO // 68
                {
                    FullName = "Nguyen Thi Thanh Huyen",
                    UserName = "huyennguyen",
                    Email = "huyen.nguyen@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 6
                },
                new RegisterUserDTO // 69
                {
                    FullName = "Nguyen Thi Phuong Thanh",
                    UserName = "thanh",
                    Email = "thanh@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 6
                },
                new RegisterUserDTO // 70
                {
                    FullName = "Pham Thi Hai Van",
                    UserName = "van",
                    Email = "van@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 6
                },
                new RegisterUserDTO // 71
                {
                    FullName = "Nguyen Thi Thu Hien",
                    UserName = "hiennguyen",
                    Email = "hien.nguyen@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 7
                },
                new RegisterUserDTO // 72
                {
                    FullName = "Nguyen Thi Hoan",
                    UserName = "hoan",
                    Email = "hoan@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles ,
                    Type = 3,
                    SubjectId = 7
                },
                new RegisterUserDTO // 73
                {
                    FullName = "Hoang Thi Lan Huong",
                    UserName = "huonghoang",
                    Email = "huong.hoang@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 7
                },
                new RegisterUserDTO // 74
                {
                    FullName = "Le Thi Mai Huong",
                    UserName = "huong",
                    Email = "huong@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 7
                },
                new RegisterUserDTO // 75
                {
                    FullName = "Tran Thi Mai",
                    UserName = "mai",
                    Email = "mai@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 7
                },
                new RegisterUserDTO // 76
                {
                    FullName = "Pham Thi Minh Quyen",
                    UserName = "quyen",
                    Email = "quyen@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 7
                },
                new RegisterUserDTO // 77
                {
                    FullName = "Dinh Thi Gia",
                    UserName = "gia",
                    Email = "gia@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 8
                },
                new RegisterUserDTO // 78
                {
                    FullName = "Nguyen Thi Tu Hong",
                    UserName = "hong",
                    Email = "hong@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 8
                },
                new RegisterUserDTO // 79
                {
                    FullName = "Pham Thi Thu Huyen",
                    UserName = "huyenpham",
                    Email = "huyen.pham@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 8
                },
                new RegisterUserDTO // 80
                {
                    FullName = "Ha Thi Lien",
                    UserName = "lienha",
                    Email = "lien.ha@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 8
                },
                new RegisterUserDTO // 81
                {
                    FullName = "Hoang Thi Lien",
                    UserName = "lienhoangthi",
                    Email = "lien.hoangthi@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 8
                },
                new RegisterUserDTO // 82
                {
                    FullName = "Do Thi Thanh Nga",
                    UserName = "ngado",
                    Email = "nga.do@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 8
                },
                new RegisterUserDTO // 83
                {
                    FullName = "Nguyen Thi Chang",
                    UserName = "chang",
                    Email = "chang@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 9
                },
                new RegisterUserDTO // 84
                {
                    FullName = "Le Thi Doan",
                    UserName = "doan",
                    Email = "doan@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 9
                },
                new RegisterUserDTO // 85
                {
                    FullName = "Nguyen Xuan Quang",
                    UserName = "quang",
                    Email = "quang@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 9
                },
                new RegisterUserDTO // 86
                {
                    FullName = "Pham Thanh Sam",
                    UserName = "sam",
                    Email = "sam@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 9
                },
                new RegisterUserDTO // 87
                {
                    FullName = "Pham Tuan Tai",
                    UserName = "tai",
                    Email = "tai@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 9
                },
                new RegisterUserDTO // 88
                {
                    FullName = "Nguyen Thi Hiep",
                    UserName = "hiepnguyenthi",
                    Email = "hiep.nguyenthi@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 10
                },
                new RegisterUserDTO // 89
                {
                    FullName = "Nguyen Thi Xuan",
                    UserName = "xuan",
                    Email = "xuan@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 10
                },
                new RegisterUserDTO // 90
                {
                    FullName = "Nguyen Thi Anh",
                    UserName = "anh",
                    Email = "anh@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 11
                },
                new RegisterUserDTO // 91
                {
                    FullName = "Hoang Don Thao",
                    UserName = "thao",
                    Email = "thao@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 11
                },
                new RegisterUserDTO // 92
                {
                    FullName = "Truong Van Binh",
                    UserName = "vbinh",
                    Email = "vbinh@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 11
                },
                new RegisterUserDTO // 93
                {
                    FullName = "Nguyen Xuan Chien",
                    UserName = "chien",
                    Email = "chien@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 12
                },
                new RegisterUserDTO // 94
                {
                    FullName = "Do Thi Thu Huong",
                    UserName = "huongdo",
                    Email = "huongdo@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 12
                },
                new RegisterUserDTO // 95
                {
                    FullName = "Ngo Thi Lan Huong",
                    UserName = "huongngo",
                    Email = "huongngo@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 12
                },
                new RegisterUserDTO // 96
                {
                    FullName = "Nguyen Vu Thai",
                    UserName = "thai",
                    Email = "thai@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 12
                },
                new RegisterUserDTO // 97
                {
                    FullName = "Dinh Thi Thu Thuy",
                    UserName = "thuydinh",
                    Email = "thuydinh@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 12
                },
                new RegisterUserDTO // 98
                {
                    FullName = "Nguyen Thi Thanh Thuy",
                    UserName = "thuynguyen",
                    Email = "thuynguyen@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 13
                },
                new RegisterUserDTO // 99
                {
                    FullName = "Do Trung Duc",
                    UserName = "dduc",
                    Email = "dduc@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 14
                },
                new RegisterUserDTO // 100
                {
                    FullName = "Nguyen Thi Minh Diep",
                    UserName = "diep",
                    Email = "diep@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 14
                },
                new RegisterUserDTO // 101
                {
                    FullName = "Nguyen Thi Hoan",
                    UserName = "hoanphap",
                    Email = "hoanphap@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 14
                },
                new RegisterUserDTO // 102
                {
                    FullName = "Nguyen Thi Van Khanh",
                    UserName = "khanhnguyen",
                    Email = "khanhnguyen@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 14
                },
                new RegisterUserDTO // 103
                {
                    FullName = "Nguyen Thi Thuy Linh",
                    UserName = "linhnguyen",
                    Email = "linhnguyen@c3chuvanan.edu.vn",
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 3,
                    SubjectId = 14
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
                    DateOfBirth = new DateTime(2007, 9, 21),
                    Roles = roles,
                    Type = 1,
                    ParentId = 1,
                    MainClassId = 6
                },
                new RegisterUserDTO // 2
                {
                    FullName = "Nguyen Ngoc Tram Anh",
                    UserName = "anh04003229",
                    Email = "anh04003229@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003229",
                    DateOfBirth = new DateTime(2007, 11, 27),
                    Roles = roles,
                    Type = 1,
                    ParentId = 2,
                    MainClassId = 6
                },
                new RegisterUserDTO // 3
                {
                    FullName = "Pham Viet Anh",
                    UserName = "anh04003230",
                    Email = "anh04003230@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003230",
                    DateOfBirth = new DateTime(2007, 12, 8),
                    Roles = roles,
                    Type = 1,
                    ParentId = 3,
                    MainClassId = 6
                },
                new RegisterUserDTO // 4
                {
                    FullName = "Bui Thi Quynh Anh",
                    UserName = "anh04003231",
                    Email = "anh04003231@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003231",
                    DateOfBirth = new DateTime(2007, 10, 15),
                    Roles = roles,
                    Type = 1,
                    ParentId = 4,
                    MainClassId = 6
                },
                new RegisterUserDTO // 5
                {
                    FullName = "Vu Duc Anh",
                    UserName = "anh04003232",
                    Email = "anhanh04003232@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003232",
                    DateOfBirth = new DateTime(2007, 3, 1),
                    Roles = roles,
                    Type = 1,
                    ParentId = 5,
                    MainClassId = 6
                },
                new RegisterUserDTO // 6
                {
                    FullName = "Nguyen Phung Linh Chi",
                    UserName = "chi04003233",
                    Email = "chi04003233@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003233",
                    DateOfBirth = new DateTime(2007, 12, 14),
                    Roles = roles,
                    Type = 1,
                    ParentId = 6,
                    MainClassId = 6
                },
                new RegisterUserDTO // 7
                {
                    FullName = "Duong My Dung",
                    UserName = "dung04003234",
                    Email = "dung04003234@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003234",
                    DateOfBirth = new DateTime(2007, 12, 5),
                    Roles = roles,
                    Type = 1,
                    ParentId = 7,
                    MainClassId = 6
                },
                new RegisterUserDTO // 8
                {
                    FullName = "Nguyen Manh Duy",
                    UserName = "duy04003235",
                    Email = "duy04003235@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003235",
                    DateOfBirth = new DateTime(2007, 8, 10),
                    Roles = roles,
                    Type = 1,
                    ParentId = 8,
                    MainClassId = 6
                },
                new RegisterUserDTO // 9
                {
                    FullName = "Pham Phuong Duy",
                    UserName = "duy04003236",
                    Email = "duy04003236@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003236",
                    DateOfBirth = new DateTime(2007, 11, 30),
                    Roles = roles,
                    Type = 1,
                    ParentId = 9,
                    MainClassId = 6
                },
                new RegisterUserDTO // 10
                {
                    FullName = "Nguyen Thuy Duong",
                    UserName = "duong04003237",
                    Email = "duong04003237@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003237",
                    DateOfBirth = new DateTime(2007, 1, 4),
                    Roles = roles,
                    Type = 1,
                    ParentId = 10,
                    MainClassId = 6
                },
                new RegisterUserDTO // 11
                {
                    FullName = "Luu Minh Hang",
                    UserName = "hang04003238",
                    Email = "hang04003238@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003238",
                    DateOfBirth = new DateTime(2007, 11, 24),
                    Roles = roles,
                    Type = 1,
                    ParentId = 11,
                    MainClassId = 6
                },
                new RegisterUserDTO // 12
                {
                    FullName = "Nguyen Huu Minh Hoang",
                    UserName = "hoang04003239",
                    Email = "hoang04003239@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003239",
                    DateOfBirth = new DateTime(2007, 5, 7),
                    Roles = roles,
                    Type = 1,
                    ParentId = 12,
                    MainClassId = 6
                },
                new RegisterUserDTO // 13
                {
                    FullName = "Nguyen Huy Hoang",
                    UserName = "hoang04003240",
                    Email = "hoang04003240@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003240",
                    DateOfBirth = new DateTime(2007, 11, 27),
                    Roles = roles,
                    Type = 1,
                    ParentId = 13,
                    MainClassId = 6
                },
                new RegisterUserDTO // 14
                {
                    FullName = "Nguyen Duc Huy",
                    UserName = "huy04003241",
                    Email = "huy04003241@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003241",
                    DateOfBirth = new DateTime(2007, 2, 2),
                    Roles = roles,
                    Type = 1,
                    ParentId = 14,
                    MainClassId = 6
                },
                new RegisterUserDTO // 15
                {
                    FullName = "Vu Duc Huy",
                    UserName = "huy04003242",
                    Email = "huy04003242@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003242",
                    DateOfBirth = new DateTime(2007, 3, 7),
                    Roles = roles,
                    Type = 1,
                    ParentId = 15,
                    MainClassId = 6
                },
                new RegisterUserDTO // 16
                {
                    FullName = "Nguyen Trung Kien",
                    UserName = "kien04003243",
                    Email = "kien04003243@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003243",
                    DateOfBirth = new DateTime(2007, 7, 12),
                    Roles = roles,
                    Type = 1,
                    ParentId = 16,
                    MainClassId = 6
                },
                new RegisterUserDTO // 17
                {
                    FullName = "Le Duy Khiem",
                    UserName = "khiem04003244",
                    Email = "khiem04003244@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003244",
                    DateOfBirth = new DateTime(2007, 8, 5),
                    Roles = roles,
                    Type = 1,
                    ParentId = 17,
                    MainClassId = 6
                },
                new RegisterUserDTO // 18
                {
                    FullName = "Nguyen Minh Khue",
                    UserName = "khue04003245",
                    Email = "khue04003245@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.003245",
                    DateOfBirth = new DateTime(2007, 12, 9),
                    Roles = roles,
                    Type = 1,
                    ParentId = 18,
                    MainClassId = 6
                },
                new RegisterUserDTO //19
                {
                    FullName = "Bui Hai Lam",
                    UserName = "lam04002587",
                    Email = "lam04002587@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.002587",
                    DateOfBirth = new DateTime(2007, 8, 11),
                    Roles = roles,
                    Type = 1,
                    ParentId = 19,
                    MainClassId = 6
                },
                new RegisterUserDTO //20
                {
                    FullName = "Nguyen Ha Gia Linh",
                    UserName = "linh04002588",
                    Email = "linh04002588@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.002588",
                    DateOfBirth = new DateTime(2007, 12, 5),
                    Roles = roles,
                    Type = 1,
                    ParentId = 20,
                    MainClassId = 6
                },
                new RegisterUserDTO //21
                {
                    FullName = "Nguyen Phuc Loc",
                    UserName = "loc04002590",
                    Email = "loc04002590@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.002590",
                    DateOfBirth = new DateTime(2007, 6, 26),
                    Roles = roles,
                    Type = 1,
                    ParentId = 21,
                    MainClassId = 6
                },
                new RegisterUserDTO //22
                {
                    FullName = "Hoang Huong Ly",
                    UserName = "ly04002591",
                    Email = "ly04002591@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.002591",
                    DateOfBirth = new DateTime(2007, 1, 10),
                    Roles = roles,
                    Type = 1,
                    ParentId = 22,
                    MainClassId = 6
                },
                new RegisterUserDTO //23
                {
                    FullName = "Trinh Xuan Minh",
                    UserName = "minh04002589",
                    Email = "minh04002589@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.002589",
                    DateOfBirth = new DateTime(2007, 2, 25),
                    Roles = roles,
                    Type = 1,
                    ParentId = 23,
                    MainClassId = 6
                },
                new RegisterUserDTO //24
                {
                    FullName = "Nguyen Vu Tien Nam",
                    UserName = "nam04002592",
                    Email = "nam04002592@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.002592",
                    DateOfBirth = new DateTime(2007, 12, 1),
                    Roles = roles,
                    Type = 1,
                    ParentId = 24,
                    MainClassId = 6
                },
                new RegisterUserDTO //25
                {
                    FullName = "Pham Thi Hang Nga",
                    UserName = "nga04002593",
                    Email = "nga04002593@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.002593",
                    DateOfBirth = new DateTime(2007, 7, 6),
                    Roles = roles,
                    Type = 1,
                    ParentId = 25,
                    MainClassId = 6
                },
                new RegisterUserDTO //26
                {
                    FullName = "Hoang Kim Ngan",
                    UserName = "ngan04002594",
                    Email = "ngan04002594@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.002594",
                    DateOfBirth = new DateTime(2007, 1, 31),
                    Roles = roles,
                    Type = 1,
                    ParentId = 26,
                    MainClassId = 6
                },
                new RegisterUserDTO //27
                {
                    FullName = "Hoang Yen Nhi",
                    UserName = "nhi04002595",
                    Email = "nhi04002595@gmail.com",
                    Identifier = "STU04.002595",
                    DateOfBirth = new DateTime(2007, 1, 20),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 27,
                    MainClassId = 6
                },
                new RegisterUserDTO //28
                {
                    FullName = "Mai Ngo Thien Phu",
                    UserName = "phu04002596",
                    Email = "phu04002596@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.002596",
                    DateOfBirth = new DateTime(2007, 9, 10),
                    Roles = roles,
                    Type = 1,
                    ParentId = 28,
                    MainClassId = 6
                },
                new RegisterUserDTO //29
                {
                    FullName = "Le Tien Tam",
                    UserName = "tam04002597",
                    Email = "tam04002597@gmail.com",
                    Password = "Sm@rtEdu1",
                    Identifier = "STU04.002597",
                    DateOfBirth = new DateTime(2007, 7, 11),
                    Roles = roles,
                    Type = 1,
                    ParentId = 29,
                    MainClassId = 6
                },
                new RegisterUserDTO //30
                {
                    FullName = "Tran Xuan Toan",
                    UserName = "toan04002599",
                    Email = "toan04002599@gmail.com",
                    Identifier = "STU04.002599",
                    DateOfBirth = new DateTime(2007, 11, 10),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 30,
                    MainClassId = 6
                },
                new RegisterUserDTO //31
                {
                    FullName = "Le Minh Tuan",
                    UserName = "tuan04002598",
                    Email = "tuan04002598@gmail.com",
                    Identifier = "STU04.002598",
                    DateOfBirth = new DateTime(2007, 2, 13),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 31,
                    MainClassId = 6
                },
                new RegisterUserDTO //32
                {
                    FullName = "Duong Tat Thanh",
                    UserName = "thanh04002603",
                    Email = "thanh04002603@gmail.com",
                    Identifier = "STU04.002603",
                    DateOfBirth = new DateTime(2007, 8, 1),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 32,
                    MainClassId = 6
                },
                new RegisterUserDTO //33
                {
                    FullName = "Le Cao Thang",
                    UserName = "thang04002602",
                    Email = "thang04002602@gmail.com",
                    Identifier = "STU04.002602",
                    DateOfBirth = new DateTime(2007, 1, 3),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 33,
                    MainClassId = 6
                },
                new RegisterUserDTO //34
                {
                    FullName = "Dang Phuong Thuy",
                    UserName = "thuy04002601",
                    Email = "thuy04002601@gmail.com",
                    Identifier = "STU04.002601",
                    DateOfBirth = new DateTime(2007, 12, 31),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 34,
                    MainClassId = 6
                },
                new RegisterUserDTO //35
                {
                    FullName = "Nguyen Thu Trang",
                    UserName = "trang04002600",
                    Email = "trang0134100853@gmail.com",
                    Identifier = "STU04002600",
                    DateOfBirth = new DateTime(2007, 3, 30),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 35,
                    MainClassId = 6
                },
                new RegisterUserDTO //36
                {
                    FullName = "Nguyen Thuy Trang",
                    UserName = "trang04002608",
                    Email = "trang04002608@gmail.com",
                    Identifier = "STU04.002608",
                    DateOfBirth = new DateTime(2007, 10, 22),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 36,
                    MainClassId = 6
                },
                new RegisterUserDTO //37
                {
                    FullName = "Le Dinh Phong",
                    UserName = "phong04002605",
                    Email = "phong04002605@gmail.com",
                    Identifier = "STU04.002605",
                    DateOfBirth = new DateTime(2007, 6, 6),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 37,
                    MainClassId = 6
                },
                new RegisterUserDTO //38
                {
                    FullName = "Bui Ta Phuong",
                    UserName = "phuong04002604",
                    Email = "phuong04002604@gmail.com",
                    Identifier = "STU04.002604",
                    DateOfBirth = new DateTime(2007, 9, 22),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 38,
                    MainClassId = 6
                },
                new RegisterUserDTO //39
                {
                    FullName = "Nguyen Van Thanh",
                    UserName = "thanh04002607",
                    Email = "thanh04002607@gmail.com",
                    Identifier = "STU04.002607",
                    DateOfBirth = new DateTime(2007, 8, 14),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 39,
                    MainClassId = 6
                },
                new RegisterUserDTO //40
                {
                    FullName = "Nguyen Ngoc Tuyen",
                    UserName = "tuyen04002606",
                    Email = "thanh04002606@gmail.com",
                    Identifier = "STU04.002606",
                    DateOfBirth = new DateTime(2007, 12, 18),
                    Password = "Sm@rtEdu1",
                    Roles = roles,
                    Type = 1,
                    ParentId = 40,
                    MainClassId = 6
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
            };

            await SeedingUsers(registerUserDTOs);
            await SeedingTeachers(registerUserDTOs);
            await SeedingMainClasses();
            await SeedingExtraClasses();
            await SeedingParents(registerUserDTOs);
            await SeedingStudents(registerUserDTOs);
            await SeedingMarks();
            await SeedingDocuments();
            await SeedingTimetables();
            await SeedingAcademicProgresses();
            await SeedingAcademicTracker();

            serverResponse.Message = "Seeding data successfully.";

            return serverResponse;
        }

        public async Task SeedingTeachers(List<RegisterUserDTO> registerUserDTOs)
        {

            var count = _unitOfWork.TeacherRepository.Count();
            if (count > 0)
            {

                System.Console.WriteLine("Teachers had been seeded before. Aborting...");

                return;
            }

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

            Console.WriteLine("Seeding teachers successfully :)");

        }

        public async Task SeedingStudents(List<RegisterUserDTO> registerUserDTOs)
        {
            var count = _unitOfWork.StudentRepository.Count();
            if (count > 0)
            {

                System.Console.WriteLine("Students had been seeded before. Aborting...");

                return;
            }
            var length = registerUserDTOs.Count(registerUserDTO => registerUserDTO.Type == 1 && registerUserDTO.ParentId > 0 && registerUserDTO.MainClassId > 0);

            var ecBookmarks = new List<EcBookmark>();

            for (var i = 0; i < length; i++)
            {
                ecBookmarks.Add(new EcBookmark());
            }

            await _unitOfWork.EcBookmarkRepository.AddRange(ecBookmarks);
            await _unitOfWork.Save();

            var students = new List<Student>();
            int index = 0;
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
                        Identifier = registerUserDTO.Identifier,
                        EcBookmarkId = ++index
                    };
                    students.Add(student);

                }
            }

            await _unitOfWork.StudentRepository.AddRange(students);
            await _unitOfWork.Save();

            Console.WriteLine("Seeding students successfully :)");

        }

        public async Task SeedingParents(List<RegisterUserDTO> registerUserDTOs)
        {
            var count = _unitOfWork.ParentRepository.Count();

            if (count > 0)
            {

                System.Console.WriteLine("Parents had been seeded before. Aborting...");

                return;
            }

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

            Console.WriteLine("Seeding parents successfully :)");

        }

        public async Task SeedingUsers(List<RegisterUserDTO> registerUserDTOs)
        {
            // Guard clause
            var count = await _userManager.Users.CountAsync();
            if (count > 0)
            {

                Console.WriteLine("Users had been seeeded before. Aborting...");

                return;
            }

            foreach (var registerUserDTO in registerUserDTOs)
            {
                var user = _mapper.Map<User>(registerUserDTO);
                await _userManager.CreateAsync(user, registerUserDTO.Password);
                await _userManager.AddToRolesAsync(user, registerUserDTO.Roles);
            }

            Console.WriteLine("Seeding users successfully :)");

        }

        public async Task SeedingMainClasses()
        {
            var count = _unitOfWork.MainClassRepository.Count();
            if (count > 0)
            {

                System.Console.WriteLine("Main classes had been seeded before. Aborting...");

                return;
            }
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
                },
                new MainClass
                {
                    Name = "10D",
                    TeacherId = 4
                },
                new MainClass
                {
                    Name = "10E",
                    TeacherId = 5
                },
                new MainClass
                {
                    Name = "11A",
                    TeacherId = 6
                },
                new MainClass
                {
                    Name = "11B",
                    TeacherId = 7
                },
                new MainClass
                {
                    Name = "11C",
                    TeacherId = 8
                },
                new MainClass
                {
                    Name = "11D",
                    TeacherId = 9
                },
                new MainClass
                {
                    Name = "11E",
                    TeacherId = 10
                },
                new MainClass
                {
                    Name = "12A",
                    TeacherId = 11
                },
                new MainClass
                {
                    Name = "12B",
                    TeacherId = 12
                },
                new MainClass
                {
                    Name = "12C",
                    TeacherId = 13
                },
                new MainClass
                {
                    Name = "12D",
                    TeacherId = 14
                },
                new MainClass
                {
                    Name = "12E",
                    TeacherId = 15
                }
            };
            await _unitOfWork.MainClassRepository.AddRange(mainClasses);
            await _unitOfWork.Save();

            Console.WriteLine("Seeding main classes successfully :)");

        }

        public async Task SeedingExtraClasses()
        {
            var count = _unitOfWork.ExtraClassRepository.Count();
            if (count > 0)
            {

                System.Console.WriteLine("Extra classes had been seeded before. Aborting...");

                return;
            }
            var extraClasses = new List<ExtraClass>
            {
                new ExtraClass
                {
                    Name = "Maths A2308-10",
                    SubjectId = 1,
                    TeacherId = 1,
                    Description = "Join us for an exciting journey through the world of mathematics in our high school math class! Designed for students who are ready to take their math skills to the next level, this class will delve into the fascinating realms of algebra, geometry, trigonometry, and calculus.",
                    Weekday = 1,
                    From = new TimeSpan(15, 0, 0),
                    To = new TimeSpan(17, 0, 0),
                    OpeningDate = new DateTime(2023, 9, 15),
                    Capacity = 32
                },
                new ExtraClass
                {
                    Name = "Literature A2308-10",
                    SubjectId = 2,
                    TeacherId = 2,
                    Description = "Embark on a captivating literary voyage in our high school literature class! Immerse yourself in the enchanting world of classic and contemporary literature as we explore timeless stories, rich poetry, and thought-provoking plays.",
                    Weekday = 2,
                    From = new TimeSpan(15, 0, 0),
                    To = new TimeSpan(17, 0, 0),
                    OpeningDate = new DateTime(2023, 9, 16),
                    Capacity = 34
                },
                new ExtraClass
                {
                    Name = "English A2308-10",
                    SubjectId = 3,
                    TeacherId = 3,
                    Description = "In this class, you'll master the foundations of English grammar, vocabulary, and pronunciation while gaining insight into the rich tapestry of Hispanic heritage. Our enthusiastic and experienced English instructor will guide you through interactive lessons, cultural activities, and immersive conversations that will make learning English a fun and rewarding experience.",
                    Weekday = 3,
                    From = new TimeSpan(15, 0, 0),
                    To = new TimeSpan(17, 0, 0),
                    OpeningDate = new DateTime(2023, 9, 17),
                    Capacity = 25
                },
                new ExtraClass
                {
                    Name = "Physics A2308-10",
                    SubjectId = 4,
                    TeacherId = 44,
                    Description = "Prepare for a thrilling expedition through the fundamental laws that govern our universe in our high school physics class! This class is your gateway to understanding the forces, motion, energy, and mysteries of the physical world.",
                    Weekday = 4,
                    From = new TimeSpan(15, 0, 0),
                    To = new TimeSpan(17, 0, 0),
                    OpeningDate = new DateTime(2023, 9, 18),
                    Capacity = 28
                },
                new ExtraClass
                {
                    Name = "Chemistry A2308-10",
                    SubjectId = 5,
                    TeacherId = 55,
                    Description = "Dive into the captivating world of molecules, reactions, and the building blocks of matter in our high school chemistry class! Join us for an exciting journey that demystifies the secrets of the elements, compounds, and the chemical processes that shape our world.",
                    Weekday = 5,
                    From = new TimeSpan(15, 0, 0),
                    To = new TimeSpan(17, 0, 0),
                    OpeningDate = new DateTime(2023, 9, 19),
                    Capacity = 26
                },
                new ExtraClass
                {
                    Name = "Biology A2308-10",
                    SubjectId = 6,
                    TeacherId = 66,
                    Description = "Embark on a thrilling adventure through the wonders of the natural world in our high school biology class! Explore the intricate web of life, from the tiniest microorganisms to the complexity of ecosystems, as we delve into the science of biology.",
                    Weekday = 6,
                    From = new TimeSpan(15, 0, 0),
                    To = new TimeSpan(17, 0, 0),
                    OpeningDate = new DateTime(2023, 9, 20),
                    Capacity = 25
                },
                new ExtraClass
                {
                    Name = "History A2308-10",
                    SubjectId = 7,
                    TeacherId = 76,
                    Description = "Step into the annals of time and embark on a captivating journey through the pages of history in our high school history class! Discover the stories, events, and civilizations that have shaped the world we live in today.",
                    Weekday = 7,
                    From = new TimeSpan(15, 0, 0),
                    To = new TimeSpan(17, 0, 0),
                    OpeningDate = new DateTime(2023, 9, 21),
                    Capacity = 20
                },
                new ExtraClass
                {
                    Name = "Geography A2308-10",
                    SubjectId = 8,
                    TeacherId = 78,
                    Description = "Embark on a thrilling adventure around the globe in our high school geography class! Explore the diverse landscapes, cultures, and environments that make our world a place of wonder and discovery.",
                    Weekday = 1,
                    From = new TimeSpan(15, 0, 0),
                    To = new TimeSpan(17, 0, 0),
                    OpeningDate = new DateTime(2023, 9, 22),
                    Capacity = 22
                },
                new ExtraClass
                {
                    Name = "Maths A2308-11",
                    SubjectId = 1,
                    TeacherId = 1,
                    Description = "Join us for an exciting journey through the world of mathematics in our high school math class! Designed for students who are ready to take their math skills to the next level, this class will delve into the fascinating realms of algebra, geometry, trigonometry, and calculus.",
                    Weekday = 2,
                    From = new TimeSpan(15, 0, 0),
                    To = new TimeSpan(17, 0, 0),
                    OpeningDate = new DateTime(2023, 9, 23),
                    Capacity = 34
                },
                new ExtraClass
                {
                    Name = "Literature A2308-11",
                    SubjectId = 2,
                    TeacherId = 2,
                    Description = "Join us for an exciting journey through the world of mathematics in our high school math class! Designed for students who are ready to take their math skills to the next level, this class will delve into the fascinating realms of algebra, geometry, trigonometry, and calculus.",
                    Weekday = 3,
                    From = new TimeSpan(15, 0, 0),
                    To = new TimeSpan(17, 0, 0),
                    OpeningDate = new DateTime(2023, 9, 24),
                    Capacity = 32
                },
                new ExtraClass
                {
                    Name = "English A2308-11",
                    SubjectId = 3,
                    TeacherId = 3,
                    Description = "Join us for an exciting journey through the world of mathematics in our high school math class! Designed for students who are ready to take their math skills to the next level, this class will delve into the fascinating realms of algebra, geometry, trigonometry, and calculus.",
                    Weekday = 4,
                    From = new TimeSpan(15, 0, 0),
                    To = new TimeSpan(17, 0, 0),
                    OpeningDate = new DateTime(2023, 9, 25),
                    Capacity = 36
                },
                new ExtraClass
                {
                    Name = "Physics A2308-11",
                    SubjectId = 4,
                    TeacherId = 44,
                    Description = "Join us for an exciting journey through the world of mathematics in our high school math class! Designed for students who are ready to take their math skills to the next level, this class will delve into the fascinating realms of algebra, geometry, trigonometry, and calculus.",
                    Weekday = 5,
                    From = new TimeSpan(15, 0, 0),
                    To = new TimeSpan(17, 0, 0),
                    OpeningDate = new DateTime(2023, 9, 26),
                    Capacity = 28
                },
                new ExtraClass
                {
                    Name = "Chemistry A2308-11",
                    SubjectId = 5,
                    TeacherId = 55,
                    Description = "Join us for an exciting journey through the world of mathematics in our high school math class! Designed for students who are ready to take their math skills to the next level, this class will delve into the fascinating realms of algebra, geometry, trigonometry, and calculus.",
                    Weekday = 6,
                    From = new TimeSpan(15, 0, 0),
                    To = new TimeSpan(17, 0, 0),
                    OpeningDate = new DateTime(2023, 9, 27),
                    Capacity = 30
                },
                new ExtraClass
                {
                    Name = "Biology A2308-11",
                    SubjectId = 6,
                    TeacherId = 66,
                    Description = "Join us for an exciting journey through the world of mathematics in our high school math class! Designed for students who are ready to take their math skills to the next level, this class will delve into the fascinating realms of algebra, geometry, trigonometry, and calculus.",
                    Weekday = 7,
                    From = new TimeSpan(15, 0, 0),
                    To = new TimeSpan(17, 0, 0),
                    OpeningDate = new DateTime(2023, 9, 28),
                    Capacity = 26
                },
                new ExtraClass
                {
                    Name = "History A2308-11",
                    SubjectId = 7,
                    TeacherId = 76,
                    Description = "Join us for an exciting journey through the world of mathematics in our high school math class! Designed for students who are ready to take their math skills to the next level, this class will delve into the fascinating realms of algebra, geometry, trigonometry, and calculus.",
                    Weekday = 1,
                    From = new TimeSpan(15, 0, 0),
                    To = new TimeSpan(17, 0, 0),
                    OpeningDate = new DateTime(2023, 9, 29),
                    Capacity = 22
                },
                new ExtraClass
                {
                    Name = "Geography A2308-11",
                    SubjectId = 8,
                    TeacherId = 78,
                    Description = "Join us for an exciting journey through the world of mathematics in our high school math class! Designed for students who are ready to take their math skills to the next level, this class will delve into the fascinating realms of algebra, geometry, trigonometry, and calculus.",
                    Weekday = 2,
                    From = new TimeSpan(15, 0, 0),
                    To = new TimeSpan(17, 0, 0),
                    OpeningDate = new DateTime(2023, 9, 30),
                    Capacity = 24
                },
                new ExtraClass
                {
                    Name = "Maths A2308-12",
                    SubjectId = 1,
                    TeacherId = 1,
                    Description = "Join us for an exciting journey through the world of mathematics in our high school math class! Designed for students who are ready to take their math skills to the next level, this class will delve into the fascinating realms of algebra, geometry, trigonometry, and calculus.",
                    Weekday = 3,
                    From = new TimeSpan(15, 0, 0),
                    To = new TimeSpan(17, 0, 0),
                    OpeningDate = new DateTime(2023, 10, 1),
                    Capacity = 38
                },
                new ExtraClass
                {
                    Name = "Literature A2308-12",
                    SubjectId = 2,
                    TeacherId = 2,
                    Description = "Join us for an exciting journey through the world of mathematics in our high school math class! Designed for students who are ready to take their math skills to the next level, this class will delve into the fascinating realms of algebra, geometry, trigonometry, and calculus.",
                    Weekday = 4,
                    From = new TimeSpan(15, 0, 0),
                    To = new TimeSpan(17, 0, 0),
                    OpeningDate = new DateTime(2023, 10, 2),
                    Capacity = 30
                },
                new ExtraClass
                {
                    Name = "English A2308-12",
                    SubjectId = 3,
                    TeacherId = 3,
                    Description = "Join us for an exciting journey through the world of mathematics in our high school math class! Designed for students who are ready to take their math skills to the next level, this class will delve into the fascinating realms of algebra, geometry, trigonometry, and calculus.",
                    Weekday = 5,
                    From = new TimeSpan(15, 0, 0),
                    To = new TimeSpan(17, 0, 0),
                    OpeningDate = new DateTime(2023, 10, 3),
                    Capacity = 32
                },
                new ExtraClass
                {
                    Name = "Physics A2308-12",
                    SubjectId = 4,
                    TeacherId = 44,
                    Description = "Join us for an exciting journey through the world of mathematics in our high school math class! Designed for students who are ready to take their math skills to the next level, this class will delve into the fascinating realms of algebra, geometry, trigonometry, and calculus.",
                    Weekday = 6,
                    From = new TimeSpan(15, 0, 0),
                    To = new TimeSpan(17, 0, 0),
                    OpeningDate = new DateTime(2023, 10, 4),
                    Capacity = 28
                },
                new ExtraClass
                {
                    Name = "Chemistry A2308-12",
                    SubjectId = 5,
                    TeacherId = 55,
                    Description = "Join us for an exciting journey through the world of mathematics in our high school math class! Designed for students who are ready to take their math skills to the next level, this class will delve into the fascinating realms of algebra, geometry, trigonometry, and calculus.",
                    Weekday = 7,
                    From = new TimeSpan(15, 0, 0),
                    To = new TimeSpan(17, 0, 0),
                    OpeningDate = new DateTime(2023, 10, 5),
                    Capacity = 26
                },
                new ExtraClass
                {
                    Name = "Biology A2308-12",
                    SubjectId = 6,
                    TeacherId = 66,
                    Description = "Join us for an exciting journey through the world of mathematics in our high school math class! Designed for students who are ready to take their math skills to the next level, this class will delve into the fascinating realms of algebra, geometry, trigonometry, and calculus.",
                    Weekday = 1,
                    From = new TimeSpan(15, 0, 0),
                    To = new TimeSpan(17, 0, 0),
                    OpeningDate = new DateTime(2023, 10, 6),
                    Capacity = 24
                },
                new ExtraClass
                {
                    Name = "History A2308-12",
                    SubjectId = 7,
                    TeacherId = 76,
                    Description = "Join us for an exciting journey through the world of mathematics in our high school math class! Designed for students who are ready to take their math skills to the next level, this class will delve into the fascinating realms of algebra, geometry, trigonometry, and calculus.",
                    Weekday = 2,
                    From = new TimeSpan(15, 0, 0),
                    To = new TimeSpan(17, 0, 0),
                    OpeningDate = new DateTime(2023, 10, 7),
                    Capacity = 20
                },
                new ExtraClass
                {
                    Name = "Geography A2308-12",
                    SubjectId = 8,
                    TeacherId = 78,
                    Description = "Join us for an exciting journey through the world of mathematics in our high school math class! Designed for students who are ready to take their math skills to the next level, this class will delve into the fascinating realms of algebra, geometry, trigonometry, and calculus.",
                    Weekday = 3,
                    From = new TimeSpan(15, 0, 0),
                    To = new TimeSpan(17, 0, 0),
                    OpeningDate = new DateTime(2023, 10, 8),
                    Capacity = 20
                },
            };

            await _unitOfWork.ExtraClassRepository.AddRange(extraClasses);
            await _unitOfWork.Save();

            Console.WriteLine("Seeding extra classes successfully :)");

        }

        public async Task SeedingDocumentsBySubject(DocumentSeederOptions options)
        {
            await _crawlerService.FetchAndSave(options.HtmlUrl, options.HtmlFilePath);
            await _crawlerService.FetchAndSave(options.JsonUrl, options.JsonFilePath);

            var documents = _crawlerService.ExtractDocuments(options.HtmlFilePath, options.JsonFilePath);

            var teachers = (await _unitOfWork.TeacherRepository.GetAll(null, t => t.SubjectId == options.SubjectId, null, null)).ToArray<Teacher>();

            var random = new Random();

            foreach (var d in documents)
            {
                var i = random.Next(0, teachers.Length - 1);
                d.TeacherId = teachers.ElementAt(i).Id;
            }

            await _unitOfWork.DocumentRepository.AddRange(documents);
            await _unitOfWork.Save();
        }

        public async Task SeedingDocuments()
        {
            var count = _unitOfWork.DocumentRepository.Count(d => true);
            if (count > 0)
            {

                Console.WriteLine("Documents had been seeded before. Aborting...");

                return;
            }
            // Seeding math documents
            await SeedingDocumentsBySubject(new DocumentSeederOptions
            {
                HtmlUrl = "https://www.goodreads.com/list/show/8231.Best_Books_About_Mathematics",
                HtmlFilePath = ".assets/math.html",
                JsonUrl = "https://www.goodreads.com/tooltips?resources%5BBook.24113%5D%5Btype%5D=Book&resources%5BBook.24113%5D%5Bid%5D=24113&resources%5BBook.38412%5D%5Btype%5D=Book&resources%5BBook.38412%5D%5Bid%5D=38412&resources%5BBook.433567%5D%5Btype%5D=Book&resources%5BBook.433567%5D%5Bid%5D=433567&resources%5BBook.1045550%5D%5Btype%5D=Book&resources%5BBook.1045550%5D%5Bid%5D=1045550&resources%5BBook.329336%5D%5Btype%5D=Book&resources%5BBook.329336%5D%5Bid%5D=329336&resources%5BBook.13912%5D%5Btype%5D=Book&resources%5BBook.13912%5D%5Bid%5D=13912&resources%5BBook.116185%5D%5Btype%5D=Book&resources%5BBook.116185%5D%5Bid%5D=116185&resources%5BBook.714583%5D%5Btype%5D=Book&resources%5BBook.714583%5D%5Bid%5D=714583&resources%5BBook.2272880%5D%5Btype%5D=Book&resources%5BBook.2272880%5D%5Bid%5D=2272880&resources%5BBook.214441%5D%5Btype%5D=Book&resources%5BBook.214441%5D%5Bid%5D=214441&resources%5BBook.5544%5D%5Btype%5D=Book&resources%5BBook.5544%5D%5Bid%5D=5544&resources%5BBook.51291%5D%5Btype%5D=Book&resources%5BBook.51291%5D%5Bid%5D=51291&resources%5BBook.106139%5D%5Btype%5D=Book&resources%5BBook.106139%5D%5Bid%5D=106139&resources%5BBook.584620%5D%5Btype%5D=Book&resources%5BBook.584620%5D%5Bid%5D=584620&resources%5BBook.13356649%5D%5Btype%5D=Book&resources%5BBook.13356649%5D%5Bid%5D=13356649&resources%5BBook.3869%5D%5Btype%5D=Book&resources%5BBook.3869%5D%5Bid%5D=3869&resources%5BBook.183015%5D%5Btype%5D=Book&resources%5BBook.183015%5D%5Bid%5D=183015&resources%5BBook.154060%5D%5Btype%5D=Book&resources%5BBook.154060%5D%5Bid%5D=154060&resources%5BBook.816%5D%5Btype%5D=Book&resources%5BBook.816%5D%5Bid%5D=816&resources%5BBook.218392%5D%5Btype%5D=Book&resources%5BBook.218392%5D%5Bid%5D=218392&resources%5BBook.13588394%5D%5Btype%5D=Book&resources%5BBook.13588394%5D%5Bid%5D=13588394&resources%5BBook.208916%5D%5Btype%5D=Book&resources%5BBook.208916%5D%5Bid%5D=208916&resources%5BBook.186749%5D%5Btype%5D=Book&resources%5BBook.186749%5D%5Bid%5D=186749&resources%5BBook.7901962%5D%5Btype%5D=Book&resources%5BBook.7901962%5D%5Bid%5D=7901962&resources%5BBook.91358%5D%5Btype%5D=Book&resources%5BBook.91358%5D%5Bid%5D=91358&resources%5BBook.586616%5D%5Btype%5D=Book&resources%5BBook.586616%5D%5Bid%5D=586616&resources%5BBook.6232657%5D%5Btype%5D=Book&resources%5BBook.6232657%5D%5Bid%5D=6232657&resources%5BBook.1471873%5D%5Btype%5D=Book&resources%5BBook.1471873%5D%5Bid%5D=1471873&resources%5BBook.66358%5D%5Btype%5D=Book&resources%5BBook.66358%5D%5Bid%5D=66358&resources%5BBook.415052%5D%5Btype%5D=Book&resources%5BBook.415052%5D%5Bid%5D=415052&resources%5BBook.15831687%5D%5Btype%5D=Book&resources%5BBook.15831687%5D%5Bid%5D=15831687&resources%5BBook.537480%5D%5Btype%5D=Book&resources%5BBook.537480%5D%5Bid%5D=537480&resources%5BBook.38315%5D%5Btype%5D=Book&resources%5BBook.38315%5D%5Bid%5D=38315&resources%5BBook.4806%5D%5Btype%5D=Book&resources%5BBook.4806%5D%5Bid%5D=4806&resources%5BBook.179744%5D%5Btype%5D=Book&resources%5BBook.179744%5D%5Bid%5D=179744&resources%5BBook.551722%5D%5Btype%5D=Book&resources%5BBook.551722%5D%5Bid%5D=551722&resources%5BBook.15852%5D%5Btype%5D=Book&resources%5BBook.15852%5D%5Bid%5D=15852&resources%5BBook.123471%5D%5Btype%5D=Book&resources%5BBook.123471%5D%5Bid%5D=123471&resources%5BBook.64582%5D%5Btype%5D=Book&resources%5BBook.64582%5D%5Bid%5D=64582&resources%5BBook.271361%5D%5Btype%5D=Book&resources%5BBook.271361%5D%5Bid%5D=271361&resources%5BBook.696238%5D%5Btype%5D=Book&resources%5BBook.696238%5D%5Bid%5D=696238&resources%5BBook.357209%5D%5Btype%5D=Book&resources%5BBook.357209%5D%5Bid%5D=357209&resources%5BBook.60488865%5D%5Btype%5D=Book&resources%5BBook.60488865%5D%5Bid%5D=60488865&resources%5BBook.17290683%5D%5Btype%5D=Book&resources%5BBook.17290683%5D%5Bid%5D=17290683&resources%5BBook.10638%5D%5Btype%5D=Book&resources%5BBook.10638%5D%5Bid%5D=10638&resources%5BBook.6493321%5D%5Btype%5D=Book&resources%5BBook.6493321%5D%5Bid%5D=6493321&resources%5BBook.24081%5D%5Btype%5D=Book&resources%5BBook.24081%5D%5Bid%5D=24081&resources%5BBook.719289%5D%5Btype%5D=Book&resources%5BBook.719289%5D%5Bid%5D=719289&resources%5BBook.275923%5D%5Btype%5D=Book&resources%5BBook.275923%5D%5Bid%5D=275923&resources%5BBook.1113522%5D%5Btype%5D=Book&resources%5BBook.1113522%5D%5Bid%5D=1113522",
                JsonFilePath = ".assets/math.json",
                SubjectId = 1
            });
            // Seeding literature documents
            await SeedingDocumentsBySubject(new DocumentSeederOptions
            {
                HtmlUrl = "https://www.goodreads.com/list/show/453.Best_Philosophical_Literature",
                HtmlFilePath = ".assets/literature.html",
                JsonUrl = "https://www.goodreads.com/tooltips?resources%5BBook.49552%5D%5Btype%5D=Book&resources%5BBook.49552%5D%5Bid%5D=49552&resources%5BBook.40961427%5D%5Btype%5D=Book&resources%5BBook.40961427%5D%5Bid%5D=40961427&resources%5BBook.52036%5D%5Btype%5D=Book&resources%5BBook.52036%5D%5Bid%5D=52036&resources%5BBook.157993%5D%5Btype%5D=Book&resources%5BBook.157993%5D%5Bid%5D=157993&resources%5BBook.7144%5D%5Btype%5D=Book&resources%5BBook.7144%5D%5Bid%5D=7144&resources%5BBook.5297%5D%5Btype%5D=Book&resources%5BBook.5297%5D%5Bid%5D=5297&resources%5BBook.4934%5D%5Btype%5D=Book&resources%5BBook.4934%5D%5Bid%5D=4934&resources%5BBook.5129%5D%5Btype%5D=Book&resources%5BBook.5129%5D%5Bid%5D=5129&resources%5BBook.7624%5D%5Btype%5D=Book&resources%5BBook.7624%5D%5Bid%5D=7624&resources%5BBook.17470674%5D%5Btype%5D=Book&resources%5BBook.17470674%5D%5Bid%5D=17470674&resources%5BBook.5107%5D%5Btype%5D=Book&resources%5BBook.5107%5D%5Bid%5D=5107&resources%5BBook.17690%5D%5Btype%5D=Book&resources%5BBook.17690%5D%5Bid%5D=17690&resources%5BBook.485894%5D%5Btype%5D=Book&resources%5BBook.485894%5D%5Bid%5D=485894&resources%5BBook.9717%5D%5Btype%5D=Book&resources%5BBook.9717%5D%5Bid%5D=9717&resources%5BBook.10959%5D%5Btype%5D=Book&resources%5BBook.10959%5D%5Bid%5D=10959&resources%5BBook.18144590%5D%5Btype%5D=Book&resources%5BBook.18144590%5D%5Bid%5D=18144590&resources%5BBook.16631%5D%5Btype%5D=Book&resources%5BBook.16631%5D%5Bid%5D=16631&resources%5BBook.5472%5D%5Btype%5D=Book&resources%5BBook.5472%5D%5Bid%5D=5472&resources%5BBook.17876%5D%5Btype%5D=Book&resources%5BBook.17876%5D%5Bid%5D=17876&resources%5BBook.11989%5D%5Btype%5D=Book&resources%5BBook.11989%5D%5Bid%5D=11989&resources%5BBook.4981%5D%5Btype%5D=Book&resources%5BBook.4981%5D%5Bid%5D=4981&resources%5BBook.298275%5D%5Btype%5D=Book&resources%5BBook.298275%5D%5Bid%5D=298275&resources%5BBook.629%5D%5Btype%5D=Book&resources%5BBook.629%5D%5Bid%5D=629&resources%5BBook.19380%5D%5Btype%5D=Book&resources%5BBook.19380%5D%5Bid%5D=19380&resources%5BBook.170448%5D%5Btype%5D=Book&resources%5BBook.170448%5D%5Bid%5D=170448&resources%5BBook.662%5D%5Btype%5D=Book&resources%5BBook.662%5D%5Bid%5D=662&resources%5BBook.1420%5D%5Btype%5D=Book&resources%5BBook.1420%5D%5Bid%5D=1420&resources%5BBook.2122%5D%5Btype%5D=Book&resources%5BBook.2122%5D%5Bid%5D=2122&resources%5BBook.18490%5D%5Btype%5D=Book&resources%5BBook.18490%5D%5Bid%5D=18490&resources%5BBook.24861%5D%5Btype%5D=Book&resources%5BBook.24861%5D%5Bid%5D=24861&resources%5BBook.17716%5D%5Btype%5D=Book&resources%5BBook.17716%5D%5Bid%5D=17716&resources%5BBook.3636%5D%5Btype%5D=Book&resources%5BBook.3636%5D%5Bid%5D=3636&resources%5BBook.17383917%5D%5Btype%5D=Book&resources%5BBook.17383917%5D%5Bid%5D=17383917&resources%5BBook.2657%5D%5Btype%5D=Book&resources%5BBook.2657%5D%5Bid%5D=2657&resources%5BBook.227463%5D%5Btype%5D=Book&resources%5BBook.227463%5D%5Bid%5D=227463&resources%5BBook.14706%5D%5Btype%5D=Book&resources%5BBook.14706%5D%5Bid%5D=14706&resources%5BBook.4900%5D%5Btype%5D=Book&resources%5BBook.4900%5D%5Bid%5D=4900&resources%5BBook.320%5D%5Btype%5D=Book&resources%5BBook.320%5D%5Bid%5D=320&resources%5BBook.4214%5D%5Btype%5D=Book&resources%5BBook.4214%5D%5Bid%5D=4214&resources%5BBook.8852%5D%5Btype%5D=Book&resources%5BBook.8852%5D%5Bid%5D=8852&resources%5BBook.4395%5D%5Btype%5D=Book&resources%5BBook.4395%5D%5Bid%5D=4395&resources%5BBook.10037%5D%5Btype%5D=Book&resources%5BBook.10037%5D%5Bid%5D=10037&resources%5BBook.11991%5D%5Btype%5D=Book&resources%5BBook.11991%5D%5Bid%5D=11991&resources%5BBook.135479%5D%5Btype%5D=Book&resources%5BBook.135479%5D%5Bid%5D=135479&resources%5BBook.71728%5D%5Btype%5D=Book&resources%5BBook.71728%5D%5Bid%5D=71728&resources%5BBook.18796%5D%5Btype%5D=Book&resources%5BBook.18796%5D%5Bid%5D=18796&resources%5BBook.4406%5D%5Btype%5D=Book&resources%5BBook.4406%5D%5Bid%5D=4406&resources%5BBook.18386%5D%5Btype%5D=Book&resources%5BBook.18386%5D%5Bid%5D=18386&resources%5BBook.2526%5D%5Btype%5D=Book&resources%5BBook.2526%5D%5Bid%5D=2526&resources%5BBook.88077%5D%5Btype%5D=Book&resources%5BBook.88077%5D%5Bid%5D=88077",
                JsonFilePath = ".assets/literature.json",
                SubjectId = 2
            });
            // Seeding english documents
            await SeedingDocumentsBySubject(new DocumentSeederOptions
            {
                HtmlUrl = "https://www.goodreads.com/list/show/1714.Best_Books_on_Writing",
                HtmlFilePath = ".assets/english.html",
                JsonUrl = "https://www.goodreads.com/tooltips?resources%5BBook.10569%5D%5Btype%5D=Book&resources%5BBook.10569%5D%5Bid%5D=10569&resources%5BBook.33514%5D%5Btype%5D=Book&resources%5BBook.33514%5D%5Bid%5D=33514&resources%5BBook.12543%5D%5Btype%5D=Book&resources%5BBook.12543%5D%5Bid%5D=12543&resources%5BBook.44905%5D%5Btype%5D=Book&resources%5BBook.44905%5D%5Bid%5D=44905&resources%5BBook.8600%5D%5Btype%5D=Book&resources%5BBook.8600%5D%5Bid%5D=8600&resources%5BBook.53343%5D%5Btype%5D=Book&resources%5BBook.53343%5D%5Bid%5D=53343&resources%5BBook.615570%5D%5Btype%5D=Book&resources%5BBook.615570%5D%5Bid%5D=615570&resources%5BBook.103761%5D%5Btype%5D=Book&resources%5BBook.103761%5D%5Bid%5D=103761&resources%5BBook.114817%5D%5Btype%5D=Book&resources%5BBook.114817%5D%5Bid%5D=114817&resources%5BBook.180467%5D%5Btype%5D=Book&resources%5BBook.180467%5D%5Bid%5D=180467&resources%5BBook.18521%5D%5Btype%5D=Book&resources%5BBook.18521%5D%5Bid%5D=18521&resources%5BBook.48654%5D%5Btype%5D=Book&resources%5BBook.48654%5D%5Bid%5D=48654&resources%5BBook.2617434%5D%5Btype%5D=Book&resources%5BBook.2617434%5D%5Bid%5D=2617434&resources%5BBook.1319%5D%5Btype%5D=Book&resources%5BBook.1319%5D%5Bid%5D=1319&resources%5BBook.151532%5D%5Btype%5D=Book&resources%5BBook.151532%5D%5Bid%5D=151532&resources%5BBook.32533%5D%5Btype%5D=Book&resources%5BBook.32533%5D%5Bid%5D=32533&resources%5BBook.186004%5D%5Btype%5D=Book&resources%5BBook.186004%5D%5Bid%5D=186004&resources%5BBook.49464%5D%5Btype%5D=Book&resources%5BBook.49464%5D%5Bid%5D=49464&resources%5BBook.39934%5D%5Btype%5D=Book&resources%5BBook.39934%5D%5Bid%5D=39934&resources%5BBook.7963%5D%5Btype%5D=Book&resources%5BBook.7963%5D%5Bid%5D=7963&resources%5BBook.9644%5D%5Btype%5D=Book&resources%5BBook.9644%5D%5Bid%5D=9644&resources%5BBook.31363%5D%5Btype%5D=Book&resources%5BBook.31363%5D%5Bid%5D=31363&resources%5BBook.76788%5D%5Btype%5D=Book&resources%5BBook.76788%5D%5Bid%5D=76788&resources%5BBook.173302%5D%5Btype%5D=Book&resources%5BBook.173302%5D%5Bid%5D=173302&resources%5BBook.4631%5D%5Btype%5D=Book&resources%5BBook.4631%5D%5Bid%5D=4631&resources%5BBook.13554235%5D%5Btype%5D=Book&resources%5BBook.13554235%5D%5Bid%5D=13554235&resources%5BBook.51750%5D%5Btype%5D=Book&resources%5BBook.51750%5D%5Bid%5D=51750&resources%5BBook.46199%5D%5Btype%5D=Book&resources%5BBook.46199%5D%5Bid%5D=46199&resources%5BBook.20181%5D%5Btype%5D=Book&resources%5BBook.20181%5D%5Bid%5D=20181&resources%5BBook.184825%5D%5Btype%5D=Book&resources%5BBook.184825%5D%5Bid%5D=184825&resources%5BBook.12530%5D%5Btype%5D=Book&resources%5BBook.12530%5D%5Bid%5D=12530&resources%5BBook.357464%5D%5Btype%5D=Book&resources%5BBook.357464%5D%5Bid%5D=357464&resources%5BBook.408230%5D%5Btype%5D=Book&resources%5BBook.408230%5D%5Bid%5D=408230&resources%5BBook.248954%5D%5Btype%5D=Book&resources%5BBook.248954%5D%5Bid%5D=248954&resources%5BBook.13126099%5D%5Btype%5D=Book&resources%5BBook.13126099%5D%5Bid%5D=13126099&resources%5BBook.32532%5D%5Btype%5D=Book&resources%5BBook.32532%5D%5Bid%5D=32532&resources%5BBook.459744%5D%5Btype%5D=Book&resources%5BBook.459744%5D%5Bid%5D=459744&resources%5BBook.68024%5D%5Btype%5D=Book&resources%5BBook.68024%5D%5Bid%5D=68024&resources%5BBook.13099738%5D%5Btype%5D=Book&resources%5BBook.13099738%5D%5Bid%5D=13099738&resources%5BBook.141560%5D%5Btype%5D=Book&resources%5BBook.141560%5D%5Bid%5D=141560&resources%5BBook.6524%5D%5Btype%5D=Book&resources%5BBook.6524%5D%5Bid%5D=6524&resources%5BBook.68317%5D%5Btype%5D=Book&resources%5BBook.68317%5D%5Bid%5D=68317&resources%5BBook.263254%5D%5Btype%5D=Book&resources%5BBook.263254%5D%5Bid%5D=263254&resources%5BBook.30594%5D%5Btype%5D=Book&resources%5BBook.30594%5D%5Bid%5D=30594&resources%5BBook.1383168%5D%5Btype%5D=Book&resources%5BBook.1383168%5D%5Bid%5D=1383168&resources%5BBook.14948%5D%5Btype%5D=Book&resources%5BBook.14948%5D%5Bid%5D=14948&resources%5BBook.15842650%5D%5Btype%5D=Book&resources%5BBook.15842650%5D%5Bid%5D=15842650&resources%5BBook.6664615%5D%5Btype%5D=Book&resources%5BBook.6664615%5D%5Bid%5D=6664615&resources%5BBook.116685%5D%5Btype%5D=Book&resources%5BBook.116685%5D%5Bid%5D=116685&resources%5BBook.859230%5D%5Btype%5D=Book&resources%5BBook.859230%5D%5Bid%5D=859230",
                JsonFilePath = ".assets/english.json",
                SubjectId = 3
            });
            // Seeding physics documents
            await SeedingDocumentsBySubject(new DocumentSeederOptions
            {
                HtmlUrl = "https://www.goodreads.com/list/show/38997.Female_Psychological_Thrillers_Suspense_Written_by_Women",
                HtmlFilePath = ".assets/physics.html",
                JsonUrl = "https://www.goodreads.com/tooltips?resources%5BBook.19288043%5D%5Btype%5D=Book&resources%5BBook.19288043%5D%5Bid%5D=19288043&resources%5BBook.22557272%5D%5Btype%5D=Book&resources%5BBook.22557272%5D%5Bid%5D=22557272&resources%5BBook.18045891%5D%5Btype%5D=Book&resources%5BBook.18045891%5D%5Bid%5D=18045891&resources%5BBook.5886881%5D%5Btype%5D=Book&resources%5BBook.5886881%5D%5Bid%5D=5886881&resources%5BBook.33516773%5D%5Btype%5D=Book&resources%5BBook.33516773%5D%5Bid%5D=33516773&resources%5BBook.17899948%5D%5Btype%5D=Book&resources%5BBook.17899948%5D%5Bid%5D=17899948&resources%5BBook.18812405%5D%5Btype%5D=Book&resources%5BBook.18812405%5D%5Bid%5D=18812405&resources%5BBook.7937843%5D%5Btype%5D=Book&resources%5BBook.7937843%5D%5Bid%5D=7937843&resources%5BBook.36430011%5D%5Btype%5D=Book&resources%5BBook.36430011%5D%5Bid%5D=36430011&resources%5BBook.15818362%5D%5Btype%5D=Book&resources%5BBook.15818362%5D%5Bid%5D=15818362&resources%5BBook.29437949%5D%5Btype%5D=Book&resources%5BBook.29437949%5D%5Bid%5D=29437949&resources%5BBook.20640318%5D%5Btype%5D=Book&resources%5BBook.20640318%5D%5Bid%5D=20640318&resources%5BBook.15776309%5D%5Btype%5D=Book&resources%5BBook.15776309%5D%5Bid%5D=15776309&resources%5BBook.16171291%5D%5Btype%5D=Book&resources%5BBook.16171291%5D%5Bid%5D=16171291&resources%5BBook.28187230%5D%5Btype%5D=Book&resources%5BBook.28187230%5D%5Bid%5D=28187230&resources%5BBook.1914973%5D%5Btype%5D=Book&resources%5BBook.1914973%5D%5Bid%5D=1914973&resources%5BBook.25574782%5D%5Btype%5D=Book&resources%5BBook.25574782%5D%5Bid%5D=25574782&resources%5BBook.27834600%5D%5Btype%5D=Book&resources%5BBook.27834600%5D%5Bid%5D=27834600&resources%5BBook.28815474%5D%5Btype%5D=Book&resources%5BBook.28815474%5D%5Bid%5D=28815474&resources%5BBook.237209%5D%5Btype%5D=Book&resources%5BBook.237209%5D%5Bid%5D=237209&resources%5BBook.23125266%5D%5Btype%5D=Book&resources%5BBook.23125266%5D%5Bid%5D=23125266&resources%5BBook.59344312%5D%5Btype%5D=Book&resources%5BBook.59344312%5D%5Bid%5D=59344312&resources%5BBook.7159515%5D%5Btype%5D=Book&resources%5BBook.7159515%5D%5Bid%5D=7159515&resources%5BBook.22609317%5D%5Btype%5D=Book&resources%5BBook.22609317%5D%5Bid%5D=22609317&resources%5BBook.24345258%5D%5Btype%5D=Book&resources%5BBook.24345258%5D%5Bid%5D=24345258&resources%5BBook.21448484%5D%5Btype%5D=Book&resources%5BBook.21448484%5D%5Bid%5D=21448484&resources%5BBook.32263%5D%5Btype%5D=Book&resources%5BBook.32263%5D%5Bid%5D=32263&resources%5BBook.21718%5D%5Btype%5D=Book&resources%5BBook.21718%5D%5Bid%5D=21718&resources%5BBook.23638955%5D%5Btype%5D=Book&resources%5BBook.23638955%5D%5Bid%5D=23638955&resources%5BBook.33151805%5D%5Btype%5D=Book&resources%5BBook.33151805%5D%5Bid%5D=33151805&resources%5BBook.34189556%5D%5Btype%5D=Book&resources%5BBook.34189556%5D%5Bid%5D=34189556&resources%5BBook.16158525%5D%5Btype%5D=Book&resources%5BBook.16158525%5D%5Bid%5D=16158525&resources%5BBook.657034%5D%5Btype%5D=Book&resources%5BBook.657034%5D%5Bid%5D=657034&resources%5BBook.18007535%5D%5Btype%5D=Book&resources%5BBook.18007535%5D%5Bid%5D=18007535&resources%5BBook.16119032%5D%5Btype%5D=Book&resources%5BBook.16119032%5D%5Bid%5D=16119032&resources%5BBook.6534%5D%5Btype%5D=Book&resources%5BBook.6534%5D%5Bid%5D=6534&resources%5BBook.31450633%5D%5Btype%5D=Book&resources%5BBook.31450633%5D%5Bid%5D=31450633&resources%5BBook.20821043%5D%5Btype%5D=Book&resources%5BBook.20821043%5D%5Bid%5D=20821043&resources%5BBook.16131077%5D%5Btype%5D=Book&resources%5BBook.16131077%5D%5Bid%5D=16131077&resources%5BBook.41184315%5D%5Btype%5D=Book&resources%5BBook.41184315%5D%5Bid%5D=41184315&resources%5BBook.9783200%5D%5Btype%5D=Book&resources%5BBook.9783200%5D%5Bid%5D=9783200&resources%5BBook.23212667%5D%5Btype%5D=Book&resources%5BBook.23212667%5D%5Bid%5D=23212667&resources%5BBook.16142191%5D%5Btype%5D=Book&resources%5BBook.16142191%5D%5Bid%5D=16142191&resources%5BBook.18209468%5D%5Btype%5D=Book&resources%5BBook.18209468%5D%5Bid%5D=18209468&resources%5BBook.18635113%5D%5Btype%5D=Book&resources%5BBook.18635113%5D%5Bid%5D=18635113&resources%5BBook.16045136%5D%5Btype%5D=Book&resources%5BBook.16045136%5D%5Bid%5D=16045136&resources%5BBook.35297426%5D%5Btype%5D=Book&resources%5BBook.35297426%5D%5Bid%5D=35297426&resources%5BBook.65910%5D%5Btype%5D=Book&resources%5BBook.65910%5D%5Bid%5D=65910&resources%5BBook.11940384%5D%5Btype%5D=Book&resources%5BBook.11940384%5D%5Bid%5D=11940384&resources%5BBook.59917933%5D%5Btype%5D=Book&resources%5BBook.59917933%5D%5Bid%5D=59917933",
                JsonFilePath = ".assets/physics.json",
                SubjectId = 4
            });
            // Seeding chemistry documents
            await SeedingDocumentsBySubject(new DocumentSeederOptions
            {
                HtmlUrl = "https://www.goodreads.com/list/show/24108.Books_with_Best_Chemistry_Between_Characters",
                HtmlFilePath = ".assets/chemistry.html",
                JsonUrl = "https://www.goodreads.com/tooltips?resources%5BBook.11870085%5D%5Btype%5D=Book&resources%5BBook.11870085%5D%5Bid%5D=11870085&resources%5BBook.1885%5D%5Btype%5D=Book&resources%5BBook.1885%5D%5Bid%5D=1885&resources%5BBook.2767052%5D%5Btype%5D=Book&resources%5BBook.2767052%5D%5Bid%5D=2767052&resources%5BBook.256683%5D%5Btype%5D=Book&resources%5BBook.256683%5D%5Bid%5D=256683&resources%5BBook.7171637%5D%5Btype%5D=Book&resources%5BBook.7171637%5D%5Bid%5D=7171637&resources%5BBook.10210%5D%5Btype%5D=Book&resources%5BBook.10210%5D%5Bid%5D=10210&resources%5BBook.13335037%5D%5Btype%5D=Book&resources%5BBook.13335037%5D%5Bid%5D=13335037&resources%5BBook.6148028%5D%5Btype%5D=Book&resources%5BBook.6148028%5D%5Bid%5D=6148028&resources%5BBook.17931665%5D%5Btype%5D=Book&resources%5BBook.17931665%5D%5Bid%5D=17931665&resources%5BBook.41865%5D%5Btype%5D=Book&resources%5BBook.41865%5D%5Bid%5D=41865&resources%5BBook.11505797%5D%5Btype%5D=Book&resources%5BBook.11505797%5D%5Bid%5D=11505797&resources%5BBook.19063%5D%5Btype%5D=Book&resources%5BBook.19063%5D%5Bid%5D=19063&resources%5BBook.345627%5D%5Btype%5D=Book&resources%5BBook.345627%5D%5Bid%5D=345627&resources%5BBook.7260188%5D%5Btype%5D=Book&resources%5BBook.7260188%5D%5Bid%5D=7260188&resources%5BBook.15931%5D%5Btype%5D=Book&resources%5BBook.15931%5D%5Bid%5D=15931&resources%5BBook.6936382%5D%5Btype%5D=Book&resources%5BBook.6936382%5D%5Bid%5D=6936382&resources%5BBook.10964%5D%5Btype%5D=Book&resources%5BBook.10964%5D%5Bid%5D=10964&resources%5BBook.4268157%5D%5Btype%5D=Book&resources%5BBook.4268157%5D%5Bid%5D=4268157&resources%5BBook.10025305%5D%5Btype%5D=Book&resources%5BBook.10025305%5D%5Bid%5D=10025305&resources%5BBook.8437379%5D%5Btype%5D=Book&resources%5BBook.8437379%5D%5Bid%5D=8437379&resources%5BBook.16056408%5D%5Btype%5D=Book&resources%5BBook.16056408%5D%5Bid%5D=16056408&resources%5BBook.10818853%5D%5Btype%5D=Book&resources%5BBook.10818853%5D%5Bid%5D=10818853&resources%5BBook.6185%5D%5Btype%5D=Book&resources%5BBook.6185%5D%5Bid%5D=6185&resources%5BBook.13539044%5D%5Btype%5D=Book&resources%5BBook.13539044%5D%5Bid%5D=13539044&resources%5BBook.18405%5D%5Btype%5D=Book&resources%5BBook.18405%5D%5Bid%5D=18405&resources%5BBook.24337%5D%5Btype%5D=Book&resources%5BBook.24337%5D%5Bid%5D=24337&resources%5BBook.15717943%5D%5Btype%5D=Book&resources%5BBook.15717943%5D%5Bid%5D=15717943&resources%5BBook.49041%5D%5Btype%5D=Book&resources%5BBook.49041%5D%5Bid%5D=49041&resources%5BBook.8755776%5D%5Btype%5D=Book&resources%5BBook.8755776%5D%5Bid%5D=8755776&resources%5BBook.1162543%5D%5Btype%5D=Book&resources%5BBook.1162543%5D%5Bid%5D=1162543&resources%5BBook.4374400%5D%5Btype%5D=Book&resources%5BBook.4374400%5D%5Bid%5D=4374400&resources%5BBook.428263%5D%5Btype%5D=Book&resources%5BBook.428263%5D%5Bid%5D=428263&resources%5BBook.15760001%5D%5Btype%5D=Book&resources%5BBook.15760001%5D%5Bid%5D=15760001&resources%5BBook.99561%5D%5Btype%5D=Book&resources%5BBook.99561%5D%5Bid%5D=99561&resources%5BBook.15863832%5D%5Btype%5D=Book&resources%5BBook.15863832%5D%5Bid%5D=15863832&resources%5BBook.11235712%5D%5Btype%5D=Book&resources%5BBook.11235712%5D%5Bid%5D=11235712&resources%5BBook.13047090%5D%5Btype%5D=Book&resources%5BBook.13047090%5D%5Bid%5D=13047090&resources%5BBook.1421990%5D%5Btype%5D=Book&resources%5BBook.1421990%5D%5Bid%5D=1421990&resources%5BBook.12578077%5D%5Btype%5D=Book&resources%5BBook.12578077%5D%5Bid%5D=12578077&resources%5BBook.156538%5D%5Btype%5D=Book&resources%5BBook.156538%5D%5Bid%5D=156538&resources%5BBook.36466732%5D%5Btype%5D=Book&resources%5BBook.36466732%5D%5Bid%5D=36466732&resources%5BBook.13372690%5D%5Btype%5D=Book&resources%5BBook.13372690%5D%5Bid%5D=13372690&resources%5BBook.20448515%5D%5Btype%5D=Book&resources%5BBook.20448515%5D%5Bid%5D=20448515&resources%5BBook.8492825%5D%5Btype%5D=Book&resources%5BBook.8492825%5D%5Bid%5D=8492825&resources%5BBook.6280118%5D%5Btype%5D=Book&resources%5BBook.6280118%5D%5Bid%5D=6280118&resources%5BBook.331920%5D%5Btype%5D=Book&resources%5BBook.331920%5D%5Bid%5D=331920&resources%5BBook.10140661%5D%5Btype%5D=Book&resources%5BBook.10140661%5D%5Bid%5D=10140661&resources%5BBook.33724%5D%5Btype%5D=Book&resources%5BBook.33724%5D%5Bid%5D=33724&resources%5BBook.16081272%5D%5Btype%5D=Book&resources%5BBook.16081272%5D%5Bid%5D=16081272&resources%5BBook.17232634%5D%5Btype%5D=Book&resources%5BBook.17232634%5D%5Bid%5D=17232634",
                JsonFilePath = ".assets/chemistry.json",
                SubjectId = 5
            });
            // Seeding biology documents
            await SeedingDocumentsBySubject(new DocumentSeederOptions
            {
                HtmlUrl = "https://www.goodreads.com/list/show/2370.Best_General_Science_Books",
                HtmlFilePath = ".assets/biology.html",
                JsonUrl = "https://www.goodreads.com/tooltips?resources%5BBook.21%5D%5Btype%5D=Book&resources%5BBook.21%5D%5Bid%5D=21&resources%5BBook.3869%5D%5Btype%5D=Book&resources%5BBook.3869%5D%5Bid%5D=3869&resources%5BBook.61535%5D%5Btype%5D=Book&resources%5BBook.61535%5D%5Bid%5D=61535&resources%5BBook.55030%5D%5Btype%5D=Book&resources%5BBook.55030%5D%5Bid%5D=55030&resources%5BBook.1842%5D%5Btype%5D=Book&resources%5BBook.1842%5D%5Bid%5D=1842&resources%5BBook.22463%5D%5Btype%5D=Book&resources%5BBook.22463%5D%5Bid%5D=22463&resources%5BBook.5544%5D%5Btype%5D=Book&resources%5BBook.5544%5D%5Bid%5D=5544&resources%5BBook.17349%5D%5Btype%5D=Book&resources%5BBook.17349%5D%5Bid%5D=17349&resources%5BBook.6117055%5D%5Btype%5D=Book&resources%5BBook.6117055%5D%5Bid%5D=6117055&resources%5BBook.475%5D%5Btype%5D=Book&resources%5BBook.475%5D%5Bid%5D=475&resources%5BBook.2095%5D%5Btype%5D=Book&resources%5BBook.2095%5D%5Bid%5D=2095&resources%5BBook.24113%5D%5Btype%5D=Book&resources%5BBook.24113%5D%5Bid%5D=24113&resources%5BBook.17977%5D%5Btype%5D=Book&resources%5BBook.17977%5D%5Bid%5D=17977&resources%5BBook.4591%5D%5Btype%5D=Book&resources%5BBook.4591%5D%5Bid%5D=4591&resources%5BBook.22435%5D%5Btype%5D=Book&resources%5BBook.22435%5D%5Bid%5D=22435&resources%5BBook.23692271%5D%5Btype%5D=Book&resources%5BBook.23692271%5D%5Bid%5D=23692271&resources%5BBook.7170627%5D%5Btype%5D=Book&resources%5BBook.7170627%5D%5Bid%5D=7170627&resources%5BBook.61539%5D%5Btype%5D=Book&resources%5BBook.61539%5D%5Bid%5D=61539&resources%5BBook.32145%5D%5Btype%5D=Book&resources%5BBook.32145%5D%5Bid%5D=32145&resources%5BBook.17994%5D%5Btype%5D=Book&resources%5BBook.17994%5D%5Bid%5D=17994&resources%5BBook.27333%5D%5Btype%5D=Book&resources%5BBook.27333%5D%5Bid%5D=27333&resources%5BBook.13965%5D%5Btype%5D=Book&resources%5BBook.13965%5D%5Bid%5D=13965&resources%5BBook.513367%5D%5Btype%5D=Book&resources%5BBook.513367%5D%5Bid%5D=513367&resources%5BBook.126061%5D%5Btype%5D=Book&resources%5BBook.126061%5D%5Bid%5D=126061&resources%5BBook.6493208%5D%5Btype%5D=Book&resources%5BBook.6493208%5D%5Bid%5D=6493208&resources%5BBook.5752%5D%5Btype%5D=Book&resources%5BBook.5752%5D%5Bid%5D=5752&resources%5BBook.38412%5D%5Btype%5D=Book&resources%5BBook.38412%5D%5Bid%5D=38412&resources%5BBook.7247854%5D%5Btype%5D=Book&resources%5BBook.7247854%5D%5Bid%5D=7247854&resources%5BBook.21413662%5D%5Btype%5D=Book&resources%5BBook.21413662%5D%5Bid%5D=21413662&resources%5BBook.36475%5D%5Btype%5D=Book&resources%5BBook.36475%5D%5Bid%5D=36475&resources%5BBook.46722%5D%5Btype%5D=Book&resources%5BBook.46722%5D%5Bid%5D=46722&resources%5BBook.16176%5D%5Btype%5D=Book&resources%5BBook.16176%5D%5Bid%5D=16176&resources%5BBook.64666%5D%5Btype%5D=Book&resources%5BBook.64666%5D%5Bid%5D=64666&resources%5BBook.117047%5D%5Btype%5D=Book&resources%5BBook.117047%5D%5Bid%5D=117047&resources%5BBook.62555%5D%5Btype%5D=Book&resources%5BBook.62555%5D%5Bid%5D=62555&resources%5BBook.17910054%5D%5Btype%5D=Book&resources%5BBook.17910054%5D%5Bid%5D=17910054&resources%5BBook.815394%5D%5Btype%5D=Book&resources%5BBook.815394%5D%5Bid%5D=815394&resources%5BBook.49234%5D%5Btype%5D=Book&resources%5BBook.49234%5D%5Bid%5D=49234&resources%5BBook.294368%5D%5Btype%5D=Book&resources%5BBook.294368%5D%5Bid%5D=294368&resources%5BBook.485812%5D%5Btype%5D=Book&resources%5BBook.485812%5D%5Bid%5D=485812&resources%5BBook.64582%5D%5Btype%5D=Book&resources%5BBook.64582%5D%5Bid%5D=64582&resources%5BBook.1168341%5D%5Btype%5D=Book&resources%5BBook.1168341%5D%5Bid%5D=1168341&resources%5BBook.5546%5D%5Btype%5D=Book&resources%5BBook.5546%5D%5Bid%5D=5546&resources%5BBook.16213%5D%5Btype%5D=Book&resources%5BBook.16213%5D%5Bid%5D=16213&resources%5BBook.183645%5D%5Btype%5D=Book&resources%5BBook.183645%5D%5Bid%5D=183645&resources%5BBook.2493108%5D%5Btype%5D=Book&resources%5BBook.2493108%5D%5Bid%5D=2493108&resources%5BBook.61665%5D%5Btype%5D=Book&resources%5BBook.61665%5D%5Bid%5D=61665&resources%5BBook.61663%5D%5Btype%5D=Book&resources%5BBook.61663%5D%5Bid%5D=61663&resources%5BBook.59808264%5D%5Btype%5D=Book&resources%5BBook.59808264%5D%5Bid%5D=59808264&resources%5BBook.61538%5D%5Btype%5D=Book&resources%5BBook.61538%5D%5Bid%5D=61538",
                JsonFilePath = ".assets/biology.json",
                SubjectId = 6
            });
            // Seeding history documents
            await SeedingDocumentsBySubject(new DocumentSeederOptions
            {
                HtmlUrl = "https://www.goodreads.com/list/show/1362.Best_History_Books_",
                HtmlFilePath = ".assets/biology.html",
                JsonUrl = "https://www.goodreads.com/tooltips?resources%5BBook.2203%5D%5Btype%5D=Book&resources%5BBook.2203%5D%5Bid%5D=2203&resources%5BBook.767171%5D%5Btype%5D=Book&resources%5BBook.767171%5D%5Bid%5D=767171&resources%5BBook.1067%5D%5Btype%5D=Book&resources%5BBook.1067%5D%5Bid%5D=1067&resources%5BBook.2199%5D%5Btype%5D=Book&resources%5BBook.2199%5D%5Bid%5D=2199&resources%5BBook.40779082%5D%5Btype%5D=Book&resources%5BBook.40779082%5D%5Bid%5D=40779082&resources%5BBook.1842%5D%5Btype%5D=Book&resources%5BBook.1842%5D%5Bid%5D=1842&resources%5BBook.48855%5D%5Btype%5D=Book&resources%5BBook.48855%5D%5Bid%5D=48855&resources%5BBook.8664353%5D%5Btype%5D=Book&resources%5BBook.8664353%5D%5Bid%5D=8664353&resources%5BBook.76401%5D%5Btype%5D=Book&resources%5BBook.76401%5D%5Bid%5D=76401&resources%5BBook.2767%5D%5Btype%5D=Book&resources%5BBook.2767%5D%5Bid%5D=2767&resources%5BBook.568236%5D%5Btype%5D=Book&resources%5BBook.568236%5D%5Bid%5D=568236&resources%5BBook.21996%5D%5Btype%5D=Book&resources%5BBook.21996%5D%5Bid%5D=21996&resources%5BBook.21%5D%5Btype%5D=Book&resources%5BBook.21%5D%5Bid%5D=21&resources%5BBook.35100%5D%5Btype%5D=Book&resources%5BBook.35100%5D%5Bid%5D=35100&resources%5BBook.1617%5D%5Btype%5D=Book&resources%5BBook.1617%5D%5Bid%5D=1617&resources%5BBook.1362%5D%5Btype%5D=Book&resources%5BBook.1362%5D%5Bid%5D=1362&resources%5BBook.45546%5D%5Btype%5D=Book&resources%5BBook.45546%5D%5Bid%5D=45546&resources%5BBook.19400%5D%5Btype%5D=Book&resources%5BBook.19400%5D%5Bid%5D=19400&resources%5BBook.2279%5D%5Btype%5D=Book&resources%5BBook.2279%5D%5Bid%5D=2279&resources%5BBook.95784%5D%5Btype%5D=Book&resources%5BBook.95784%5D%5Bid%5D=95784&resources%5BBook.39020%5D%5Btype%5D=Book&resources%5BBook.39020%5D%5Bid%5D=39020&resources%5BBook.542389%5D%5Btype%5D=Book&resources%5BBook.542389%5D%5Bid%5D=542389&resources%5BBook.18300212%5D%5Btype%5D=Book&resources%5BBook.18300212%5D%5Bid%5D=18300212&resources%5BBook.27323%5D%5Btype%5D=Book&resources%5BBook.27323%5D%5Bid%5D=27323&resources%5BBook.261243%5D%5Btype%5D=Book&resources%5BBook.261243%5D%5Bid%5D=261243&resources%5BBook.40929%5D%5Btype%5D=Book&resources%5BBook.40929%5D%5Bid%5D=40929&resources%5BBook.42389%5D%5Btype%5D=Book&resources%5BBook.42389%5D%5Bid%5D=42389&resources%5BBook.51411855%5D%5Btype%5D=Book&resources%5BBook.51411855%5D%5Bid%5D=51411855&resources%5BBook.44234%5D%5Btype%5D=Book&resources%5BBook.44234%5D%5Bid%5D=44234&resources%5BBook.139069%5D%5Btype%5D=Book&resources%5BBook.139069%5D%5Bid%5D=139069&resources%5BBook.130363%5D%5Btype%5D=Book&resources%5BBook.130363%5D%5Bid%5D=130363&resources%5BBook.93426%5D%5Btype%5D=Book&resources%5BBook.93426%5D%5Bid%5D=93426&resources%5BBook.40961608%5D%5Btype%5D=Book&resources%5BBook.40961608%5D%5Bid%5D=40961608&resources%5BBook.16130%5D%5Btype%5D=Book&resources%5BBook.16130%5D%5Bid%5D=16130&resources%5BBook.10414941%5D%5Btype%5D=Book&resources%5BBook.10414941%5D%5Bid%5D=10414941&resources%5BBook.4820%5D%5Btype%5D=Book&resources%5BBook.4820%5D%5Bid%5D=4820&resources%5BBook.347610%5D%5Btype%5D=Book&resources%5BBook.347610%5D%5Bid%5D=347610&resources%5BBook.26348%5D%5Btype%5D=Book&resources%5BBook.26348%5D%5Bid%5D=26348&resources%5BBook.70561%5D%5Btype%5D=Book&resources%5BBook.70561%5D%5Bid%5D=70561&resources%5BBook.133486%5D%5Btype%5D=Book&resources%5BBook.133486%5D%5Bid%5D=133486&resources%5BBook.17780%5D%5Btype%5D=Book&resources%5BBook.17780%5D%5Bid%5D=17780&resources%5BBook.29022%5D%5Btype%5D=Book&resources%5BBook.29022%5D%5Bid%5D=29022&resources%5BBook.192955%5D%5Btype%5D=Book&resources%5BBook.192955%5D%5Bid%5D=192955&resources%5BBook.296662%5D%5Btype%5D=Book&resources%5BBook.296662%5D%5Bid%5D=296662&resources%5BBook.40923%5D%5Btype%5D=Book&resources%5BBook.40923%5D%5Bid%5D=40923&resources%5BBook.94799%5D%5Btype%5D=Book&resources%5BBook.94799%5D%5Bid%5D=94799&resources%5BBook.7648269%5D%5Btype%5D=Book&resources%5BBook.7648269%5D%5Bid%5D=7648269&resources%5BBook.475%5D%5Btype%5D=Book&resources%5BBook.475%5D%5Bid%5D=475&resources%5BBook.25019%5D%5Btype%5D=Book&resources%5BBook.25019%5D%5Bid%5D=25019&resources%5BBook.146274%5D%5Btype%5D=Book&resources%5BBook.146274%5D%5Bid%5D=146274",
                JsonFilePath = ".assets/biology.json",
                SubjectId = 7
            });
            // Seeding geography documents
            await SeedingDocumentsBySubject(new DocumentSeederOptions
            {
                HtmlUrl = "https://www.goodreads.com/list/show/35857.The_Most_Popular_Fantasy_on_Goodreads",
                HtmlFilePath = ".assets/biology.html",
                JsonUrl = "https://www.goodreads.com/tooltips?resources%5BBook.186074%5D%5Btype%5D=Book&resources%5BBook.186074%5D%5Bid%5D=186074&resources%5BBook.61215351%5D%5Btype%5D=Book&resources%5BBook.61215351%5D%5Bid%5D=61215351&resources%5BBook.5907%5D%5Btype%5D=Book&resources%5BBook.5907%5D%5Bid%5D=5907&resources%5BBook.13496%5D%5Btype%5D=Book&resources%5BBook.13496%5D%5Bid%5D=13496&resources%5BBook.5%5D%5Btype%5D=Book&resources%5BBook.5%5D%5Bid%5D=5&resources%5BBook.3%5D%5Btype%5D=Book&resources%5BBook.3%5D%5Bid%5D=3&resources%5BBook.136251%5D%5Btype%5D=Book&resources%5BBook.136251%5D%5Bid%5D=136251&resources%5BBook.6%5D%5Btype%5D=Book&resources%5BBook.6%5D%5Bid%5D=6&resources%5BBook.68428%5D%5Btype%5D=Book&resources%5BBook.68428%5D%5Bid%5D=68428&resources%5BBook.61215384%5D%5Btype%5D=Book&resources%5BBook.61215384%5D%5Bid%5D=61215384&resources%5BBook.61215372%5D%5Btype%5D=Book&resources%5BBook.61215372%5D%5Bid%5D=61215372&resources%5BBook.1%5D%5Btype%5D=Book&resources%5BBook.1%5D%5Bid%5D=1&resources%5BBook.7235533%5D%5Btype%5D=Book&resources%5BBook.7235533%5D%5Bid%5D=7235533&resources%5BBook.15881%5D%5Btype%5D=Book&resources%5BBook.15881%5D%5Bid%5D=15881&resources%5BBook.2%5D%5Btype%5D=Book&resources%5BBook.2%5D%5Bid%5D=2&resources%5BBook.1215032%5D%5Btype%5D=Book&resources%5BBook.1215032%5D%5Bid%5D=1215032&resources%5BBook.62291%5D%5Btype%5D=Book&resources%5BBook.62291%5D%5Bid%5D=62291&resources%5BBook.100915%5D%5Btype%5D=Book&resources%5BBook.100915%5D%5Bid%5D=100915&resources%5BBook.228665%5D%5Btype%5D=Book&resources%5BBook.228665%5D%5Bid%5D=228665&resources%5BBook.33%5D%5Btype%5D=Book&resources%5BBook.33%5D%5Bid%5D=33&resources%5BBook.10572%5D%5Btype%5D=Book&resources%5BBook.10572%5D%5Bid%5D=10572&resources%5BBook.119322%5D%5Btype%5D=Book&resources%5BBook.119322%5D%5Bid%5D=119322&resources%5BBook.10664113%5D%5Btype%5D=Book&resources%5BBook.10664113%5D%5Bid%5D=10664113&resources%5BBook.12067%5D%5Btype%5D=Book&resources%5BBook.12067%5D%5Bid%5D=12067&resources%5BBook.30165203%5D%5Btype%5D=Book&resources%5BBook.30165203%5D%5Bid%5D=30165203&resources%5BBook.13497%5D%5Btype%5D=Book&resources%5BBook.13497%5D%5Bid%5D=13497&resources%5BBook.14497%5D%5Btype%5D=Book&resources%5BBook.14497%5D%5Bid%5D=14497&resources%5BBook.28187%5D%5Btype%5D=Book&resources%5BBook.28187%5D%5Bid%5D=28187&resources%5BBook.34497%5D%5Btype%5D=Book&resources%5BBook.34497%5D%5Bid%5D=34497&resources%5BBook.113436%5D%5Btype%5D=Book&resources%5BBook.113436%5D%5Bid%5D=113436&resources%5BBook.21787%5D%5Btype%5D=Book&resources%5BBook.21787%5D%5Bid%5D=21787&resources%5BBook.16793%5D%5Btype%5D=Book&resources%5BBook.16793%5D%5Bid%5D=16793&resources%5BBook.33574273%5D%5Btype%5D=Book&resources%5BBook.33574273%5D%5Bid%5D=33574273&resources%5BBook.170448%5D%5Btype%5D=Book&resources%5BBook.170448%5D%5Bid%5D=170448&resources%5BBook.11127%5D%5Btype%5D=Book&resources%5BBook.11127%5D%5Bid%5D=11127&resources%5BBook.76620%5D%5Btype%5D=Book&resources%5BBook.76620%5D%5Bid%5D=76620&resources%5BBook.7896527%5D%5Btype%5D=Book&resources%5BBook.7896527%5D%5Bid%5D=7896527&resources%5BBook.2213661%5D%5Btype%5D=Book&resources%5BBook.2213661%5D%5Bid%5D=2213661&resources%5BBook.17245%5D%5Btype%5D=Book&resources%5BBook.17245%5D%5Bid%5D=17245&resources%5BBook.77197%5D%5Btype%5D=Book&resources%5BBook.77197%5D%5Bid%5D=77197&resources%5BBook.256683%5D%5Btype%5D=Book&resources%5BBook.256683%5D%5Bid%5D=256683&resources%5BBook.10964%5D%5Btype%5D=Book&resources%5BBook.10964%5D%5Bid%5D=10964&resources%5BBook.43763%5D%5Btype%5D=Book&resources%5BBook.43763%5D%5Bid%5D=43763&resources%5BBook.13023%5D%5Btype%5D=Book&resources%5BBook.13023%5D%5Bid%5D=13023&resources%5BBook.157993%5D%5Btype%5D=Book&resources%5BBook.157993%5D%5Bid%5D=157993&resources%5BBook.41637836%5D%5Btype%5D=Book&resources%5BBook.41637836%5D%5Bid%5D=41637836&resources%5BBook.6310%5D%5Btype%5D=Book&resources%5BBook.6310%5D%5Bid%5D=6310&resources%5BBook.17061%5D%5Btype%5D=Book&resources%5BBook.17061%5D%5Bid%5D=17061&resources%5BBook.7332%5D%5Btype%5D=Book&resources%5BBook.7332%5D%5Bid%5D=7332&resources%5BBook.39988%5D%5Btype%5D=Book&resources%5BBook.39988%5D%5Bid%5D=39988",
                JsonFilePath = ".assets/biology.json",
                SubjectId = 8
            });

            Console.WriteLine("Seeding documents successfully :)");

        }

        public async Task SeedingMarks()
        {
            var count = _unitOfWork.MarkRepository.Count();
            if (count > 0)
            {
                System.Console.WriteLine("Marks had been seeded before. Aborting...");
                return;
            }

            var marks = new List<Mark>();
            var students = await _unitOfWork.StudentRepository.GetAll(null, null, null, null);
            var subjects = await _unitOfWork.SubjectRepository.GetAll(null, null, null, null);

            var random = new Random();

            foreach (var student in students)
            {
                foreach (var subject in subjects)
                {
                    for (var i = 0; i < 6; i++)
                    {
                        var mark = new Mark
                        {
                            StudentId = student.Id,
                            SubjectId = subject.Id,
                            Semester = i % 2 == 0 ? (byte)1 : (byte)2,
                            FromYear = 2022 + (i / 2),
                            ToYear = 2023 + (i / 2),

                        };
                        if (i <= 1)
                        {
                            mark.Oral_1 = random.Next(6, 10);
                            mark.Oral_2 = random.Next(6, 10);
                            mark.Test15_1 = random.Next(5, 10);
                            mark.Test15_2 = random.Next(5, 10);
                            mark.Test15_3 = random.Next(6, 10);
                            mark.Test45_1 = random.Next(60, 100) / 10.0;
                            mark.Test45_2 = random.Next(50, 100) / 10.0;
                            mark.Test60 = random.Next(60, 100) / 10.0;
                        }
                        if (i == 2)
                        {
                            mark.Oral_1 = random.Next(4, 10);
                            mark.Oral_2 = random.Next(5, 10);
                            mark.Test15_1 = random.Next(6, 10);
                            mark.Test15_2 = random.Next(5, 10);
                            mark.Test15_3 = random.Next(4, 10);
                        }
                        marks.Add(mark);
                    }
                }
            }
            await _unitOfWork.MarkRepository.AddRange(marks);
            await _unitOfWork.Save();

            System.Console.WriteLine("Seeding marks successfully :)");

        }

        public async Task SeedingTimetables()
        {
            var count = _unitOfWork.TimetableRepository.Count();
            if (count > 0)
            {
                System.Console.WriteLine("Timetables had been seeded before. Aborting...");
                return;
            }
            var teachers = (await _unitOfWork.TeacherRepository.GetAll(null, null, null, null)).ToArray<Teacher>();
            var timetables = new List<Timetable>();
            var random = new Random();

            var startDate = new DateTime(2023, 9, 1);
            for (var i = 0; i < 90; i++)
            {
                if (startDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    startDate = startDate.AddDays(1);
                    continue;
                }
                var r = random.Next(0, 2);

                var day = new List<Timetable>();
                for (var j = 0; j < 4; j++)
                {
                    r = 0;
                    var rrr = random.Next(0, 3);
                    var rr = random.Next(0, teachers.Length);
                    if (r == 0)
                    {
                        var timetable = new Timetable
                        {
                            MainClassId = 6,
                            From = startDate.AddHours(TimetableRandomer.MorningTimes[j].From.Hour).AddMinutes(TimetableRandomer.MorningTimes[j].From.Minute),
                            To = startDate.AddHours(TimetableRandomer.MorningTimes[j].To.Hour).AddMinutes(TimetableRandomer.MorningTimes[j].To.Minute),
                            TeacherId = teachers[rr].Id,
                            Topic = TimetableRandomer.Topics[((int)(await _unitOfWork.TeacherRepository.GetSingle(t => t.Id == teachers[rr].Id)).SubjectId) - 1][rrr]
                        };
                        day.Add(timetable);
                    }
                    else if (r == 1)
                    {
                        var timetable = new Timetable
                        {
                            MainClassId = 6,
                            From = startDate.AddHours(TimetableRandomer.AfternoonTimes[j].From.Hour).AddMinutes(TimetableRandomer.AfternoonTimes[j].From.Minute),
                            To = startDate.AddHours(TimetableRandomer.AfternoonTimes[j].To.Hour).AddMinutes(TimetableRandomer.AfternoonTimes[j].To.Minute),
                            TeacherId = teachers[rr].Id,
                            Topic = TimetableRandomer.Topics[((int)(await _unitOfWork.TeacherRepository.GetSingle(t => t.Id == teachers[rr].Id)).SubjectId) - 1][rrr]
                        };
                        day.Add(timetable);
                    }
                }
                for (var j = 0; j < 4; j++)
                {
                    r = 1;
                    var rrr = random.Next(0, 3);
                    var rr = random.Next(0, teachers.Length);
                    if (r == 0)
                    {
                        var timetable = new Timetable
                        {
                            MainClassId = 6,
                            From = startDate.AddHours(TimetableRandomer.MorningTimes[j].From.Hour).AddMinutes(TimetableRandomer.MorningTimes[j].From.Minute),
                            To = startDate.AddHours(TimetableRandomer.MorningTimes[j].To.Hour).AddMinutes(TimetableRandomer.MorningTimes[j].To.Minute),
                            TeacherId = teachers[rr].Id,
                            Topic = TimetableRandomer.Topics[((int)(await _unitOfWork.TeacherRepository.GetSingle(t => t.Id == teachers[rr].Id)).SubjectId) - 1][rrr]
                        };
                        day.Add(timetable);
                    }
                    else if (r == 1)
                    {
                        var timetable = new Timetable
                        {
                            MainClassId = 6,
                            From = startDate.AddHours(TimetableRandomer.AfternoonTimes[j].From.Hour).AddMinutes(TimetableRandomer.AfternoonTimes[j].From.Minute),
                            To = startDate.AddHours(TimetableRandomer.AfternoonTimes[j].To.Hour).AddMinutes(TimetableRandomer.AfternoonTimes[j].To.Minute),
                            TeacherId = teachers[rr].Id,
                            Topic = TimetableRandomer.Topics[((int)(await _unitOfWork.TeacherRepository.GetSingle(t => t.Id == teachers[rr].Id)).SubjectId) - 1][rrr]
                        };
                        day.Add(timetable);
                    }
                }
                timetables.AddRange(day);
                startDate = startDate.AddDays(1);
            }
            await _unitOfWork.TimetableRepository.AddRange(timetables);
            await _unitOfWork.Save();
            System.Console.WriteLine("Seeding timetables successfully :)");
        }

        public async Task SeedingAcademicProgresses()
        {
            var count = _unitOfWork.AcademicProgressRepository.Count();
            if (count > 0)
            {
                System.Console.WriteLine("Academic progresses had been seeded before. Aborting...");
                return;
            }

            var r = new Random();
            var temp = await _unitOfWork.TimetableRepository.GetAll(null);
            var timetables = temp.Where(t => t.From <= DateTime.UtcNow && t.To <= DateTime.UtcNow);
            var academicProgresses = new List<AcademicProgress>();
            int[] attendances = { -2, -1, 0, 1 };
            foreach (var t in timetables)
            {
                var academicProgress = new AcademicProgress
                {
                    TimetableId = t.Id,
                    Attendance = r.Next(-2, 2),
                    IsDoneHomework = r.Next(0, 2) == 1,
                    TeacherComment = "Nothing to comment.",
                    StudentId = 1
                };
                academicProgresses.Add(academicProgress);
            }

            await _unitOfWork.AcademicProgressRepository.AddRange(academicProgresses);
            await _unitOfWork.Save();
            System.Console.WriteLine("Seeding academic progresses successfully :)");
        }

        public async Task SeedingAcademicTracker()
        {
            var count = _unitOfWork.AcademicTrackerRepository.Count();
            if (count > 0)
            {
                System.Console.WriteLine("Academic trackers had been seeded before. Aborting...");
                return;
            }

            var dictionary = new Dictionary<DateTime, AcademicTracker>();
            var academicProgresses = await _unitOfWork.AcademicProgressRepository.GetAll(null, null, null, new List<string> { "Timetable.Teacher.Subject", "Timetable" });
            foreach (var aP in academicProgresses)
            {
                if (!dictionary.ContainsDate(aP.Timetable.From))
                {
                    dictionary.Add(aP.Timetable.From, new AcademicTracker
                    {
                        Date = aP.Timetable.From,
                        StudentId = aP.StudentId,
                        Attendance = AcademicRandomer.BuildAttendance(aP),
                        Homework = AcademicRandomer.BuildHomework(aP),
                        TeacherComment = AcademicRandomer.BuildTeacherComment(aP)
                    });
                }
                else
                {
                    var academicTracker = dictionary.GetAcademicTrackerAtDate(aP.Timetable.From);
                    if (AcademicRandomer.BuildAttendance(aP) is not null) academicTracker.Attendance += AcademicRandomer.BuildAttendance(aP);
                    if (AcademicRandomer.BuildHomework(aP) is not null) academicTracker.Homework += AcademicRandomer.BuildHomework(aP);
                    if (AcademicRandomer.BuildTeacherComment(aP) is not null) academicTracker.TeacherComment += AcademicRandomer.BuildTeacherComment(aP);
                }
            }
            var academicTrackers = dictionary.Values.ToArray<AcademicTracker>();

            await _unitOfWork.AcademicTrackerRepository.AddRange(academicTrackers);
            await _unitOfWork.Save();

            System.Console.WriteLine("Seeding academic trackers successfully :)");
        }
    }
}