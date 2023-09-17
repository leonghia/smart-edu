import { getToken } from "../helpers/token.helper.js";
import { BASE_URL } from "../app.config.js";
import { getData, postData } from "../helpers/ajax.helper.js";

class DataService {

    async getStudents() {
        return await getData(`${BASE_URL}/Student`);
    }

    async getMainClasses() {
        return await getData(`${BASE_URL}/MainClass`);
    }

    async getExtraClasses() {
        return await getData(`${BASE_URL}/ExtraClass`);
    }

    async addExtraClassStudent(addExtraClassStudentDTO) {
        return await postData(`${BASE_URL}/ExtraClassStudent`, addExtraClassStudentDTO);
    }

    async getCurrentUser() {
        return await getData(`${BASE_URL}/Account/user`);
    }
}

export default new DataService();