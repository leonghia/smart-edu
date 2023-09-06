import { getData, login } from "../helpers/data.helper.js";
import { BASE_URL } from "../app.config.js";

class AuthService {
  //private chi dc phep truy cap trong class ben ngoai khong the truy cap
  #token = localStorage.getItem("token");

  async login(loginUserDTO) {
    return await login(`${BASE_URL}/Account/login`, loginUserDTO);
  }

  get _token() {
    return this.#token;
  }

  logout() {}
  //kiem tra xem token con han k
  async getCurrentUser() {
    return await getData(`${BASE_URL}/Account/user`);
  }
}

export default new AuthService();
