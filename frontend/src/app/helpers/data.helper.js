export const getToken = function () { // public string | null getToken
    // Kiem tra xem token co tren trinh duyet khong
    // neu co tra ve token: string
    // neu khong tra ve null
    return localStorage.getItem("token");
}