 export const convertDateTimeToVn = function(datetime) {
    //Buoc 1: Lay 10 ki tu dau cua datetime 
    const dt = datetime.slice(0,10);

    //Buoc 2: Dinh dang theo kieu thoi gian cua Viet Nam
    //2.1 : Tach rieng ngay, thang, nam thanh 3 phan tu cua 1 mang
    const dtArr = dt.split("-"); //["2006", "10", "06"]
    //2.2 :  Dao nguoc nam va ngay ["06", "10", "2006"]
    const temp = dtArr[0];
    dtArr[0] = dtArr[2];
    dtArr[2] = temp;
    //2.3 : Ghep 3 phan tu vao va phan tach boi dau gach cheo
    return dtArr.join("/");

}

export const convertDateTimeToISO = function(datetime) {
    //2008-09-21T00:00:00	
    const dtISOArr = datetime.split("/");
    const temp = dtISOArr[0];
    dtISOArr[0] = dtISOArr[2];
    dtISOArr[2] = temp;
    return dtISOArr.join("-") + "T00:00:00";
}

export const convertTime = function(time) {
    const t = time.slice(0,5);
    return t;
}
//Cach 1:
// export const convertWeekday = function(weekday) {
//     switch(weekday) {
//         case 1:
//             return "Monday";
//         case 2:
//             return "Tuesday";
//         case 3: 
//             return "Wednesday";    
//         case 4:
//             return "Thursday";
//         case 5:
//             return "Friday";
//         case 6: 
//             return "Saturday";
//         case 0:
//             return "Sunday";
//     }
// }


//Cach 2: Dung enum
export const convertWeekday = {
    0: "Sunday",
    1: "Monday",
    2: "Tuesday",
    3: "Wednesday",
    4: "Thursday",
    5: "Friday",
    6: "Saturday"
};