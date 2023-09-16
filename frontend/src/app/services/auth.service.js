import { BASE_URL } from "../app.config.js";
import { getToken } from "../helpers/token.helper.js";

class AuthService {

    constructor() {

    }

    // kiem tra thong tin ve nguoi dung di cung token (ket noi voi server)
    // neu token hop le, tra ve thong tin nguoi dung 
    // neu token khong hop le ( token het han hoac to ken bi sai), tra vef ERROR (401)
    // GET,POST, PUT,DELETE
    async getCurentUser(){ //async vaf await luon di cung voi nhau
         // AJAX : la 1 ky thuat dung de ket noi ma khong can load lai trang
        const response = await fetch(`${BASE_URL}/Account/user`,{
            method: "GET",
            mode: "cors",
            cache: "no-cache",
            credentials: "same-origin",
            headers:{
                "Authorization": `Bearer ${getToken()}`
            },
            redirect: "follow",
            referrerPolicy: "no-referrer"
        });
        return await response.json();
    }

    async login(loginUserDTO){ // loginUserDTO: {username: "phuc",password:12345}
        /*
        loginUserDTO = {
        username : "phuc",
        password: "12345"
        }
       
        */
        const response = await fetch(`${BASE_URL}/Account/login`,{
            method: "POST", // tai sao loogin phai dung phuong thuc POST chu khong phai GET
            mode: "cors",
            cache: "no-cache",
            credentials: "same-origin",
            headers: {
                "Content-Type": "application/json"
            },
            redirect: "follow",
            referrer: "no-referrer",
            body: JSON.stringify(loginUserDTO)
        });
        return await response.json();
    }

    logout() {
        // buoc 1: xoa token o session storage
        sessionStorage.removeItem("token");
        sessionStorage.clear();

        // buoc 2 : xoa token o local storage
        localStorage.removeItem("token");

        // buoc 3: tai lai trang web
        location.reload();


    };

}

export default new AuthService();