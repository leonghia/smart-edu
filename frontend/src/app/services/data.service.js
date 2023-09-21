import { getToken } from "../helpers/token.helper.js";
import { BASE_URL } from "../app.config.js";
import { getData, postData, updateData } from "../helpers/ajax.helper.js";
import { data } from "../app.store.js";

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

    async getSubjects() {
        return await getData(`${BASE_URL}/Subject`);
    }

    async registerExtraClass(addExtraClassStudentDTO) {
        return await postData(`${BASE_URL}/ExtraClassStudent`, addExtraClassStudentDTO);
    }

    async unregisterExtraClass(deleteExtraClassStudentDTO) {
        return await updateData(`${BASE_URL}/ExtraClassStudent`, deleteExtraClassStudentDTO);
    }

    async getCurrentUser() {
        return await getData(`${BASE_URL}/Account/user`);
    }

    async getStudent(id) {
        return await getData(`${BASE_URL}/Student/${id}`);
    }

    async bookmarkExtraClass(addExtraClassEcBookmarkDTO) {
        return await postData(`${BASE_URL}/ExtraClassEcBookmark`, addExtraClassEcBookmarkDTO);
    }

    async unbookmarkExtraClass(deleteExtraClassEcBookmarkDTO) {
        return await updateData(`${BASE_URL}/ExtraClassEcBookmark`, deleteExtraClassEcBookmarkDTO);
    }
}

export default new DataService();