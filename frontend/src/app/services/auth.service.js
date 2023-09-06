import { getData, login } from "../helpers/data.helper.js";
import { BASE_URL } from "../app.config.js";

class AuthService {

    // private: chi duoc phep truy cap trong class, ben ngoai khong duoc truy cap
    #token = localStorage.getItem("token");

    async login(loginUserDTO) { // loginUserDTO {username: "no1hoatieu", password: "12345"}
       return await login(`${BASE_URL}/Account/login`, loginUserDTO);
    }

    get _token() {
        return this.#token;
    }

    logout() {

    }

    // Kiem tra xem token con han khong
    async getCurrentUser() {
        return await getData(`${BASE_URL}/Account/user`);
    }
}

export default new AuthService();