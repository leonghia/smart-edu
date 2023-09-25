import { getToken } from "../helpers/token.helper.js";
import { BASE_URL } from "../app.config.js";
import { getData, postData, updateData } from "../helpers/ajax.helper.js";
import { data } from "../app.store.js";
import { RequestParams } from "../models/request-params.model.js";
import { DocumentFilterRequestParams } from "../models/docFilterRequestParams.js";

class DataService {

    async getStudents(requestParams = new RequestParams()) {
        return await getData(`${BASE_URL}/Student?PageSize=${requestParams.pageSize}&PageNumber=${requestParams.pageNumber}`);
    }

    async getMainClasses(requestParams = new RequestParams()) {
        return await getData(`${BASE_URL}/MainClass?PageSize=${requestParams.pageSize}&PageNumber=${requestParams.pageNumber}`);
    }

    async getExtraClasses(requestParams = new RequestParams()) {
        return await getData(`${BASE_URL}/ExtraClass?PageSize=${requestParams.pageSize}&PageNumber=${requestParams.pageNumber}`);
    }

    async getSubjects(requestParams = new RequestParams()) {
        return await getData(`${BASE_URL}/Subject?PageSize=${requestParams.pageSize}&PageNumber=${requestParams.pageNumber}`);
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

    async getDocuments(requestParams = new RequestParams(), documentFilterRequestParams = new DocumentFilterRequestParams()) {
        return await getData(`${BASE_URL}/Document?PageSize=${requestParams.pageSize}&PageNumber=${requestParams.pageNumber}&SubjectId=${documentFilterRequestParams.subjectId}&FromNumbersOfRating=${documentFilterRequestParams.fromNumbersOfRating}&ToNumbersOfRating=${documentFilterRequestParams.toNumbersOfRating}&FromRating=${documentFilterRequestParams.fromRating}&ToRating=${documentFilterRequestParams.toRating}`);
    }

    async getDocumentsCount(documentFilterRequestParams = new DocumentFilterRequestParams()) {
        return await getData(`${BASE_URL}/Document/count?SubjectId=${documentFilterRequestParams.subjectId}&FromNumbersOfRating=${documentFilterRequestParams.fromNumbersOfRating}&ToNumbersOfRating=${documentFilterRequestParams.toNumbersOfRating}&FromRating=${documentFilterRequestParams.fromRating}&ToRating=${documentFilterRequestParams.toRating}`);
    }

    async getDocumentsCountEachsubject()
    {
        return await getData(`${BASE_URL}/Document/count-each`);
    }
}

export default new DataService();