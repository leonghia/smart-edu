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

