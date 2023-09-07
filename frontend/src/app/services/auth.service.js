import { BASE_URL } from "../app.config.js";


class AuthService {

    constructor() {

    }

    checkToken() { // public boolean checkToken
        // Kiem tra xem token co tren trinh duyet khong
        // neu cos tra ve token
        // neu khong tra ve null

            return localStorage.getItem("token");
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
                "Authorization": `Bearer ${this.checkToken()}`
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
        const data = await response.json();

        if (data.data){
            localStorage.setItem("token",data);
        }else{
            console.error("Sai ten nguoi dung hoac mat khau.");
        }
    }
}

export default new AuthService();