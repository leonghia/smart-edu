import { login } from "../helpers/data.helper.js";
import { BASE_URL } from "../app.config.js";

class AuthService {
  //private chi dc phep truy cap trong class ben ngoai khong the truy cap
  #token = localStorage.getItem("token");

  async login(loginUserDTO) {
    return await login(`${BASE_URL}/login`, loginUserDTO);
  }

  get _token() {
    return this.#token;
  }

  logout() {}
}

export default new AuthService();
