export const getToken = function () { // public string | null getToken
    // Kiem tra xem token co tren trinh duyet khong
    // neu co tra ve token: string
    // neu khong tra ve null
    return localStorage.getItem("token");
}

export const saveToken = function (value) {

    localStorage.setItem("token", value);

}

/**
 * Hàm lưu token vào session storage.
 * @param {string} value Giá trị của token cần lưu . 
 * @returns {void} 
 * @author Trịnh Đình Quốc <draogon10a3@gmail.com>
 */

export const saveTokenToSession = function (value) {
    sessionStorage.setItem("token", value);
}
