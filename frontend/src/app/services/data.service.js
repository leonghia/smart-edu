import { getToken } from "../helpers/token.helper.js";
import { BASE_URL } from "../app.config.js";
import { getData, postData, updateData } from "../helpers/ajax.helper.js";
import { data } from "../app.store.js";
import { RequestParams } from "../models/requestParams.js";
import { DocumentFilterRequestParams } from "../models/docFilterRequestParams.js";
import { MarkFilterOption } from "../models/markFilterOption.js";
import { TimetableRequestParams } from "../models/timetableRequestParams.js";
import { toISOVNString } from "../helpers/datetime.helper.js";
import { AcademicProgressRequestParams } from "../models/academicProgressRequestParams.js";
import { AcademicTrackerRequestParams } from "../models/academicTrackerRequestParams.js";

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

    async getDocumentsCountEachSubject() {
        return await getData(`${BASE_URL}/Document/count-each`);
    }

    async getMainClassById(id) {
        return await getData(`${BASE_URL}/MainClass/${id}`);
    }

    async getRanking(id = 0, markFilterOption = new MarkFilterOption()) {
        return await getData(`${BASE_URL}/Mark/ranking/${id}?Semester=${markFilterOption.semester}&FromYear=${markFilterOption.fromYear}&ToYear=${markFilterOption.toYear}`);
    }

    async getTimetableByWeek(timetableRequestParams = new TimetableRequestParams()) {
        const from = toISOVNString(timetableRequestParams.from);
        const to = toISOVNString(timetableRequestParams.to);
        return await getData(`${BASE_URL}/Timetable?MainClassId=${timetableRequestParams.mainClassId}&From=${from}&To=${to}`);
    }

    async getAcademicProgressByDate(academicProgressRequestParams = new AcademicProgressRequestParams()) {
        const date = toISOVNString(academicProgressRequestParams.date);
        return await getData(`${BASE_URL}/AcademicProgress?StudentId=${academicProgressRequestParams.studentId}&Date=${date}`);
    }

    async getAcademicTrackersByStudent(academicTrackerRequestParams = new AcademicTrackerRequestParams()) {
        const from = toISOVNString(academicTrackerRequestParams.from);
        const to = toISOVNString(academicTrackerRequestParams.to);
        return await getData(`${BASE_URL}/AcademicTracker?StudentId=${academicTrackerRequestParams.studentId}&From=${from}&To=${to}`);
    }
}

export default new DataService();